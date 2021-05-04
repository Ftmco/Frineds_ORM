using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Models.Connection.Shared;
using Npgsql;
using System.Data;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.Cosmos.ConnectionBase
{
    public class PgSqlConnectionBase : IPgSqlConnectionBase
    {
        private NpgsqlConnection _npgConnection;

        #region --:: Open Connection ::--

        public async Task<OpenConnectionResult> OpenConnectionAsync(string connectionString)
           => await Task.Run(async () =>
           {
               try
               {
                   if (_npgConnection != null && _npgConnection.State != ConnectionState.Open)
                   {
                       _npgConnection = new(connectionString);
                       await _npgConnection.OpenAsync();
                   }
                   return new OpenConnectionResult { ConnectionStatus = OpenConnectionStatus.Success, SqlConnection = _npgConnection };
               }
               catch
               {
                   throw;
               }
           });

        public async Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString)
           => await Task.Run(async () =>
           {
               try
               {
                   return await OpenConnectionAsync(connectionString);
               }
               catch
               {
                   return new() { ConnectionStatus = OpenConnectionStatus.Exception };
               }
           });

        public OpenConnectionResult TryOpenConnection(string connectionString)
        {
            try
            {
                return OpenConnection(connectionString);
            }
            catch
            {
                return new() { ConnectionStatus = OpenConnectionStatus.Exception };
            }
        }

        public OpenConnectionResult OpenConnection(string connectionString)
        {
            try
            {
                if (_npgConnection != null && _npgConnection.State != ConnectionState.Open)
                {
                    _npgConnection = new(connectionString);
                    _npgConnection.Open();
                }
                return new() { ConnectionStatus = OpenConnectionStatus.Success, SqlConnection = _npgConnection };
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region --:: Close Connection ::--

        public CloseConnectionResult CloseConnection(string connectionString)
        {
            try
            {
                _npgConnection = new(connectionString);
                _npgConnection.Close();
                return CloseConnectionResult.Success;
            }
            catch
            {
                throw;
            }
        }

        public CloseConnectionResult CloseConnection(NpgsqlConnection npgsqlConnection)
            => CloseConnection(npgsqlConnection.ConnectionString);

        public async Task<CloseConnectionResult> CloseConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    _npgConnection = new(connectionString);
                    await _npgConnection.CloseAsync();
                    return CloseConnectionResult.Success;
                }
                catch
                {
                    throw;
                }
            });

        public async Task<CloseConnectionResult> CloseConnectionAsync(NpgsqlConnection npgsqlConnection)
            => await Task.FromResult(await CloseConnectionAsync(npgsqlConnection.ConnectionString));

        public CloseConnectionResult TryCloseConnection(string connectionString)
        {
            try
            {
                return CloseConnection(connectionString);
            }
            catch
            {
                return CloseConnectionResult.Exception;
            }
        }

        public CloseConnectionResult TryCloseConnection(NpgsqlConnection npgsqlConnection)
            => TryCloseConnection(npgsqlConnection.ConnectionString);

        public async Task<CloseConnectionResult> TryCloseConnectionAsync(string connectionString)
             => await Task.Run(async () =>
             {
                 try
                 {
                     return await CloseConnectionAsync(connectionString);
                 }
                 catch
                 {
                     return CloseConnectionResult.Exception;
                 }
             });

        public async Task<CloseConnectionResult> TryCloseConnectionAsync(NpgsqlConnection npgsqlConnection)
            => await Task.FromResult(await TryCloseConnectionAsync(npgsqlConnection.ConnectionString));

        #endregion

    }
}
