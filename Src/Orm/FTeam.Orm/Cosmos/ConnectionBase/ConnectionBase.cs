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
        private readonly IDbConnection _connection;

        public ConnectionBase(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        #endregion

        #region :: Open Connection Base ::

        public OpenConnectionResult TryOpenConnection(IDbConnection sqlConnection)
            => TryOpenConnection(sqlConnection.ConnectionString);

        public async Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                OpenConnectionResult result = new();
                try
                {
                    return await OpenConnectionAsync(connectionString);
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

        public async Task<OpenConnectionResult> TryOpenConnectionAsync(IDbConnection sqlConnection)
            => await Task.FromResult(await TryOpenConnectionAsync(sqlConnection.ConnectionString));

        public OpenConnectionResult TryOpenConnection(string connectionString)
        {
            OpenConnectionResult result = new();
            try
            {
                return OpenConnection(connectionString);
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

        public async Task<OpenConnectionResult> OpenConnectionAsync(string connectionString)
         => await Task.Run(() => OpenConnection(connectionString));

        public OpenConnectionResult OpenConnection(string connectionString)
        {
            OpenConnectionResult result = new();
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    result.DbConnection = _connection;
                    return result;
                }
                _connection.ConnectionString = connectionString;
                _connection.Open();

                result.DbConnection = _connection;
                result.ConnectionStatus = OpenConnectionStatus.Success;
                return result;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OpenConnectionResult> OpenConnectionAsync(IDbConnection sqlConnection)
            => await Task.FromResult(await OpenConnectionAsync(sqlConnection.ConnectionString));

        public OpenConnectionResult OpenConnection(IDbConnection sqlConnection)
            => OpenConnection(sqlConnection.ConnectionString);

        #endregion

        #region :: Close Connection Base ::

        public CloseConnectionResult TryCloseConnection(string connectionString)
        {
            try
            {
                return CloseConnection(connectionString);
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

        public CloseConnectionResult TryCloseConnection(IDbConnection sqlConnection)
            => TryCloseConnection(sqlConnection.ConnectionString);


        public async Task<CloseConnectionResult> TryCloseConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    return await CloseConnectionAsync(connectionString);
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

        public async Task<CloseConnectionResult> TryCloseConnectionAsync(IDbConnection sqlConnection)
            => await Task.FromResult(await TryCloseConnectionAsync(sqlConnection.ConnectionString));



        public async Task<CloseConnectionResult> CloseConnectionAsync(string connectionString)
         => await Task.Run(() => CloseConnection(connectionString));

        public CloseConnectionResult CloseConnection(string connectionString)
        {
            try
            {
                _connection.ConnectionString = connectionString;
                _connection.Close();
                return CloseConnectionResult.Success;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CloseConnectionResult> CloseConnectionAsync(IDbConnection sqlConnection)
            => await Task.FromResult(await CloseConnectionAsync(sqlConnection.ConnectionString));

        public CloseConnectionResult CloseConnection(IDbConnection sqlConnection)
            => CloseConnection(sqlConnection.ConnectionString);

        #endregion
    }
}
