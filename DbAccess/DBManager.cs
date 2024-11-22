using System.Data;

namespace DbAccess
{
    public class DBManager
    {
        private readonly DatabaseHandlerFactory dbFactory;
        private readonly IDatabaseHandler database;
        private readonly string providerName;

        public DBManager(string connectionStringName)
        {
            dbFactory = new DatabaseHandlerFactory(connectionStringName);
            database = dbFactory.CreateDatabase();
            providerName = dbFactory.GetProviderName();
        }

        public IDbConnection GetDatabasecOnnection()
        {
            return database.CreateConnection();
        }

        public void CloseConnection(IDbConnection connection)
        {
            database.CloseConnection(connection);
        }

        public IDbDataParameter CreateParameter(string name, object value, DbType dbType)
        {
            return DataParameterManager.CreateParameter
                    (
                        providerName,
                        name, value, dbType,
                        ParameterDirection.Input
                     );
        }

        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return DataParameterManager.CreateParameter
                (
                    providerName, name, size, value, dbType,
                    ParameterDirection.Input
                );
        }

        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return DataParameterManager.CreateParameter
                (
                    providerName, name, size, value,
                    dbType, direction
                );
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    DataSet dataset = new();
                    IDataAdapter dataAdaper = database.CreateAdapter(command);
                    _ = dataAdaper.Fill(dataset);

                    return dataset.Tables[0];
                }
            }
        }

        public DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    DataSet dataset = new();
                    IDataAdapter dataAdaper = database.CreateAdapter(command);
                    _ = dataAdaper.Fill(dataset);

                    return dataset;
                }
            }
        }

        public IDataReader GetDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            IDbConnection connection = database.CreateConnection();
            connection = database.CreateConnection();
            connection.Open();

            IDbCommand command = database.CreateCommand(commandText, commandType, connection);
            if (parameters != null)
            {
                foreach (IDbDataParameter parameter in parameters)
                {
                    _ = command.Parameters.Add(parameter);
                }
            }

            IDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void Delete(string commandText, CommandType commandType, out string msgType, out string msgText, IDbDataParameter[]? parameters = null)
        {
            try
            {
                using (IDbConnection connection = database.CreateConnection())
                {
                    connection.Open();

                    using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (IDbDataParameter parameter in parameters)
                            {
                                _ = command.Parameters.Add(parameter);
                            }
                        }
                        int result = 0;
                        result = command.ExecuteNonQuery();
                        if (result == 1)
                        {
                            msgType = "OK";
                            msgText = "Record Deleted Successfully";
                        }
                        else
                        {
                            msgType = "KO";
                            msgText = "Error : Record Not Deleted";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msgType = "KO";
                msgText = "Error (Exception) : " + ex.Message;
            }
        }

        public void Insert(string commandText, CommandType commandType, out string msgType, out string msgText, IDbDataParameter[] parameters)
        {
            try
            {
                using (IDbConnection connection = database.CreateConnection())
                {
                    connection.Open();

                    using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (IDbDataParameter parameter in parameters)
                            {
                                _ = command.Parameters.Add(parameter);
                            }
                        }

                        int result = 0;
                        result = command.ExecuteNonQuery();
                        if (result == 1)
                        {
                            msgType = "OK";
                            msgText = "Record Inserted Successfully";
                        }
                        else
                        {
                            msgType = "KO";
                            msgText = "Error : Record Not Inserted";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msgType = "KO";
                msgText = "Error (Exception) : " + ex.Message;
            }
        }

        public int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out int lastId)
        {
            lastId = 0;
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    object newId = command.ExecuteScalar();
                    lastId = Convert.ToInt32(newId);
                }
            }

            return lastId;
        }

        public long Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out long lastId)
        {
            lastId = 0;
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    object newId = command.ExecuteScalar();
                    lastId = Convert.ToInt64(newId);
                }
            }

            return lastId;
        }

        public void InsertWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();
                IDbTransaction transactionScope = connection.BeginTransaction();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        _ = command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void InsertWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();
                IDbTransaction transactionScope = connection.BeginTransaction(isolationLevel);

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        _ = command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void Update(string commandText, CommandType commandType, out string msgType, out string msgText, IDbDataParameter[] parameters)
        {
            try
            {
                using (IDbConnection connection = database.CreateConnection())
                {
                    connection.Open();

                    using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (IDbDataParameter parameter in parameters)
                            {
                                _ = command.Parameters.Add(parameter);
                            }
                        }

                        int result = 0;
                        result = command.ExecuteNonQuery();
                        if (result == 1)
                        {
                            msgType = "OK";
                            msgText = "Record Updated Successfully ";
                        }
                        else
                        {
                            msgType = "KO";
                            msgText = "Error : Record Not Updated";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msgType = "KO";
                msgText = "Error (Exception) : " + ex.Message;
            }
        }

        public void UpdateWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();
                IDbTransaction transactionScope = connection.BeginTransaction();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        _ = command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void UpdateWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();
                IDbTransaction transactionScope = connection.BeginTransaction(isolationLevel);

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        _ = command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public object GetScalarValue(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            using (IDbConnection connection = database.CreateConnection())
            {
                connection.Open();

                using (IDbCommand command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (IDbDataParameter parameter in parameters)
                        {
                            _ = command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }
    }
}