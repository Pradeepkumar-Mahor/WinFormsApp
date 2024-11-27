using System.Data;
using System.Data.Odbc;

namespace DbAccess
{
    public class OdbcDataAccess : IDatabaseHandler
    {
        private string TestConnectionString = "Driver={ODBC Driver};Server=your_server;Database=your_database;Uid=your_username;Pwd=your_password;";
        private string ConnectionString { get; set; }

        public OdbcDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            OdbcConnection connection = new(ConnectionString);
            return connection;
        }

        public void CloseConnection(IDbConnection connection)
        {
            OdbcConnection OdbcConnection = (OdbcConnection)connection;
            OdbcConnection.Close();
            OdbcConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new OdbcCommand
            {
                CommandText = commandText,
                Connection = (OdbcConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new OdbcDataAdapter((OdbcCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            OdbcCommand Odbccommand = (OdbcCommand)command;
            return Odbccommand.CreateParameter();
        }
    }
}