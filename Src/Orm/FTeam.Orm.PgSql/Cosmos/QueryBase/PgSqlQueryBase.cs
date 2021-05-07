using FTeam.Orm.Models.QueryBase;
using FTeam.Orm.PgSql.Cosmos.ConnectionBase;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.Cosmos.QueryBase
{
    public class PgSqlQueryBase : IPgSqlQueryBase
    {
        #region --:: Dependency ::--

        private readonly IPgSqlConnectionBase _connectionBase;

        public PgSqlQueryBase()
        {
            _connectionBase = new PgSqlConnectionBase();
        }

        #endregion

        public RunQueryResult RunQuery(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public RunQueryResult RunQuery(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public Task<RunQueryResult> RunQueryAsync(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public Task<RunQueryResult> RunQueryAsync(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus RunVoidQuery(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus RunVoidQuery(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus RunVoidQuery(string connectionString, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public QueryStatus RunVoidQuery(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> RunVoidQueryAsync(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> RunVoidQueryAsync(string connectionString, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> RunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> RunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public RunQueryResult TryRunQuery(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public RunQueryResult TryRunQuery(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public Task<RunQueryResult> TryRunQueryAsync(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public Task<RunQueryResult> TryRunQueryAsync(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus TryRunVoidQuery(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus TryRunVoidQuery(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }

        public QueryStatus TryRunVoidQuery(string connectionString, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public QueryStatus TryRunVoidQuery(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, string query)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> TryRunVoidQueryAsync(string connectionString, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> TryRunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, NpgsqlCommand NpgsqlCommand)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> TryRunVoidQueryAsync(NpgsqlConnection NpgsqlConnection, string query)
        {
            throw new NotImplementedException();
        }
    }
}
