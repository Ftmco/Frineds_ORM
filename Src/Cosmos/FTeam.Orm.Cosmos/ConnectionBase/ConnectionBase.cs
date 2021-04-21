using FTeam.Orm.Results.Connection;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.ConnectionBase
{
    public class ConnectionBase : IConnectionBase
    {
        private readonly SqlConnection _connection;

        public async Task<CloseConnectionResult> CloseConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    _connection.ConnectionString = connectionString;
                    await _connection.CloseAsync();
                    return CloseConnectionResult.Success;
                }
                catch (SqlException)
                {
                    return CloseConnectionResult.SqlException;
                }
                catch (Exception)
                {
                    return CloseConnectionResult.Exception;
                }
            });

        public async Task<OpenConnectionResult> OpenConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    _connection.ConnectionString = connectionString;
                    await _connection.OpenAsync();
                    return OpenConnectionResult.Success;
                }
                catch (InvalidOperationException)
                {
                    return OpenConnectionResult.InvalidOperationException;
                }
                catch (SqlException)
                {
                    return OpenConnectionResult.SqlException;
                }
                catch (Exception)
                {
                    return OpenConnectionResult.Exception;
                }
            });

    }
}
