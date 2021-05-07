using FTeam.Orm.Models.QueryBase;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public interface IQueryBase
    {
        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, IDbCommand sqlCommand);

        Task<QueryStatus> RunVoidQueryAsync(string connectionString, IDbCommand sqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(IDbConnection sqlConnection, IDbCommand sqlCommand);

        Task<QueryStatus> RunVoidQueryAsync(IDbConnection sqlConnection, IDbCommand sqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(IDbConnection sqlConnection, string query);

        Task<QueryStatus> RunVoidQueryAsync(IDbConnection sqlConnection, string query);

        Task<RunQueryResult> TryRunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> RunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> TryRunQueryAsync(IDbConnection sqlConnection, string query);

        Task<RunQueryResult> RunQueryAsync(IDbConnection sqlConnection, string query);

        RunQueryResult TryRunQuery(string connectionString, string query);
        RunQueryResult RunQuery(string connectionString, string query);

        RunQueryResult TryRunQuery(IDbConnection sqlConnection, string query);

        RunQueryResult RunQuery(IDbConnection sqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, string query);

        QueryStatus RunVoidQuery(string connectionString, string query);

        QueryStatus TryRunVoidQuery(IDbConnection sqlConnection, string query);
        QueryStatus RunVoidQuery(IDbConnection sqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, IDbCommand sqlCommand);

        QueryStatus RunVoidQuery(string connectionString, IDbCommand sqlCommand);

        QueryStatus TryRunVoidQuery(IDbConnection sqlConnection, IDbCommand sqlCommand);

        QueryStatus RunVoidQuery(IDbConnection sqlConnection, IDbCommand sqlCommand);
    }
}
