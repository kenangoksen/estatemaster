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
    public string CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        string result = string.Empty;
        string CommandText = @"CALL sp_create_customer(
        @$created_by, @$customer_type, @$assigned_user_id, @$first_name, @$last_name,
        @$email, @$phone, @$birth_date, @$gender, @$budget_min, @$budget_max,
        @$preferred_province, @$preferred_district, @$preferred_neighborhood,
        @$preferred_square_meters, @$preferred_room_count, @$amenities,
        @$facade, @$source, @$last_interaction, @$notes);";

        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();
        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {            // Giriş Parametreleri
                command.Parameters.AddWithValue("@$created_by", request.created_by ?? "");
                command.Parameters.AddWithValue("@$customer_type", request.CustomerType ?? "");
                command.Parameters.AddWithValue("@$assigned_user_id", request.AssignedUserId ?? "");
                command.Parameters.AddWithValue("@$first_name", request.FirstName ?? "");
                command.Parameters.AddWithValue("@$last_name", request.LastName ?? "");
                command.Parameters.AddWithValue("@$email", request.Email ?? "");
                command.Parameters.AddWithValue("@$phone", request.Phone ?? "");
                command.Parameters.AddWithValue("@$birth_date", request.BirthDate);
                command.Parameters.AddWithValue("@$gender", request.Gender ?? "");
                command.Parameters.AddWithValue("@$budget_min", request.BudgetMin ?? 0);
                command.Parameters.AddWithValue("@$budget_max", request.BudgetMax ?? 0);
                command.Parameters.AddWithValue("@$preferred_province", request.PreferredProvince ?? "");
                command.Parameters.AddWithValue("@$preferred_district", request.PreferredDistrict ?? "");
                command.Parameters.AddWithValue("@$preferred_neighborhood", request.PreferredNeighborhood ?? "");
                command.Parameters.AddWithValue("@$preferred_square_meters", request.PreferredSquareMeters ?? 0);
                command.Parameters.AddWithValue("@$preferred_room_count", request.PreferredRoomCount ?? "");
                command.Parameters.AddWithValue("@$amenities", request.Amenities ?? "");
                command.Parameters.AddWithValue("@$facade", request.Facade ?? "");
                command.Parameters.AddWithValue("@$source", request.Source ?? "");
                command.Parameters.AddWithValue("@$last_interaction", request.LastInteraction);
                command.Parameters.AddWithValue("@$notes", request.Notes ?? "");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader["oresult"]?.ToString() ?? string.Empty;
                    }
                }

                if (command.Connection != null)
                {
                    command.Connection.Close();
                }

                command.Connection.Dispose();

            }
        }
        catch (MySqlException ex)
        {
            throw new AppException(connection, ex.ToString());
        }
        catch (SocketException ex)
        {
            throw new Exception("SocketException : " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception : " + ex.Message);
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }

        return result ?? string.Empty;
    }

    [HttpPost]
    [Route("GetCustomerById")]
    public CustomerResponse GetCustomer([FromBody] GetCustomerById request)
    {
        CustomerResponse data = new CustomerResponse();
        string CommandText = @"CALL sp_get_customer_by_id(@$id);";
        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();
        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {
                command.Parameters.AddWithValue("@$id", request.id);
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        data.id = reader["id"].ToString();
                        data.created_at = ConvertHelper.ToDateTime(reader["created_at"].ToString());
                        data.updated_at = reader["updated_at"] != DBNull.Value
                        ? Convert.ToDateTime(reader["updated_at"])
                        : (DateTime?)null;
                        data.created_by = reader["created_by"].ToString();
                        data.customer_type = reader["customer_type"].ToString();
                        data.assigned_user_id = reader["assigned_user_id"].ToString();
                        data.first_name = reader["first_name"].ToString();
                        data.last_name = reader["last_name"].ToString();
                        data.email = reader["email"].ToString();
                        data.phone = reader["phone"].ToString();
                        data.birth_date = ConvertHelper.ToDateTime(reader["birth_date"].ToString());
                        data.gender = reader["gender"].ToString();
                        data.budget_min = reader["budget_min"].ToString();
                        data.budget_max = reader["budget_max"].ToString();
                        data.preferred_province = reader["preferred_province"].ToString();
                        data.preferred_district = reader["preferred_district"].ToString();
                        data.preferred_neighborhood = reader["preferred_neighborhood"].ToString();
                        data.preferred_square_meters = reader["preferred_square_meters"].ToString();
                        data.preferred_room_count = reader["preferred_room_count"].ToString();
                        data.amenities = reader["amenities"].ToString();
                        data.facade = reader["facade"].ToString();
                        data.source = reader["source"].ToString();
                        data.last_interaction = reader["last_interaction"] != DBNull.Value
                        ? ConvertHelper.ToDateTime(reader["last_interaction"].ToString())
                        : (DateTime?)null;
                        data.notes = reader["notes"].ToString();
                    }
                connection.Close();
                connection.Dispose();
            }
        }
        catch (MySqlException ex)
        {
            throw new AppException(connection, ex.ToString());
        }
        catch (SocketException ex)
        {
            throw new Exception("SocketException : " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception : " + ex.Message);
        }
        return data;
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

    [HttpPost]
    [Route("UpdateCustomer")]
    public string UpdateCustomer([FromBody] UpdateCustomerRequest request)
    {
        string result = "";
        string CommandText = @"CALL sp_update_customer(
        @$id, @$customer_type, @$assigned_user_id, @$first_name, @$last_name,
        @$email, @$phone, @$birth_date, @$gender, @$budget_min, @$budget_max,
        @$preferred_province, @$preferred_district, @$preferred_neighborhood,
        @$preferred_square_meters, @$preferred_room_count, @$amenities,
        @$facade, @$source, @$last_interaction, @$notes, @$updated_by, @$updated_at);";

        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();
        try
        {
            using (MySqlCommand command = new MySqlCommand(CommandText, connection))
            {
                // Parametreleri eşleştir
                command.Parameters.AddWithValue("@$id", request.id);
                command.Parameters.AddWithValue("@$customer_type", request.customer_type);
                command.Parameters.AddWithValue("@$assigned_user_id", request.assigned_user_id);
                command.Parameters.AddWithValue("@$first_name", request.first_name);
                command.Parameters.AddWithValue("@$last_name", request.last_name);
                command.Parameters.AddWithValue("@$email", request.email);
                command.Parameters.AddWithValue("@$phone", request.phone);
                command.Parameters.AddWithValue("@$birth_date", request.BirthDate);
                command.Parameters.AddWithValue("@$gender", request.gender);
                command.Parameters.AddWithValue("@$budget_min", request.budget_min);
                command.Parameters.AddWithValue("@$budget_max", request.budget_max);
                command.Parameters.AddWithValue("@$preferred_province", request.preferred_province);
                command.Parameters.AddWithValue("@$preferred_district", request.preferred_district);
                command.Parameters.AddWithValue("@$preferred_neighborhood", request.preferred_neighborhood);
                command.Parameters.AddWithValue("@$preferred_square_meters", request.preferred_square_meters);
                command.Parameters.AddWithValue("@$preferred_room_count", request.preferred_room_count);
                command.Parameters.AddWithValue("@$amenities", request.amenities);
                command.Parameters.AddWithValue("@$facade", request.facade);
                command.Parameters.AddWithValue("@$source", request.source);
                command.Parameters.AddWithValue("@$last_interaction", request.last_interaction);
                command.Parameters.AddWithValue("@$notes", request.notes);
                command.Parameters.AddWithValue("@$updated_by", request.updated_by);
                command.Parameters.AddWithValue("@$updated_at", request.updated_at);

                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        result = reader["oresult"].ToString();
                    }

                command.Connection.Clone();
                command.Connection.Dispose();
            }
        }
        catch (MySqlException ex)
        {
            throw new AppException(connection, ex.ToString());
        }
        catch (SocketException ex)
        {
            throw new Exception("SocketException : " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception : " + ex.Message);
        }

        return result;
    }
}