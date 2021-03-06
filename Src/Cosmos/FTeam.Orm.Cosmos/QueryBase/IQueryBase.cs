﻿using FTeam.Orm.Models.QueryBase;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public interface IQueryBase
    {
        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, string query);
        Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query);

        Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, SqlCommand sqlCommand);
        Task<QueryStatus> RunVoidQueryAsync(string connectionString, SqlCommand sqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(SqlConnection sqlConnection, SqlCommand sqlCommand);
        Task<QueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, SqlCommand sqlCommand);

        Task<QueryStatus> TryRunVoidQueryAsync(SqlConnection sqlConnection, string query);
        Task<QueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, string query);

        Task<RunQueryResult> TryRunQueryAsync(string connectionString, string query);
        Task<RunQueryResult> RunQueryAsync(string connectionString, string query);

        Task<RunQueryResult> TryRunQueryAsync(SqlConnection sqlConnection, string query);
        Task<RunQueryResult> RunQueryAsync(SqlConnection sqlConnection, string query);

        RunQueryResult TryRunQuery(string connectionString, string query);
        RunQueryResult RunQuery(string connectionString, string query);

        RunQueryResult TryRunQuery(SqlConnection sqlConnection, string query);
        RunQueryResult RunQuery(SqlConnection sqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, string query);
        QueryStatus RunVoidQuery(string connectionString, string query);

        QueryStatus TryRunVoidQuery(SqlConnection sqlConnection, string query);
        QueryStatus RunVoidQuery(SqlConnection sqlConnection, string query);

        QueryStatus TryRunVoidQuery(string connectionString, SqlCommand sqlCommand);
        QueryStatus RunVoidQuery(string connectionString, SqlCommand sqlCommand);

        QueryStatus TryRunVoidQuery(SqlConnection sqlConnection, SqlCommand sqlCommand);
        QueryStatus RunVoidQuery(SqlConnection sqlConnection, SqlCommand sqlCommand);
    }
}
