using FTeam.Orm.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.ConnectionBase
{
    public class ConnectionBase : IConnectionBase
    {
        #region --:: Dependency ::--

        /// <summary>
        /// Sql Connection Object
        /// </summary>
        private readonly SqlConnection _connection;

        public ConnectionBase()
        {
            _connection = new();
        }

        #endregion

        #region :: Open Connection Base ::

        public OpenConnectionResult TryOpenConnection(SqlConnection sqlConnection)
            => TryOpenConnection(sqlConnection.ConnectionString);

        public async Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString)
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

        public async Task<OpenConnectionResult> TryOpenConnectionAsync(SqlConnection sqlConnection)
            => await Task.FromResult(await TryOpenConnectionAsync(sqlConnection.ConnectionString));

        public OpenConnectionResult TryOpenConnection(string connectionString)
        {
            OpenConnectionResult result = new();
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    result.SqlConnection = _connection;
                    return result;
                }
                _connection.ConnectionString = connectionString;
                _connection.Open();

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
        }

        #endregion

        #region :: Close Connection Base ::

        public CloseConnectionResult TryCloseConnection(string connectionString)
        {
            try
            {
                _connection.ConnectionString = connectionString;
                _connection.Close();
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
        }

        public CloseConnectionResult TryCloseConnection(SqlConnection sqlConnection)
            => TryCloseConnection(sqlConnection.ConnectionString);


        public async Task<CloseConnectionResult> TryCloseConnectionAsync(string connectionString)
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

        public async Task<CloseConnectionResult> TryCloseConnectionAsync(SqlConnection sqlConnection)
            => await Task.FromResult(await TryCloseConnectionAsync(sqlConnection.ConnectionString));

        #endregion
    }
}
