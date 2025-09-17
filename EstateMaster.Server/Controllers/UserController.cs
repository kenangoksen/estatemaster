using System.Data;
using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Core.Models;
using EstateMaster.Server.Helper;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Collections.Generic;
using System.Text.Json;

namespace EstateMaster.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IAppSettings appSettings;

        public UserController(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        [HttpPost]
        [Route("AdminCreateUser")]
        public async Task<IActionResult> AdminCreateUser([FromBody] AdminCreateUserRequest request, [FromHeader(Name = "sid")] string sessionId)
        {
            string commandText = "sp_create_user";

            if (string.IsNullOrEmpty(sessionId))
            {
                return Unauthorized(new ErrorResponseUser { Message = "Oturum bilgisi bulunamadı. Admin girişi gerekli.", Code = "AUTH-03" });
            }

            using (var connection = new MySqlConnection(appSettings.Database.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_admin_session_id", sessionId);
                        command.Parameters.AddWithValue("@p_name", request.name);
                        command.Parameters.AddWithValue("@p_surname", request.surname);
                        command.Parameters.AddWithValue("@p_phone", request.phone);
                        command.Parameters.AddWithValue("@p_state", request.state);
                        command.Parameters.AddWithValue("@p_user_type", request.userType);
                        command.Parameters.AddWithValue("@p_username", request.username);
                        command.Parameters.AddWithValue("@p_password", request.password);
                        command.Parameters.AddWithValue("@p_email", request.email);
                        command.Parameters.AddWithValue("@p_description", request.description);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string resultMessage = null;
                                string userIdString = null; // String olarak okuyacağımız değer

                                // result_message kolonunu kontrol et ve al
                                if (reader.GetSchemaTable().Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == "result_message"))
                                {
                                    resultMessage = reader.IsDBNull(reader.GetOrdinal("result_message")) ? null : reader.GetString("result_message");
                                }

                                // user_id kolonunu kontrol et ve al
                                // BURADA DEĞİŞİKLİK YAPIYORUZ
                                if (reader.GetSchemaTable().Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == "user_id"))
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("user_id")))
                                    {
                                        // MySQL Connector/NET, CHAR(36) UUID'leri Guid olarak okuyabilir.
                                        // Eğer Guid olarak okursa, bunu string'e çevirmeliyiz.
                                        // Eğer doğrudan string olarak okuyorsa, GetString() sorunsuz çalışır.
                                        // Her iki durumu da kapsamak için try-catch veya GetFieldType kullanabiliriz.
                                        // En güvenlisi GetValue ile obje alıp tipine bakmaktır.

                                        object rawUserId = reader.GetValue(reader.GetOrdinal("user_id"));

                                        if (rawUserId is Guid guidValue)
                                        {
                                            userIdString = guidValue.ToString();
                                        }
                                        else if (rawUserId is string stringValue)
                                        {
                                            userIdString = stringValue;
                                        }
                                        else if (rawUserId != null)
                                        {
                                            // Beklenmedik bir tip gelirse ToString() ile dönüştür
                                            userIdString = rawUserId.ToString();
                                        }
                                    }
                                }

                                // Önemli Değişiklik: HTTP durum kodunu SADECE user_idString'e göre belirle
                                if (!string.IsNullOrEmpty(userIdString)) // Artık userIdString'i kontrol ediyoruz
                                {
                                    // SP bir userId döndürdüyse, bu bir başarıdır.
                                    return Ok(new SuccessResponseUser { Message = resultMessage ?? "Kullanıcı başarıyla oluşturuldu.", UserId = userIdString });
                                }
                                else
                                {
                                    // userIdString NULL ise, SP tarafından bir hata oluşmuştur.
                                    string specificErrorMessage = resultMessage;
                                    if (string.IsNullOrEmpty(specificErrorMessage) || !specificErrorMessage.StartsWith("Hata:"))
                                    {
                                        specificErrorMessage = "Kullanıcı oluşturulurken bir sorun oluştu veya kullanıcı ID'si dönmedi.";
                                    }
                                    return BadRequest(new ErrorResponseUser { Message = specificErrorMessage, Code = "SP-01" });
                                }
                            }
                            else
                            {
                                return StatusCode(500, new ErrorResponseUser { Message = "Kullanıcı oluşturma işlemi sırasında veritabanından yanıt alınamadı.", Code = "DB-01" });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Loglama yapmak önemlidir: _logger.LogError(ex, "MySQL Hatası AdminCreateUser: {Message}", ex.Message);
                    return StatusCode(500, new ErrorResponseUser { Message = $"Veritabanı hatası: {ex.Message}", Code = ex.SqlState ?? "DB-02" });
                }
                catch (Exception ex)
                {
                    // _logger.LogError(ex, "Beklenmedik Hata AdminCreateUser: {Message}", ex.Message);
                    return StatusCode(500, new ErrorResponseUser { Message = $"Sunucu hatası: {ex.Message}", Code = "SERVER-01" });
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }
        }

        [HttpPost]
        [Route("CreateUserSelf")] // Route doğru
        public async Task<IActionResult> CreateUserSelf([FromBody] CreateUserSelfRequest request) // IActionResult dönüyoruz
        {
            string commandText = "sp_create_user_self";

            // CompanyCode kontrolü - C# tarafında ilk validasyon
            if (string.IsNullOrEmpty(request.CompanyCode))
            {
                return BadRequest(new ErrorResponseUser { Message = "Şirket kodu boş olamaz.", Code = "VALIDATION-01" });
            }

            // Diğer temel validasyonları da buraya ekleyebiliriz (örneğin email formatı, şifre karmaşıklığı)
            if (string.IsNullOrEmpty(request.username) || request.username.Length < 4)
            {
                return BadRequest(new ErrorResponseUser { Message = "Kullanıcı adı en az 4 karakter olmalıdır.", Code = "VALIDATION-02" });
            }
            if (string.IsNullOrEmpty(request.email) || !System.Text.RegularExpressions.Regex.IsMatch(request.email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                return BadRequest(new ErrorResponseUser { Message = "Lütfen geçerli bir e-posta adresi giriniz.", Code = "VALIDATION-03" });
            }
            if (string.IsNullOrEmpty(request.password) || request.password.Length < 6)
            {
                return BadRequest(new ErrorResponseUser { Message = "Şifre en az 6 karakter olmalıdır.", Code = "VALIDATION-04" });
            }


            using (var connection = new MySqlConnection(appSettings.Database.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        // SP parametre isimlerinin @p_ ile başladığını varsayıyorum
                        command.Parameters.AddWithValue("@p_name", request.name);
                        command.Parameters.AddWithValue("@p_surname", request.surname);
                        command.Parameters.AddWithValue("@p_phone", request.phone);
                        command.Parameters.AddWithValue("@p_state", request.state); // request.state varsayılan olarak "Aktif" gelecek
                        command.Parameters.AddWithValue("@p_user_type", request.userType); // request.userType varsayılan olarak "USER" gelecek
                        command.Parameters.AddWithValue("@p_username", request.username);
                        command.Parameters.AddWithValue("@p_password", request.password); // Şifre hash'leme SP'de yapılıyor
                        command.Parameters.AddWithValue("@p_email", request.email);
                        command.Parameters.AddWithValue("@p_description", request.description);
                        command.Parameters.AddWithValue("@p_company_code", request.CompanyCode);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string resultMessage = null;
                                string userIdString = null;

                                // result_message kolonunun varlığını kontrol et ve al
                                if (reader.GetSchemaTable().Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == "result_message"))
                                {
                                    resultMessage = reader.IsDBNull(reader.GetOrdinal("result_message")) ? null : reader.GetString("result_message");
                                }

                                // user_id kolonunun varlığını kontrol et ve al
                                if (reader.GetSchemaTable().Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == "user_id"))
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("user_id")))
                                    {
                                        object rawUserId = reader.GetValue(reader.GetOrdinal("user_id"));
                                        if (rawUserId is Guid guidValue)
                                        {
                                            userIdString = guidValue.ToString();
                                        }
                                        else if (rawUserId is string stringValue)
                                        {
                                            userIdString = stringValue;
                                        }
                                        else if (rawUserId != null)
                                        {
                                            userIdString = rawUserId.ToString();
                                        }
                                    }
                                }

                                // Mantık: Eğer userIdString döndüyse başarılıdır, aksi halde hata.
                                if (!string.IsNullOrEmpty(userIdString))
                                {
                                    return Ok(new SuccessResponseUser { Message = resultMessage ?? "Hesabınız başarıyla oluşturuldu.", UserId = userIdString });
                                }
                                else
                                {
                                    // Eğer userIdString dönmediyse, SP bir hata bildirmiş demektir.
                                    string specificErrorMessage = resultMessage;
                                    if (string.IsNullOrEmpty(specificErrorMessage) || !specificErrorMessage.StartsWith("Hata:"))
                                    {
                                        specificErrorMessage = "Hesabınız oluşturulurken bir sorun oluştu veya kullanıcı ID'si dönmedi.";
                                    }
                                    return BadRequest(new ErrorResponseUser { Message = specificErrorMessage, Code = "SP-01" });
                                }
                            }
                            else
                            {
                                // SP'den yanıt dönmemesi beklenmedik bir durumdur.
                                return StatusCode(500, new ErrorResponseUser { Message = "Hesap oluşturma işlemi sırasında veritabanından yanıt alınamadı.", Code = "DB-01" });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // _logger.LogError(ex, "MySQL Hatası CreateUserSelf: {Message}", ex.Message);
                    return StatusCode(500, new ErrorResponseUser { Message = $"Veritabanı hatası: {ex.Message}", Code = ex.SqlState ?? "DB-02" });
                }
                catch (Exception ex)
                {
                    // _logger.LogError(ex, "Beklenmedik Hata CreateUserSelf: {Message}", ex.Message);
                    return StatusCode(500, new ErrorResponseUser { Message = $"Sunucu hatası: {ex.Message}", Code = "SERVER-01" });
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers([FromHeader(Name = "sid")] string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                return Unauthorized("Oturum bilgisi bulunamadı.");
            }

            var users = new List<object>();
            using var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            await connection.OpenAsync();

            try
            {
                using var command = new MySqlCommand("sp_get_users", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_session_id", sessionId);

                using var reader = await command.ExecuteReaderAsync();

                // SP'nin ilk sonucu hata mesajı mı, yoksa veri mi kontrol et
                if (await reader.ReadAsync())
                {
                    // Eğer "error_message" kolonu varsa, bu bir hata yanıtıdır.
                    if (reader.GetSchemaTable().Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == "error_message"))
                    {
                        var errorMessage = reader["error_message"]?.ToString();
                        return BadRequest(errorMessage);
                    }
                    else
                    {
                        // İlk satır bir hata mesajı değil, muhtemelen ilk kullanıcı kaydı.
                        // Okunan ilk kullanıcı kaydını ekle ve döngüye devam et.
                        do
                        {
                            users.Add(new
                            {
                                id = reader["id"]?.ToString(),
                                created_at = reader.IsDBNull("created_at") ? (DateTime?)null : reader.GetDateTime("created_at"),
                                updated_at = reader.IsDBNull("updated_at") ? (DateTime?)null : reader.GetDateTime("updated_at"),
                                created_by = reader.IsDBNull("created_by") ? null : reader["created_by"]?.ToString(),
                                name = reader["name"]?.ToString(),
                                surname = reader["surname"]?.ToString(),
                                phone = reader.IsDBNull("phone") ? null : reader["phone"]?.ToString(),
                                state = reader["state"]?.ToString(),
                                userType = reader["userType"]?.ToString(),
                                username = reader["username"]?.ToString(),
                                email = reader["email"]?.ToString(),
                                description = reader.IsDBNull("description") ? null : reader["description"]?.ToString(),
                                company_id = reader["company_id"]?.ToString()
                            });
                        } while (await reader.ReadAsync());
                    }
                }
                // Eğer reader.ReadAsync() ilk başta false döndüyse (hiç kayıt yoksa ve error_message de dönmediyse),
                // users listesi boş kalır ve boş bir 200 OK yanıtı döner.
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}");
                return StatusCode(500, $"Veritabanı hatası oluştu: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return StatusCode(500, $"Beklenmedik bir hata oluştu: {ex.Message}");
            }

            return Ok(users);
        }
        [HttpPost("GetUserById")]
        public async Task<string> GetUserById([FromBody] UsersRequestID request, [FromHeader(Name = "sid")] string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                return "Hata: Oturum bilgisi bulunamadı. Admin girişi gerekli.";
            }
            if (string.IsNullOrEmpty(request.id))
            {
                return "Hata: Kullanıcı ID'si eksik.";
            }

            string commandText = "sp_get_user_by_id";
            object user = null;

            using var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            await connection.OpenAsync();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_admin_session_id", sessionId);
                command.Parameters.AddWithValue("@p_user_id", request.id); // Request objesinden ID al

                using var reader = await command.ExecuteReaderAsync();
                if (reader.HasRows && await reader.ReadAsync())
                {
                    user = new
                    {
                        id = reader["id"].ToString(),
                        company_id = reader["company_id"].ToString(),
                        name = reader["name"].ToString(),
                        surname = reader["surname"].ToString(),
                        phone = reader["phone"]?.ToString(),
                        state = reader["state"].ToString(),
                        userType = reader["userType"].ToString(),
                        username = reader["username"].ToString(),
                        email = reader["email"].ToString(),
                        description = reader["description"]?.ToString(),
                        created_at = ((DateTime)reader["created_at"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        updated_at = reader["updated_at"] is DBNull ? (string)null : ((DateTime)reader["updated_at"]).ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
                else
                {
                    // Stored Procedure bir sonuç döndürmediyse (hata mesajı gibi)
                    if (await reader.NextResultAsync() && await reader.ReadAsync())
                    {
                        return reader["result_message"]?.ToString();
                    }
                    return "Hata: Kullanıcı bulunamadı veya yetkiniz yok.";
                }
            }
            catch (MySqlException ex)
            {
                return "Veritabanı Hatası: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Beklenmedik Hata: " + ex.Message;
            }

            if (user == null)
            {
                return "Hata: Kullanıcı bulunamadı.";
            }

            return JsonSerializer.Serialize(user);
        }

        // UpdateUser metodu POST olarak güncellendi
        [HttpPost("UpdateUser")]
        public async Task<string> UpdateUser([FromBody] UpdateUserRequest request, [FromHeader(Name = "sid")] string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                return "Hata: Oturum bilgisi bulunamadı. Admin girişi gerekli.";
            }
            if (string.IsNullOrEmpty(request.id))
            {
                return "Hata: Güncellenecek kullanıcı ID'si eksik.";
            }

            string commandText = "sp_update_user";
            string result = "";
            using var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            await connection.OpenAsync();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_admin_session_id", sessionId);
                command.Parameters.AddWithValue("@p_user_id", request.id);
                command.Parameters.AddWithValue("@p_name", request.name);
                command.Parameters.AddWithValue("@p_surname", request.surname);
                command.Parameters.AddWithValue("@p_phone", request.phone);
                command.Parameters.AddWithValue("@p_state", request.state);
                command.Parameters.AddWithValue("@p_user_type", request.userType);
                command.Parameters.AddWithValue("@p_email", request.email);
                command.Parameters.AddWithValue("@p_description", request.description);

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    result = reader["result_message"]?.ToString();
                }
                else
                {
                    result = "Kullanıcı güncelleme işlemi başarısız: Veritabanından yanıt alınamadı.";
                }
            }
            catch (MySqlException ex)
            {
                result = "Veritabanı Hatası: " + ex.Message;
            }
            catch (Exception ex)
            {
                result = "Beklenmedik Hata: " + ex.Message;
            }

            return result;
        }

        // DeleteUser metodu da POST olarak güncellendi
        [HttpPost("DeleteUser")]
        public async Task<string> DeleteUser([FromBody] DeleteUserRequest request, [FromHeader(Name = "sid")] string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                return "Hata: Oturum bilgisi bulunamadı. Admin girişi gerekli.";
            }
            if (string.IsNullOrEmpty(request.id))
            {
                return "Hata: Silinecek kullanıcı ID'si eksik.";
            }

            string commandText = "sp_delete_user";
            string result = "";
            using var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            await connection.OpenAsync();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_admin_session_id", sessionId);
                command.Parameters.AddWithValue("@p_user_id", request.id);

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    result = reader["result_message"]?.ToString();
                }
                else
                {
                    result = "Kullanıcı silme işlemi başarısız: Veritabanından yanıt alınamadı.";
                }
            }
            catch (MySqlException ex)
            {
                result = "Veritabanı Hatası: " + ex.Message;
            }
            catch (Exception ex)
            {
                result = "Beklenmedik Hata: " + ex.Message;
            }

            return result;
        }
    }
}