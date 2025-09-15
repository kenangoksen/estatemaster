using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Core.Models;
using EstateMaster.Server.Helper;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;

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
        string CommandText = "sp_get_auth_user";
        var connection = new MySqlConnection(appSettings.Database.ConnectionString);
        await connection.OpenAsync();
        try
        {
            using (var command = new MySqlCommand(CommandText, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_username", request.username);
                command.Parameters.AddWithValue("@p_password", request.password);

                using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    // Stored procedure'dan dönen ilk sonucu kontrol et
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();
                        // Hata mesajı mı geldiğini kontrol et
                        if (reader.GetSchemaTable().Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == "error_message"))
                        {
                            user.Error = reader["error_message"].ToString();
                            user.IsAuthenticated = false;
                        }
                        else
                        {
                            // Başarılı giriş
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
                                password = reader["password"].ToString(),
                                login_date = ConvertHelper.ToDateTime(reader["login_date"].ToString()),
                                session_id = reader["session_id"].ToString(),
                                company_id = reader["company_id"].ToString(),
                                IsAuthenticated = true // Oturum başarılı
                            };
                        }
                    }
                    else
                    {
                        // Stored procedure'dan bir hata mesajı gelmediyse bile, başarısız bir durum
                        user.Error = "Kullanıcı adı veya şifre hatalı.";
                        user.IsAuthenticated = false;
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            user.Error = "Veritabanı hatası: " + ex.Message;
            user.IsAuthenticated = false;
        }
        catch (Exception ex)
        {
            user.Error = "Beklenmedik bir hata oluştu: " + ex.Message;
            user.IsAuthenticated = false;
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
            connection.Dispose();
        }

        return user;
    }
}