using System.Configuration;

namespace WindowsFormsApp
{
    public class DatabaseHandlerFactory
    {
        public readonly ConnectionStringSettings connectionStringSettings;

        public DatabaseHandlerFactory(string connectionStringName)
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }

        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;

            switch (connectionStringSettings.ProviderName.ToLower())
            {
                case "sql.data.sqlclient":
                    database = new SqlDataAccess(connectionStringSettings.ConnectionString);
                    break;

                case "system.data.oracleclient":
                    database = new OracleDataAccess(connectionStringSettings.ConnectionString);
                    break;

                case "system.data.oleDb":
                    database = new OledbDataAccess(connectionStringSettings.ConnectionString);
                    break;

                case "system.data.odbc":
                    database = new OdbcDataAccess(connectionStringSettings.ConnectionString);
                    break;

                case "system.data.sqlite":
                    database = new SqlLiteDataAccess(connectionStringSettings.ConnectionString);
                    break;

                default:
                    break;
            }

            return database;
        }

        public string GetProviderName()
        {
            //return "System.Data.SqlClient";
            return connectionStringSettings.ProviderName;
        }
    }
}