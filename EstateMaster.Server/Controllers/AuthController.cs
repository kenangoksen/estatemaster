using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Core.Models;
using EstateMaster.Server.Helper;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private IAppSettings appSettings { get; set; }

    public AuthController(IAppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    [HttpPost]
    [Route("AuthUser")]
    public async Task<LoginSessionResponse> AuthUser([FromBody] LoginRequest request)
    {
        LoginSessionResponse user = new LoginSessionResponse();
        string CommandText = "sp_get_auth_user"; // Sadece SP adı yeterli
        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        await connection.OpenAsync();
        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure; // SP'yi ismine göre çağırıyoruz

                // Parametreleri isme göre ekliyoruz
                command.Parameters.AddWithValue("@p_username", request.username);
                command.Parameters.AddWithValue("@p_password", request.password); // Düz metin şifreyi gönderiyoruz

                using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        user = new LoginSessionResponse()
                        {
                            id = reader["id"].ToString(),
                            created_at = ConvertHelper.ToDateTime(reader["created_at"].ToString()),
                            updated_at = ConvertHelper.ToDateTime(reader["updated_at"].ToString()),
                            created_by = reader["created_by"].ToString(),
                            name = reader["name"].ToString(),
                            surname = reader["surname"].ToString(),
                            phone = reader["phone"].ToString(),
                            state = reader["state"].ToString(),
                            userType = reader["userType"].ToString(),
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(), // Buradaki şifre hash'lenmiş gelecek
                            login_date = ConvertHelper.ToDateTime(reader["login_date"].ToString()),
                            session_id = reader["session_id"].ToString(),
                            company_id = reader["company_id"].ToString()
                        };
                    }
                }
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
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
        }

        return user;
    }
}