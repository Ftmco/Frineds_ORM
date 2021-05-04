using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Models.Connection.Shared;
using Npgsql;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.Cosmos.ConnectionBase
{
    public interface IPgSqlConnectionBase
    {
        Task<OpenConnectionResult> OpenConnectionAsync(string connectionString);

        Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString);

        OpenConnectionResult OpenConnection(string connectionString);

        OpenConnectionResult TryOpenConnection(string connectionString);

        Task<CloseConnectionResult> CloseConnectionAsync(string connectionString);

        Task<CloseConnectionResult> TryCloseConnectionAsync(string connectionString);

        Task<CloseConnectionResult> CloseConnectionAsync(NpgsqlConnection npgsqlConnection);

        Task<CloseConnectionResult> TryCloseConnectionAsync(NpgsqlConnection npgsqlConnection);

        CloseConnectionResult CloseConnection(string connectionString);

        CloseConnectionResult TryCloseConnection(string connectionString);

        CloseConnectionResult CloseConnection(NpgsqlConnection npgsqlConnection);

        CloseConnectionResult TryCloseConnection(NpgsqlConnection npgsqlConnection);
    }
}
