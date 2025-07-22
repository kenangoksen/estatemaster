using System.Net.Sockets;
using EstateMaster.Server.Adaptor.Helpers;
using EstateMaster.Server.Helper;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace EstateMaster.Server.Controllers
{
    [ApiController]
    [Route("api/property")]
    public class PropertyController : ControllerBase
    {
        private IAppSettings appSettings { get; set; }

        public PropertyController(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        [HttpPost]
        [Route("SaveProperty")]
        public string SaveProperty([FromBody] SavePropertyRequest request)
        {
            string result = string.Empty;
            string CommandText = @"CALL sp_create_property( @$created_at, @$updated_at, @$created_by, @$property_type, @$user_id, @$title, 
                                              @$description, @$price, @$province, @$district, @$square_meters_net, @$neighborhood, @$estate_status_type)";
            var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            connection.Open();

            try
            {
                using (var command = new MySqlCommand(CommandText, connection))
                {
                    // Parametreler
                    command.Parameters.AddWithValue("@$created_at", request.created_at);
                    command.Parameters.AddWithValue("@$updated_at", request.updated_at);
                    command.Parameters.AddWithValue("@$created_by", request.created_by);
                    command.Parameters.AddWithValue("@$property_type", request.property_type);
                    command.Parameters.AddWithValue("@$user_id", request.user_id);
                    command.Parameters.AddWithValue("@$title", request.title);
                    command.Parameters.AddWithValue("@$description", request.description);
                    command.Parameters.AddWithValue("@$price", request.price);
                    command.Parameters.AddWithValue("@$province", request.province);
                    command.Parameters.AddWithValue("@$district", request.district);
                    command.Parameters.AddWithValue("@$square_meters_net", request.square_meters_net);
                    command.Parameters.AddWithValue("@$neighborhood", request.neighborhood);
                    command.Parameters.AddWithValue("@$estate_status_type", request.estate_status_type);

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
        [Route("GetProperties")]
        public List<PropertiesResponse> GetPropertyList()
        {
            List<PropertiesResponse> data = new List<PropertiesResponse>();
            string CommandText = @"CALL sp_get_properties;";
            var connection = new MySqlConnection(appSettings.Database.ConnectionString);
            connection.Open();

            try
            {
                using (var command = new MySqlCommand(CommandText, connection))
                {
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            data.Add(new PropertiesResponse()
                            {
                                id = reader["id"]?.ToString() ?? string.Empty,
                                created_at = Convert.ToDateTime(reader["created_at"].ToString()),
                                updated_at = Convert.ToDateTime(reader["updated_at"].ToString()),
                                created_by = reader["created_by"]?.ToString() ?? string.Empty,
                                property_type = reader["property_type"]?.ToString() ?? string.Empty,
                                user_id = reader["user_id"]?.ToString() ?? string.Empty,
                                title = reader["title"]?.ToString() ?? string.Empty,
                                description = reader["description"]?.ToString() ?? string.Empty,
                                price = Convert.ToDouble(reader["price"]),
                                province = reader["province"]?.ToString() ?? string.Empty,
                                district = reader["district"]?.ToString() ?? string.Empty,
                                square_meters_net = Convert.ToDouble(reader["square_meters_net"]),
                                neighborhood = reader["neighborhood"]?.ToString() ?? string.Empty,
                                estate_status_type = reader["estate_status_type"]?.ToString() ?? string.Empty
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
