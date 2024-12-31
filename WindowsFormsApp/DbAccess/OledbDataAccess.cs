using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApp
{
    public class OledbDataAccess : IDatabaseHandler
    {
        private string TestConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\path\\to\\your\\database.mdb;";
        private readonly string ConnectionString;

        public OledbDataAccess(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            return connection;
        }

        public void CloseConnection(IDbConnection connection)
        {
            OleDbConnection OledbConnection = (OleDbConnection)connection;
            OledbConnection.Close();
            OledbConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new OleDbCommand
            {
                CommandText = commandText,
                Connection = (OleDbConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new OleDbDataAdapter((OleDbCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            OleDbCommand Oledbcommand = (OleDbCommand)command;
            return Oledbcommand.CreateParameter();
        }
    }
}