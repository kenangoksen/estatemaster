using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Helper;
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
                                description = reader["description"].ToString(),
                                email = reader["email"].ToString()
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
        [HttpPost]
        [Route("getById")]
        public UsersResponse GetUser([FromBody] UsersRequestID request)
        {
            UsersResponse data = new UsersResponse();
            string CommandText = @"CALL sp_get_user_byID(@$id);";
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
                            data.updated_at = Convert.ToDateTime(reader["updated_at"].ToString());
                            data.created_by = reader["created_by"].ToString();
                            data.name = reader["name"].ToString();
                            data.surname = reader["surname"].ToString();
                            data.phone = reader["phone"].ToString();
                            data.state = reader["state"].ToString();
                            data.userType = reader["userType"].ToString();
                            data.username = reader["username"].ToString();
                            data.password = reader["password"].ToString();
                            data.login_date = Convert.ToDateTime(reader["login_date"].ToString());
                            data.description = reader["description"].ToString();
                            data.email = reader["email"].ToString();
                        };
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

        [HttpPost]
        [Route("UpdateUser")]
        public string UpdateUser([FromBody] UsersRequest request)
        {
            string result = "";
            string CommandText = @"CALL sp_update_user(@$id, @$created_at, @$updated_at, @$created_by, @$name, @$surname, @$phone, @$state, @$userType, @$username, @$password, @$login_date, @$description, @$email)";
            var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            connection.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(CommandText, connection))
                {
                    command.Parameters.AddWithValue("@$id", request.id);
                    command.Parameters.AddWithValue("@$created_at", request.created_at);
                    command.Parameters.AddWithValue("@$updated_at", request.updated_at);
                    command.Parameters.AddWithValue("@$created_by", request.created_by);
                    command.Parameters.AddWithValue("@$name", request.name);
                    command.Parameters.AddWithValue("@$surname", request.surname);
                    command.Parameters.AddWithValue("@$phone", request.phone);
                    command.Parameters.AddWithValue("@$state", request.state);
                    command.Parameters.AddWithValue("@$userType", request.userType);
                    command.Parameters.AddWithValue("@$username", request.username);
                    command.Parameters.AddWithValue("@$password", request.password);
                    command.Parameters.AddWithValue("@$login_date", request.login_date);
                    command.Parameters.AddWithValue("@$description", request.description);
                    command.Parameters.AddWithValue("@$email", request.email);

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

        [HttpPost]
        [Route("CreateUser")]
        public string CreateUser([FromBody] CreateUserRequest request)
        {
            string result = "";
            string CommandText = @"CALL sp_create_user(@$created_at, @$updated_at, @$created_by, @$name, @$surname, @$phone, @$state, @$userType, @$username, @$password, @$login_date, @$description, @$email)";
            var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            connection.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(CommandText, connection))
                {
                    command.Parameters.AddWithValue("@$created_at", request.created_at);
                    command.Parameters.AddWithValue("@$updated_at", request.updated_at);
                    command.Parameters.AddWithValue("@$created_by", request.created_by);
                    command.Parameters.AddWithValue("@$name", request.name);
                    command.Parameters.AddWithValue("@$surname", request.surname);
                    command.Parameters.AddWithValue("@$phone", request.phone);
                    command.Parameters.AddWithValue("@$state", request.state);
                    command.Parameters.AddWithValue("@$userType", request.userType);
                    command.Parameters.AddWithValue("@$username", request.username);
                    command.Parameters.AddWithValue("@$password", request.password);
                    command.Parameters.AddWithValue("@$login_date", request.login_date);
                     command.Parameters.AddWithValue("@$description", request.description);
                    command.Parameters.AddWithValue("@$email", request.email);

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

        [HttpPost]
        [Route("DeleteUser")]

        public void DeleteUser([FromBody] DeleteUserRequest request)
        {
            string CommandText = @"CALL sp_delete_user(@$id);";
            var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            connection.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(CommandText, connection))
                {
                    command.Parameters.AddWithValue("@$id", request.id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            
                        }
                    command.Connection.Close();
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
        }
    }
}
