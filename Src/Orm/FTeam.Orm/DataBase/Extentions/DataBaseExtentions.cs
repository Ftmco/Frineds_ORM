using FTeam.Orm.Models;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace FTeam.Orm.DataBase.Extentions
{
    public static class DataBaseExtentions
    {
        public static IDbConnection GetConnection(this DbConnectionInfo dbConnectionInfo)
            => dbConnectionInfo.DataBaseType switch
            {
                DataBaseType.PostgreSQL => dbConnectionInfo.GetPgSqlConnection(),
                DataBaseType.SQLServer => dbConnectionInfo.GetSqlServerCoonection(),
                _ => dbConnectionInfo.GetSqlServerCoonection()
            };

        private static IDbConnection GetSqlServerCoonection(this DbConnectionInfo dbConnectionInfo)
        {
            string connectionString = $"Data Source={dbConnectionInfo.Server};Initial Catalog={dbConnectionInfo.DataBaseName};";
            connectionString += dbConnectionInfo.Authentication switch
            {
                Authentication.SqlServerAuthentication => $"User Id={dbConnectionInfo.UserId};Password={dbConnectionInfo.Password}",
                _ => "Integrated Security=True"
            };
            return new SqlConnection(connectionString);

        }

        private static IDbConnection GetPgSqlConnection(this DbConnectionInfo dbConnectionInfo)
        {
            string connectionString = $"Server={dbConnectionInfo.Server};Data Base={dbConnectionInfo.DataBaseName};Port={(dbConnectionInfo.Port ?? "5432")};Password={dbConnectionInfo.Password}";
            return new NpgsqlConnection(connectionString);
        }
    }
}
