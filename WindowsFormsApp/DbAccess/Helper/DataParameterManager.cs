using Microsoft.Data.SqlClient;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SQLite;

namespace WindowsFormsApp
{
    public class DataParameterManager
    {
        public static IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;

            switch (providerName.ToLower())
            {
                case "sql.data.sqlclient":
                    return CreateSqlParameter(name, value, dbType, direction);

                case "system.data.oracleclient":
                    return CreateOracleParameter(name, value, dbType, direction);

                case "system.data.oleDb":
                    return CreateOleDbParameter(name, value, dbType, direction);

                case "system.data.odbc":
                    return CreateOdbcParameter(name, value, dbType, direction);

                case "system.data.sqlite":
                    return CreateSqLiteParameter(name, value, dbType, direction);

                default:
                    break;
            }
            return parameter;
        }

        public static IDbDataParameter CreateParameter(string providerName, string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "sql.data.sqlclient":
                    return CreateSqlParameter(name, size, value, dbType, direction);

                case "system.data.oracleclient":
                    return CreateOracleParameter(name, size, value, dbType, direction);

                case "system.data.oleDb":
                    return CreateOleDbParameter(name, size, value, dbType, direction);

                case "system.data.odbc":
                    return CreateOdbcParameter(name, size, value, dbType, direction);

                case "system.data.sqlite":
                    return CreateSqLiteParameter(name, size, value, dbType, direction);

                default:
                    break;
            }
            return parameter;
        }

        private static IDbDataParameter CreateSqlParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateSqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOracleParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOracleParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOleDbParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new OleDbParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOleDbParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new OleDbParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOdbcParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new OdbcParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOdbcParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new OdbcParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateSqLiteParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new SQLiteParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateSqLiteParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SQLiteParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
    }
}