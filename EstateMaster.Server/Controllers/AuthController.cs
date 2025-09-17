using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Core.Models; // Roles sınıfı için ekledik
using EstateMaster.Server.Helper;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using EstateMaster.Server.Core.Helpers; // SuccessResponse ve ErrorResponse için ekledik

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private IAppSettings appSettings { get; set; }

    public AuthController(IAppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    [HttpPost("AuthUser")]
    public async Task<IActionResult> AuthUser([FromBody] LoginRequest request)
    {
        try
        {
            using (var connection = new MySqlConnection(appSettings.Database.ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand("sp_get_auth_user", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_username", request.username);
                    command.Parameters.AddWithValue("p_password", request.password);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows) // Eğer sonuç seti varsa devam et
                        {
                            // Stored procedure iki farklı sonuç seti döndürebiliyor:
                            // 1. Başarılı login: LoginSessionResponse objesi
                            // 2. Başarısız login: SELECT 'Authentication failed' AS result;
                            
                            // İlk kolonu kontrol ederek hangi tip yanıt geldiğini anlayalım
                            // Bu kısım kritik!
                            await reader.ReadAsync(); // İlk satırı oku
                            if (reader.GetName(0) == "result") // Eğer ilk kolonun adı 'result' ise, bu bir hata mesajıdır
                            {
                                // Kullanıcı adı/şifre hatalı durumunu backend'in sp_doexception'ı zaten logladığı için
                                // burada sadece HTTP 401 Unauthorized dönmeliyiz.
                                // sp_doexception'dan gelen mesajı ErrorResponse olarak frontend'e iletelim.
                                // Stored procedure'dan dönen mesajı doğrudan ErrorResponse içine koyabiliriz.
                                // Ancak sp_doexception bir SELECT dönmüyor, sadece exception tablosuna kaydediyor.
                                // Bu yüzden manuel mesaj atayalım.
                                return Unauthorized(new ErrorResponse { Message = "Kullanıcı adı veya şifre hatalı.", Code = "AUTH-01" });
                            }
                            else
                            {
                                // Eğer 'result' kolonu yoksa, bu başarılı login yanıtıdır.
                                // Reader'ı en başa almamız veya yeniden okumamız gerekebilir eğer ReadAsync() ile ilerlediyse.
                                // Daha güvenli bir yaklaşım: Eğer 'result' değilse, varsayılan olarak kullanıcı datasını okuruz.
                                // Eğer reader.ReadAsync() bir kez çalıştıysa, reader'ı yeniden okumamız gerekebilir.
                                // En güzeli, reader'ı tekrar başa almamız için bir yol bulmak veya ikinci bir kez ReadAsync() yapmak.
                                // Basitçe: İlk okuma başarısız olursa reader ilerlemez, bu durumda yeniden okuruz.
                                // Ancak bu senaryoda, zaten reader.GetName(0) kontrolünü yaptığımız için, reader
                                // zaten doğru konumda. Sadece kolon isimleriyle okuyacağız.

                                var user = new LoginSessionResponse()
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
                                    // Password'ü hiçbir zaman frontend'e göndermemeliyiz.
                                    // Stored procedure'dan da bu kolonu çıkarın.
                                    // Eğer çıkaramıyorsak, en azından burada okumayın.
                                    // password = reader["password"].ToString(), // Burayı KESİNLİKLE YORUM SATIRI YAPIN VEYA SİLİN
                                    email = reader["email"].ToString(),
                                    login_date = ConvertHelper.ToDateTime(reader["login_date"].ToString()),
                                    company_id = reader["company_id"].ToString(),
                                    session_id = reader["session_id"].ToString(), // SP'de v_session_id AS session_id olarak dönüyor
                                };
                                return Ok(new SuccessResponse<LoginSessionResponse> { Data = user, Message = "Giriş Başarılı" });
                            }
                        }
                        else // Hiç sonuç seti dönmediyse (bu durum aslında IFNULL kontrolüyle engelleniyor SP'de)
                        {
                            return Unauthorized(new ErrorResponse { Message = "Kullanıcı adı veya şifre hatalı.", Code = "AUTH-01" });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Hata detaylarını loglayın
            // sp_doexception zaten veritabanına logluyor, burada da konsola veya bir logger'a loglayabiliriz.
            Console.WriteLine($"AuthUser hatası: {ex.Message}");
            // Normalde burada bir logger kullanmalıyız.
            // Örneğin: _logger.LogError(ex, "AuthUser metodunda bir hata oluştu.");
            
            // Veritabanı hatası durumunda genel bir hata mesajı döndürün.
            return StatusCode(500, new ErrorResponse { Message = "Beklenmedik bir hata oluştu.", Code = "GEN-01" });
        }
    }
}