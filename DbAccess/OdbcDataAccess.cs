﻿using System.Data;
using System.Data.Odbc;

namespace DbAccess
{
    public class OdbcDataAccess : IDatabaseHandler
    {
        private string ConnectionString { get; set; }

        public OdbcDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new OdbcConnection(ConnectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            OdbcConnection odbcConnection = (OdbcConnection)connection;
            odbcConnection.Close();
            odbcConnection.Dispose();
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
            OdbcCommand SQLcommand = (OdbcCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}