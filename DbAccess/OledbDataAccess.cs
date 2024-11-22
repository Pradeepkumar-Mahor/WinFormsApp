using System.Data;

namespace DbAccess
{
    public class OledbDataAccess : IDatabaseHandler
    {
        private readonly string connectionString;

        public OledbDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CloseConnection(IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            throw new NotImplementedException();
        }
    }
}