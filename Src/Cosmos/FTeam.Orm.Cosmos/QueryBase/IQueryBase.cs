using FTeam.Orm.Results.QueryBase;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public interface IQueryBase
    {
        Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, string query);

        Task<RunQueryResult> RunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> RunQueryAsync(SqlConnection sqlConnection, string query);

        RunQueryResult RunQuery(string connectionString, string query);

        RunQueryResult RunQuery(SqlConnection sqlConnection, string query);

        QueryStatus RunVoidQuery(string connectionString, string query);

        QueryStatus RunVoidQuery(SqlConnection sqlConnection, string query);
    }
}
