using FTeam.DependencyController.Kernel;
using FTeam.Orm.Cosmos.ConnectionBase;
using FTeam.Orm.Results.Connection;
using FTeam.Orm.Results.QueryBase;
using System;
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

        public Task RunQueryAsync(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public async Task<VoidQueryStatus> RunVoidQueryAsync(string connectionString, string query)
            => await Task.Run(async () =>
            {
                OpenConnectionResult openConnection = await _connectionBase.OpenConnectionAsync(connectionString);

                switch (openConnection.ConnectionStatus)
                {
                    case OpenConnectionStatus.Success:
                        {
                            VoidQueryStatus result = await RunVoidQueryAsync(openConnection.SqlConnection, query);
                            return result;
                        }
                    case OpenConnectionStatus.Exception:
                        return VoidQueryStatus.Exception;

                    case OpenConnectionStatus.InvalidOperationException:
                        return VoidQueryStatus.InvalidOperationException;

                    case OpenConnectionStatus.SqlException:
                        return VoidQueryStatus.SqlException;

                    default:
                        return VoidQueryStatus.Exception;
                }
            });

        public async Task<VoidQueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, string query)
            => await Task.Run(async () =>
            {
                try
                {
                    SqlCommand cmd = new(query, sqlConnection);
                    await cmd.ExecuteNonQueryAsync();
                    return VoidQueryStatus.Success;
                }
                catch (DbException)
                {
                    return VoidQueryStatus.DbException;
                }
                catch (Exception)
                {
                    return VoidQueryStatus.Exception;
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
