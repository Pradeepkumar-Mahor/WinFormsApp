using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using LiteDB;
using System.Drawing;

namespace DbAccess
{
    public class SqlLiteDataAccess : IDatabaseHandler
    {
        private string TestConnectionString = "Data Source=sample.db";
        private string ConnectionString;

        public SqlLiteDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            SQLiteConnection sqlConnection = (SQLiteConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new SQLiteCommand
            {
                CommandText = commandText,
                Connection = (SQLiteConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new SQLiteDataAdapter((SQLiteCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            SQLiteCommand SQLcommand = (SQLiteCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}