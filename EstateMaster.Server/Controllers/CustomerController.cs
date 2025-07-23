using System.Data;
using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Core.Models;
using EstateMaster.Server.Helper;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;

[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private IAppSettings appSettings { get; set; }

    public CustomerController(IAppSettings appSettings)
    {
        this.appSettings = appSettings;
    }
    /// <summary>
    /// Yeni müşteri kaydı oluşturur.
    /// sp_create_customer prosedürü çağrılarak UUID ve işlem sonucu döner.
    /// </summary>
    [HttpPost]
    [Route("CreateCustomer")]
    public CustomerResponse CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        CustomerResponse response = new CustomerResponse();
        string CommandText = @"CALL sp_create_customer(@$first_name, @$last_name, @$email, @$phone,
                                                         @$customer_type, @$budget_min, @$budget_max,
                                                         @$preferred_province, @$preferred_district, @$preferred_neighborhood,
                                                         @$oresult, @$intID);";

        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();
        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {
                // Giriş parametreleri
                command.Parameters.AddWithValue("@$first_name", request.FirstName);
                command.Parameters.AddWithValue("@$last_name", request.LastName);
                command.Parameters.AddWithValue("@$email", request.Email);
                command.Parameters.AddWithValue("@$phone", request.Phone);
                command.Parameters.AddWithValue("@$customer_type", request.CustomerType);
                command.Parameters.AddWithValue("@$budget_min", request.BudgetMin);
                command.Parameters.AddWithValue("@$budget_max", request.BudgetMax);
                command.Parameters.AddWithValue("@$preferred_province", request.PreferredProvince);
                command.Parameters.AddWithValue("@$preferred_district", request.PreferredDistrict);
                command.Parameters.AddWithValue("@$preferred_neighborhood", request.PreferredNeighborhood);

                // Çıkış parametreleri
                command.Parameters.Add(new MySqlParameter("@$oresult", MySqlDbType.VarChar) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new MySqlParameter("@$intID", MySqlDbType.VarChar) { Direction = ParameterDirection.Output });

                command.ExecuteNonQuery();

                // Dönüş değerleri response objesine atanır
                response.Result = command.Parameters["@$oresult"].Value?.ToString() ?? "";
                response.Id = command.Parameters["@$intID"].Value?.ToString() ?? "";
                response.CreatedAt = DateTime.Now;
            }
            connection.Close();
            connection.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("Müşteri oluşturma hatası: " + ex.Message);
        }

        return response;
    }

    /// <summary>
    /// Aktif müşterileri getirir. sp_get_customers çağrılır.
    /// </summary>
    [HttpGet]
    [Route("GetCustomers")]
    public List<CustomerListResponse> GetCustomers()
    {
        List<CustomerListResponse> result = new List<CustomerListResponse>();
        string commandText = "CALL sp_get_customers();";
        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();

        try
        {
            using (var command = new MySqlCommand(commandText, connection))
            {

                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        result.Add(new CustomerListResponse
                        {
                            Id = reader["id"].ToString(),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Phone = reader["phone"].ToString(),
                            CustomerType = reader["customer_type"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["created_at"].ToString())
                        });
                    }

                connection.Close();
                connection.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Müşteri listesi alınamadı: " + ex.Message);
        }

        return result;
    }

    /// <summary>
    /// Müşterinin aktiflik durumunu değiştirir.
    /// sp_toggle_customer_active_state çağrılır.
    /// </summary>
    [HttpPost]
    [Route("ToggleCustomerState")]
    public ToggleCustomerResponse ToggleCustomerState([FromBody] ToggleCustomerRequest request)
    {
        ToggleCustomerResponse response = new ToggleCustomerResponse();
        string commandText = "CALL sp_toggle_customer_active_state(@$id, @$oresult);";
        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();

        try
        {
            using (var command = new MySqlCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("@$id", request.Id);
                command.Parameters.Add(new MySqlParameter("@$oresult", MySqlDbType.VarChar) { Direction = ParameterDirection.Output });

                command.ExecuteNonQuery();

                response.Result = command.Parameters["@$oresult"].Value?.ToString() ?? "";
            }

            connection.Close();
            connection.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("Aktiflik durumu değiştirilemedi: " + ex.Message);
        }

        return response;
    }
}