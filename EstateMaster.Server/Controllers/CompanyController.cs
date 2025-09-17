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
[Route("api/company")]
public class CompanyController : ControllerBase
{
    private IAppSettings appSettings { get; set; }

    public CompanyController(IAppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    [HttpPost]
    [Route("CreateCompany")]
    public async Task<string> RegisterCompany([FromBody] CompanyRegisterRequest request)
    {
        string result = "";
        string CommandText = "sp_create_company"; // Stored procedure'ün adı

        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        await connection.OpenAsync();

        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {
                // Komut türünü stored procedure olarak belirtiyoruz.
                // Bu, parametrelerin isme göre eşleşmesini sağlar.
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Parametreleri stored procedure'deki adlarıyla tam olarak eşleştirerek ekliyoruz
                command.Parameters.AddWithValue("@p_company_name", request.CompanyName);
                command.Parameters.AddWithValue("@p_company_email", request.CompanyEmail);
                command.Parameters.AddWithValue("@p_user_name", request.UserName);
                command.Parameters.AddWithValue("@p_user_surname", request.UserSurname);
                command.Parameters.AddWithValue("@p_user_username", request.UserUsername);
                command.Parameters.AddWithValue("@p_user_password", request.UserPassword);
                command.Parameters.AddWithValue("@p_user_email", request.UserEmail);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    do
                    {
                        while (await reader.ReadAsync())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.GetSchemaTable().Rows.Cast<System.Data.DataRow>().Any(row => row["ColumnName"].ToString() == "company_id"))
                                {
                                    result = "Kayıt işlemi başarılı.";
                                    break;
                                }
                            }
                        }
                    } while (await reader.NextResultAsync());
                }
            }
        }
        catch (MySqlException ex)
        {
            return "Hata: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "Hata: " + ex.Message;
        }
        finally
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
        }

        return result ?? string.Empty;
    }
}