using FTeam.Orm.Models.QueryBase;
using Npgsql;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.Cosmos.QueryBase
{
    public interface IPgSqlQueryBase
    {
        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, NpgsqlCommand NpgsqlCommand);

        Task<QueryStatus> RunVoidQueryAsync(string connectionString, NpgsqlCommand NpgsqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand);

        Task<QueryStatus> RunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, string query);

        Task<QueryStatus> RunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, string query);

        Task<RunQueryResult> TryRunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> RunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> TryRunQueryAsync(NpgsqlConnection NpgsqlConnection, string query);

        Task<RunQueryResult> RunQueryAsync(NpgsqlConnection NpgsqlConnection, string query);

        RunQueryResult TryRunQuery(string connectionString, string query);

        RunQueryResult RunQuery(string connectionString, string query);

        RunQueryResult TryRunQuery(NpgsqlConnection NpgsqlConnection, string query);

        RunQueryResult RunQuery(NpgsqlConnection NpgsqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, string query);

        QueryStatus RunVoidQuery(string connectionString, string query);

        QueryStatus TryRunVoidQuery(NpgsqlConnection NpgsqlConnection, string query);

        QueryStatus RunVoidQuery(NpgsqlConnection NpgsqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, NpgsqlCommand NpgsqlCommand);

        QueryStatus RunVoidQuery(string connectionString, NpgsqlCommand NpgsqlCommand);

        QueryStatus TryRunVoidQuery(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand);

        QueryStatus RunVoidQuery(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand);
    }
}
