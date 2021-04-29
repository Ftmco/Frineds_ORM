using FTeam.Orm.Results.QueryBase;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public interface IQueryBase
    {
        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, SqlCommand sqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(SqlConnection sqlConnection, SqlCommand sqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(SqlConnection sqlConnection, string query);

        Task<RunQueryResult> TryRunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> TryRunQueryAsync(SqlConnection sqlConnection, string query);

        RunQueryResult TryRunQuery(string connectionString, string query);

        RunQueryResult TryRunQuery(SqlConnection sqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, string query);

        QueryStatus TryRunVoidQuery(SqlConnection sqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, SqlCommand sqlCommand);

        QueryStatus TryRunVoidQuery(SqlConnection sqlConnection, SqlCommand sqlCommand);
    }
}
