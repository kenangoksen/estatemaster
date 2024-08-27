using EstateMaster.Server.Adaptor.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Connections
{

    [Serializable]
    public class MySQLConnection : IDBConnection
    {

        private string lastSQL { get; set; }
        private string _connectionString { get; set; }
        private MySqlConnection _openConnection { get; set; }
        private MySqlTransaction _transaction { get; set; }

        public MySQLConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public long Insert(string sql, Dictionary<string, dynamic> arguments = null)
        {
            lastSQL = sql;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = GetCommandInstance(sql, connection);
            command.CommandTimeout = int.MaxValue;

            if (arguments == null)
            {
                arguments = new Dictionary<string, dynamic>();
            }

            foreach (KeyValuePair<string, dynamic> pair in arguments)
            {
                command.Parameters.AddWithValue(pair.Key, pair.Value);
            }

            command.ExecuteNonQuery();
            long insertId = command.LastInsertedId;

            CloseActiveConnection(connection);

            return insertId;
        }

        public void Execute(string sql, Dictionary<string, dynamic> arguments = null)
        {
            lastSQL = sql;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = GetCommandInstance(sql, connection);
            command.CommandTimeout = int.MaxValue;

            if (arguments == null)
            {
                arguments = new Dictionary<string, dynamic>();
            }

            foreach (KeyValuePair<string, dynamic> pair in arguments)
            {
                command.Parameters.AddWithValue(pair.Key, pair.Value);
            }

            command.ExecuteNonQuery();

            CloseActiveConnection(connection);
        }

        public void ExecuteSP(string sql)
        {
            lastSQL = sql;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = GetCommandInstance(sql, connection);
            command.CommandTimeout = int.MaxValue;
            using (command)
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                using (MySqlDataReader rd = command.ExecuteReader())
                    while (rd.Read())
                    {

                    }
                command.Connection.Close();
                command.Connection.Dispose();
            }
            CloseActiveConnection(connection);
        }

        public List<Dictionary<string, dynamic>> Query(string sql, Dictionary<string, dynamic> arguments = null)
        {
            lastSQL = sql;
            MySqlConnection connection = GetConnection();
            MySqlCommand query = GetCommandInstance(sql, connection);
            query.CommandTimeout = int.MaxValue;

            if (arguments == null)
            {
                arguments = new Dictionary<string, dynamic>();
            }

            foreach (KeyValuePair<string, dynamic> pair in arguments)
            {
                query.Parameters.AddWithValue(pair.Key, pair.Value);
            }

            // Veriler alınır ve bağlantı kapatılır
            List<Dictionary<string, dynamic>> data = ReadSafely(query);

            CloseActiveConnection(connection);

            return data;
        }

        private Dictionary<string, dynamic> ToRow(MySqlDataReader reader)
        {
            Dictionary<string, dynamic> row = new Dictionary<string, dynamic>();
            for (int index = 0; index < reader.FieldCount; index++)
            {
                if (reader[index] is DBNull)
                {
                    row[reader.GetName(index)] = null;
                }
                else
                {
                    row[reader.GetName(index)] = reader[index];
                }
            }
            return row;
        }

        private List<Dictionary<string, dynamic>> ToList(MySqlDataReader reader)
        {
            List<Dictionary<string, dynamic>> items = new List<Dictionary<string, dynamic>>();
            while (reader.Read())
            {
                items.Add(ToRow(reader));
            }
            return items;
        }

        private List<Dictionary<string, dynamic>> ReadSafely(MySqlCommand query)
        {
            MySqlDataReader reader = query.ExecuteReader();
            try
            {
                List<Dictionary<string, dynamic>> data = ToList(reader);
                reader.Close();
                return data;
            }
            catch (Exception exception)
            {
                reader.Close();
                throw new Exception(exception.Message, exception);
            }
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                if (_openConnection == null)
                {
                    MySqlConnection connection = new MySqlConnection(_connectionString);
                    connection.Open();
                    return connection;
                }
                return _openConnection;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void BeginTransaction()
        {
            try
            {
                _openConnection = new MySqlConnection(_connectionString);
                _openConnection.Open();
                _transaction = _openConnection.BeginTransaction();
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public void CloseTransaction()
        {
            if (_openConnection != null)
            {
                _openConnection.Dispose();
            }
        }

        public void Commit()
        {
            if (_openConnection != null)
            {
                _transaction.Commit();
                _transaction = _openConnection.BeginTransaction();
            }
        }

        public void Rollback()
        {
            if (_openConnection != null)
            {
                _transaction.Rollback();
                _transaction = _openConnection.BeginTransaction();
            }
        }

        public string GetLastSQL()
        {
            return lastSQL;
        }

        public void ExecuteScript(string content)
        {
            Execute(content);
        }

        private MySqlCommand GetCommandInstance(string sql, MySqlConnection connection)
        {
            if (_transaction == null)
            {
                return new MySqlCommand(sql, connection);
            }

            return new MySqlCommand(sql, connection, _transaction);
        }

        private void CloseActiveConnection(MySqlConnection connection)
        {
            if (_openConnection != null)
            {
                return;
            }

            if (connection == null)
            {
                return;
            }

            connection.Dispose();
        }

        public void DisposeAll()
        {
            if (_openConnection != null)
            {
                _openConnection.Dispose();
            }
        }

    }

}
