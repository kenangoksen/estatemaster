using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Core.Models;
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
    public LoginSessionResponse AuthUser([FromBody] LoginRequest request)
    {
        LoginSessionResponse user = new LoginSessionResponse();
        string CommandText = @"CALL sp_get_auth_user(@$username, @$password);";
        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        connection.Open();
        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {
                command.Parameters.AddWithValue("@$username", request.username);
                command.Parameters.AddWithValue("@$password", request.password);
                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        user = new LoginSessionResponse()
                        {
                            id = reader["id"].ToString(),
                            created_at = Convert.ToDateTime(reader["created_at"].ToString()),
                            updated_at = Convert.ToDateTime(reader["updated_at"].ToString()),
                            created_by = reader["created_by"].ToString(),
                            name = reader["name"].ToString(),
                            surname = reader["surname"].ToString(),
                            phone = reader["phone"].ToString(),
                            state = reader["state"].ToString(),
                            userType = reader["userType"].ToString(),
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(),
                            login_date = Convert.ToDateTime(reader["login_date"].ToString()),
                            session_id = reader["session_id"].ToString()
                        };
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
        return user;
    }
}
