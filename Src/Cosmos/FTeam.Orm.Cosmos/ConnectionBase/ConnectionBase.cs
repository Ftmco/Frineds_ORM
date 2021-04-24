using FTeam.Orm.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.ConnectionBase
{
    public class ConnectionBase : IConnectionBase
    {
        private readonly SqlConnection _connection;

        public ConnectionBase()
        {
            _connection = new();
        }

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

        public async Task<CloseConnectionResult> CloseConnectionAsync(SqlConnection sqlConnection)
            => await Task.FromResult(await CloseConnectionAsync(sqlConnection.ConnectionString));

        public async Task<OpenConnectionResult> OpenConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                OpenConnectionResult result = new();
                try
                {
                    _connection.ConnectionString = connectionString;
                    await _connection.OpenAsync();

                    result.SqlConnection = _connection;
                    result.ConnectionStatus = OpenConnectionStatus.Success;
                    return result;
                }
                catch (InvalidOperationException)
                {
                    result.ConnectionStatus = OpenConnectionStatus.InvalidOperationException;
                    return result;
                }
                catch (SqlException)
                {
                    result.ConnectionStatus = OpenConnectionStatus.SqlException;
                    return result;
                }
                catch (Exception)
                {
                    result.ConnectionStatus = OpenConnectionStatus.Exception;
                    return result;
                }
            });

        public async Task<OpenConnectionResult> OpenConnectionAsync(SqlConnection sqlConnection)
            => await Task.FromResult(await OpenConnectionAsync(sqlConnection.ConnectionString));
    }
}
