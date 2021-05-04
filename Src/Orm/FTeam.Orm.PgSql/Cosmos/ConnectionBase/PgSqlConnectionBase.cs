using FTeam.Orm.Domains.Connection;
using Npgsql;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.Cosmos.ConnectionBase
{
    public class PgSqlConnectionBase : IPgSqlConnectionBase
    {
        private NpgsqlConnection _npgConnection;

        public async Task<OpenConnectionResult> OpenConnectionAsync(string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    _npgConnection = new(connectionString);
                    await _npgConnection.OpenAsync();
                    return new OpenConnectionResult();
                }
                catch
                {

                    throw;
                }
            });

        public Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString)
        {
            throw new System.NotImplementedException();
        }
    }
}
