using FTeam.Orm.Cosmos.ConnectionBase;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public class QueryBase : IQueryBase
    {
        private readonly IConnectionBase _connectionBase;

        public QueryBase()
        {
            _connectionBase = new ConnectionBase.ConnectionBase();
        }

        public RunQueryResult RunQuery(string connectionString, string query)
            => RunQuery(_connectionBase.OpenConnection(connectionString).SqlConnection, query);


        public RunQueryResult RunQuery(SqlConnection sqlConnection, string query)
        {
            try
            {
                SqlDataAdapter sqlDataAdapter = new(query, sqlConnection);
                DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                return new RunQueryResult { DataTable = dataTable, QueryStatus = QueryStatus.Success };
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connectionBase.TryCloseConnection(sqlConnection);
            }
        }

        public async Task<RunQueryResult> RunQueryAsync(string connectionString, string query)
            => await Task.FromResult(await RunQueryAsync(_connectionBase.OpenConnectionAsync(connectionString).Result.SqlConnection, query));

        public async Task<RunQueryResult> RunQueryAsync(SqlConnection sqlConnection, string query)
        => await Task.Run(async () =>
        {
            try
            {
                SqlDataAdapter sqlDataAdapter = new(query, sqlConnection);
                DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                return new RunQueryResult { DataTable = dataTable, QueryStatus = QueryStatus.Success };
            }
            catch (InvalidOperationException)
            {
                return new RunQueryResult { QueryStatus = QueryStatus.InvalidOperationException };
            }
            catch (Exception)
            {
                return new RunQueryResult { QueryStatus = QueryStatus.Exception };
            }
            finally
            {
                await _connectionBase.TryCloseConnectionAsync(sqlConnection);
            }
        });

        public QueryStatus RunVoidQuery(string connectionString, string query)
            => RunVoidQuery(_connectionBase.OpenConnection(connectionString).SqlConnection, query);

        public QueryStatus RunVoidQuery(SqlConnection sqlConnection, string query)
        {
            try
            {
                SqlCommand cmd = new(query, sqlConnection);
                cmd.ExecuteNonQuery();
                return QueryStatus.Success;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connectionBase.TryCloseConnection(sqlConnection);
            }
        }

        public QueryStatus RunVoidQuery(string connectionString, SqlCommand sqlCommand)
            => RunVoidQuery(connectionString, sqlCommand.CommandText);

        public QueryStatus RunVoidQuery(SqlConnection sqlConnection, SqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.ExecuteNonQuery();
                return QueryStatus.Success;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connectionBase.TryCloseConnection(sqlConnection);
            }
        }

        public async Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query)
            => await Task.FromResult(await RunVoidQueryAsync(_connectionBase.OpenConnectionAsync(connectionString).Result.SqlConnection, query));

        public async Task<QueryStatus> RunVoidQueryAsync(string connectionString, SqlCommand sqlCommand)
             => await Task.Run(async () =>
             {
                 OpenConnectionResult openConnection = await _connectionBase.TryOpenConnectionAsync(connectionString);

                 return openConnection.ConnectionStatus switch
                 {
                     OpenConnectionStatus.Success => await TryRunVoidQueryAsync(openConnection.SqlConnection, sqlCommand),

                     OpenConnectionStatus.Exception => QueryStatus.Exception,

                     OpenConnectionStatus.InvalidOperationException => QueryStatus.InvalidOperationException,

                     OpenConnectionStatus.SqlException => QueryStatus.SqlException,

                     _ => QueryStatus.Exception
                 };
             });

        public async Task<QueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, SqlCommand sqlCommand)
            => await Task.Run(async () =>
            {
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    await sqlCommand.ExecuteNonQueryAsync();
                    return QueryStatus.Success;
                }
                catch (DbException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await _connectionBase.TryCloseConnectionAsync(sqlConnection);
                }
            });

        public async Task<QueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, string query)
            => await Task.Run(async () =>
            {
                try
                {
                    SqlCommand cmd = new(query, sqlConnection);
                    await cmd.ExecuteNonQueryAsync();
                    return QueryStatus.Success;
                }
                catch (DbException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await _connectionBase.TryCloseConnectionAsync(sqlConnection);
                }
            });

        public RunQueryResult TryRunQuery(string connectionString, string query)
        {
            OpenConnectionResult openConnection = _connectionBase.TryOpenConnection(connectionString);

            return openConnection.ConnectionStatus switch
            {
                OpenConnectionStatus.Success => TryRunQuery(openConnection.SqlConnection, query),

                OpenConnectionStatus.Exception => new RunQueryResult { QueryStatus = QueryStatus.Exception },

                OpenConnectionStatus.InvalidOperationException => new RunQueryResult { QueryStatus = QueryStatus.InvalidOperationException },

                OpenConnectionStatus.SqlException => new RunQueryResult { QueryStatus = QueryStatus.SqlException },

                _ => new RunQueryResult { QueryStatus = QueryStatus.Exception }
            };
        }

        public RunQueryResult TryRunQuery(SqlConnection sqlConnection, string query)
        {
            try
            {
                return RunQuery(sqlConnection, query);
            }
            catch (InvalidOperationException)
            {
                return new RunQueryResult { QueryStatus = QueryStatus.InvalidOperationException };
            }
            catch (Exception)
            {
                return new RunQueryResult { QueryStatus = QueryStatus.Exception };
            }
            finally
            {
                _connectionBase.TryCloseConnection(sqlConnection);
            }
        }

        public async Task<RunQueryResult> TryRunQueryAsync(string connectionString, string query)
            => await Task.Run(async () =>
            {
                OpenConnectionResult openConnection = await _connectionBase.TryOpenConnectionAsync(connectionString);

                return openConnection.ConnectionStatus switch
                {
                    OpenConnectionStatus.Success => await TryRunQueryAsync(openConnection.SqlConnection, query),

                    OpenConnectionStatus.Exception => new RunQueryResult { QueryStatus = QueryStatus.Exception },

                    OpenConnectionStatus.InvalidOperationException => new RunQueryResult { QueryStatus = QueryStatus.InvalidOperationException },

                    OpenConnectionStatus.SqlException => new RunQueryResult { QueryStatus = QueryStatus.SqlException },

                    _ => new RunQueryResult { QueryStatus = QueryStatus.Exception }
                };
            });

        public async Task<RunQueryResult> TryRunQueryAsync(SqlConnection sqlConnection, string query)
            => await Task.Run(async () =>
            {
                try
                {
                    return await RunQueryAsync(sqlConnection, query);
                }
                catch (InvalidOperationException)
                {
                    return new RunQueryResult { QueryStatus = QueryStatus.InvalidOperationException };
                }
                catch (Exception)
                {
                    return new RunQueryResult { QueryStatus = QueryStatus.Exception };
                }
                finally
                {
                    await _connectionBase.TryCloseConnectionAsync(sqlConnection);
                }
            });

        public QueryStatus TryRunVoidQuery(string connectionString, string query)
        {
            OpenConnectionResult openConnection = _connectionBase.TryOpenConnection(connectionString);

            return openConnection.ConnectionStatus switch
            {
                OpenConnectionStatus.Success => TryRunVoidQuery(openConnection.SqlConnection, query),

                OpenConnectionStatus.Exception => QueryStatus.Exception,

                OpenConnectionStatus.InvalidOperationException => QueryStatus.InvalidOperationException,

                OpenConnectionStatus.SqlException => QueryStatus.SqlException,

                _ => QueryStatus.Exception
            };
        }

        public QueryStatus TryRunVoidQuery(SqlConnection sqlConnection, string query)
        {
            try
            {
                return RunVoidQuery(sqlConnection, query);
            }
            catch (DbException)
            {
                return QueryStatus.DbException;
            }
            catch (Exception)
            {
                return QueryStatus.Exception;
            }
            finally
            {
                _connectionBase.TryCloseConnection(sqlConnection);
            }
        }

        public QueryStatus TryRunVoidQuery(string connectionString, SqlCommand sqlCommand)
        {
            OpenConnectionResult openConnection = _connectionBase.TryOpenConnection(connectionString);

            return openConnection.ConnectionStatus switch
            {
                OpenConnectionStatus.Success => TryRunVoidQuery(openConnection.SqlConnection, sqlCommand),

                OpenConnectionStatus.Exception => QueryStatus.Exception,

                OpenConnectionStatus.InvalidOperationException => QueryStatus.InvalidOperationException,

                OpenConnectionStatus.SqlException => QueryStatus.SqlException,

                _ => QueryStatus.Exception
            };
        }

        public QueryStatus TryRunVoidQuery(SqlConnection sqlConnection, SqlCommand sqlCommand)
        {
            try
            {
                return RunVoidQuery(sqlConnection, sqlCommand);
            }
            catch (DbException)
            {
                return QueryStatus.DbException;
            }
            catch (Exception)
            {
                return QueryStatus.Exception;
            }
            finally
            {
                _connectionBase.TryCloseConnection(sqlConnection);
            }
        }

        public async Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, string query)
            => await Task.Run(async () =>
            {
                OpenConnectionResult openConnection = await _connectionBase.TryOpenConnectionAsync(connectionString);

                return openConnection.ConnectionStatus switch
                {
                    OpenConnectionStatus.Success => await TryRunVoidQueryAsync(openConnection.SqlConnection, query),

                    OpenConnectionStatus.Exception => QueryStatus.Exception,

                    OpenConnectionStatus.InvalidOperationException => QueryStatus.InvalidOperationException,

                    OpenConnectionStatus.SqlException => QueryStatus.SqlException,

                    _ => QueryStatus.Exception
                };
            });

        public async Task<QueryStatus> TryRunVoidQueryAsync(SqlConnection sqlConnection, string query)
            => await Task.Run(async () =>
            {
                try
                {
                    return await RunVoidQueryAsync(sqlConnection, query);
                }
                catch (DbException)
                {
                    return QueryStatus.DbException;
                }
                catch (Exception)
                {
                    return QueryStatus.Exception;
                }
                finally
                {
                    await _connectionBase.TryCloseConnectionAsync(sqlConnection);
                }
            });

        public async Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, SqlCommand sqlCommand)
             => await Task.FromResult(await RunVoidQueryAsync(connectionString, sqlCommand));

        public async Task<QueryStatus> TryRunVoidQueryAsync(SqlConnection sqlConnection, SqlCommand sqlCommand)
             => await Task.Run(async () =>
             {
                 try
                 {
                     return await RunVoidQueryAsync(sqlConnection, sqlCommand);
                 }
                 catch (DbException)
                 {
                     return QueryStatus.DbException;
                 }
                 catch (Exception)
                 {
                     return QueryStatus.Exception;
                 }
                 finally
                 {
                     await _connectionBase.TryCloseConnectionAsync(sqlConnection);
                 }
             });
    }
}
