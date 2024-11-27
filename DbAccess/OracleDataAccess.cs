using LiteDB;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Net.Http.Headers;

namespace DbAccess
{
    public class OracleDataAccess : IDatabaseHandler
    {
        private string TestConnectionString = "User Id=scott;Password=tiger;Data Source=oracle";

        private readonly string ConnectionString;

        public OracleDataAccess(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            return connection;
        }

        public void CloseConnection(IDbConnection connection)
        {
            OracleConnection OracleConnection = (OracleConnection)connection;
            OracleConnection.Close();
            OracleConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new OracleCommand
            {
                CommandText = commandText,
                Connection = (OracleConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new OracleDataAdapter((OracleCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            OracleCommand Oraclecommand = (OracleCommand)command;
            return Oraclecommand.CreateParameter();
        }
    }
}