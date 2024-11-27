using System;
using Npgsql;
using System.Data;

namespace DbAccess
{
    public class PostgreSQLDataAccess : IDatabaseHandler
    {
        private string TestConnectionString = "Host=localhost;Username=your_username;Password=your_password;Database=your_database";

        private readonly string ConnectionString;

        public PostgreSQLDataAccess(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            return connection;
        }

        public void CloseConnection(IDbConnection connection)
        {
            NpgsqlConnection NpgsqlConnection = (NpgsqlConnection)connection;
            NpgsqlConnection.Close();
            NpgsqlConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new NpgsqlCommand
            {
                CommandText = commandText,
                Connection = (NpgsqlConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new NpgsqlDataAdapter((NpgsqlCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            NpgsqlCommand Npgsqlcommand = (NpgsqlCommand)command;
            return Npgsqlcommand.CreateParameter();
        }
    }
}