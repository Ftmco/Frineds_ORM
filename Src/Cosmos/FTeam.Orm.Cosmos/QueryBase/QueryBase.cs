using FTeam.DependencyController.Kernel;
using FTeam.Orm.Cosmos.ConnectionBase;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public class QueryBase : IQueryBase
    {
        private readonly IFkernel _kernel = new Fkernel();

        private readonly IConnectionBase _connectionBase;

        public QueryBase()
        {
            RegisterDependency();
            _connectionBase = _kernel.Get<IConnectionBase>();
        }

        public RunQueryResult RunQuery(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public RunQueryResult RunQuery(SqlConnection sqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public async Task<RunQueryResult> RunQueryAsync(string connectionString, string query)
            => await Task.Run(async () =>
            {
                OpenConnectionResult openConnection = await _connectionBase.OpenConnectionAsync(connectionString);

                return openConnection.ConnectionStatus switch
                {
                    OpenConnectionStatus.Success => await RunQueryAsync(openConnection.SqlConnection, query),

                    OpenConnectionStatus.Exception => new RunQueryResult { QueryStatus = QueryStatus.Exception },

                    OpenConnectionStatus.InvalidOperationException => new RunQueryResult { QueryStatus = QueryStatus.InvalidOperationException },

                    OpenConnectionStatus.SqlException => new RunQueryResult { QueryStatus = QueryStatus.SqlException },

                    _ => new RunQueryResult { QueryStatus = QueryStatus.Exception }
                };
            });

        public async Task<RunQueryResult> RunQueryAsync(SqlConnection sqlConnection, string query)
            => await Task.Run(async() =>
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
                    await _connectionBase.CloseConnectionAsync(sqlConnection);
                }
            });

        public QueryStatus RunVoidQuery(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus RunVoidQuery(SqlConnection sqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query)
            => await Task.Run(async () =>
            {
                OpenConnectionResult openConnection = await _connectionBase.OpenConnectionAsync(connectionString);

                return openConnection.ConnectionStatus switch
                {
                    OpenConnectionStatus.Success => await RunVoidQueryAsync(openConnection.SqlConnection, query),

                    OpenConnectionStatus.Exception => QueryStatus.Exception,

                    OpenConnectionStatus.InvalidOperationException => QueryStatus.InvalidOperationException,

                    OpenConnectionStatus.SqlException => QueryStatus.SqlException,

                    _ => QueryStatus.Exception
                };
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
                    await _connectionBase.CloseConnectionAsync(sqlConnection);
                }
            });

        private void RegisterDependency()
        {
            _kernel.Inject<IConnectionBase, ConnectionBase.ConnectionBase>();
        }
    }
}
