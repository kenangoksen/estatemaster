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
                                              @$description, @$price, @$province, @$district, @$square_meters_net, @$neighborhood, @$estatae_status_type)";
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
                    command.Parameters.AddWithValue("@$estatae_status_type", request.estatae_status_type);

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
    }
}
