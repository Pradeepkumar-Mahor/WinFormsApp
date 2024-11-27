using System.Data.SQLite;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace DbAccess
{
    public class SqlLiteDataAccess : IDatabaseHandler
    {
        private string TestConnectionString = "Data Source=sample.db";
        private string ConnectionString { get; set; }

        public SqlLiteDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(ConnectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            SqliteConnection sqlConnection = (SqliteConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new SqliteCommand
            {
                CommandText = commandText,
                Connection = (SqliteConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            SqlLiteDataAccess dataAdapter = new SqlLiteDataAccess(ConnectionString);

            DataSet dataSet = new DataSet();
            dataAdapter.CreateAdapter(command);

            return (IDataAdapter)dataAdapter;
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            SqliteCommand SQLcommand = (SqliteCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}