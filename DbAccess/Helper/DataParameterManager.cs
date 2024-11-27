using Microsoft.Data.SqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SQLite;

namespace DbAccess
{
    public class DataParameterManager
    {
        public static IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter? parameter = null;
            return providerName.ToLower() switch
            {
                "sql.data.sqlclient" => CreateSqlParameter(name, value, dbType, direction),
                "system.data.oracleclient" => CreateOracleParameter(name, value, dbType, direction),
                "system.data.oleDb" => CreateOleDbParameter(name, value, dbType, direction),
                "system.data.odbc" => CreateOdbcParameter(name, value, dbType, direction),
                "npgsql" => CreatePostgreSQLParameter(name, value, dbType, direction),
                "system.data.sqlite" => CreateSqLiteParameter(name, value, dbType, direction),
                _ => parameter,
            };
        }

        public static IDbDataParameter CreateParameter(string providerName, string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter? parameter = null;
            return providerName.ToLower() switch
            {
                "sql.data.sqlclient" => CreateSqlParameter(name, size, value, dbType, direction),
                "system.data.oracleclient" => CreateOracleParameter(name, size, value, dbType, direction),
                "system.data.oleDb" => CreateOleDbParameter(name, size, value, dbType, direction),
                "system.data.odbc" => CreateOdbcParameter(name, size, value, dbType, direction),
                "npgsql" => CreatePostgreSQLParameter(name, size, value, dbType, direction),
                "system.data.sqlite" => CreateSqLiteParameter(name, size, value, dbType, direction),
                _ => parameter,
            };
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

        private static IDbDataParameter CreatePostgreSQLParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new NpgsqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreatePostgreSQLParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new NpgsqlParameter
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