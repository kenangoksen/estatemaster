namespace EstateMaster.Server.Adaptor.Helpers;
using System;
using System.Globalization;
using MySqlConnector;

// custom exception class for throwing application specific exceptions (e.g. for validation) 
// that can be caught and handled within the application
public class AppException : Exception
{
    public MySqlConnection connection { get; set; }
    public string message { get; set; }
    public AppException() : base() { }

    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }

    public AppException(MySqlConnection connection, string message)
    {
        this.connection = connection;
        this.message = message;
        string result = "";
        if (message.Contains("DB_EXCEPTION"))
        {
            string globalExceptionCommand = @"SELECT @'global_exception' as a , @'global_exception_code' as b";
            using (MySqlCommand command = new MySqlCommand(globalExceptionCommand, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                    if (reader.Read())
                    {
                        result = reader["a"].ToString() + " (" + reader["b"].ToString() + ")";
                    }
            }
            connection.Close();
            connection.Dispose();
        }
        if(result == String.Empty && message != String.Empty){
            result = "System Error: " + message;
        }
        throw new AppException(result);
    } 
}