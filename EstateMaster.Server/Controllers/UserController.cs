using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace EstateMaster.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IAppSettings appSettings { get; set; }

        public UserController(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        [HttpPost]
        [Route("GetUsers")]
        public List<UsersResponse> GetUserList()
        {
            List<UsersResponse> data = new List<UsersResponse>();
            string CommandText = @"CALL sp_get_users;";
            var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            connection.Open();
            try
            {
                using (var command = new MySqlCommand(CommandText, connection))
                {

                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            data.Add(new UsersResponse()
                            {
                                id = Convert.ToInt32(reader["id"].ToString()),
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
                            });
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
    }
}
