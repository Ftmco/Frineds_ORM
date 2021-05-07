using FTeam.Orm.Domains.Connection.PgSql;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Extentions
{
    /// <summary>
    /// Data Base Connection String Extentions
    /// </summary>
    public static class DataBaseExtentions
    {
        /// <summary>
        /// Create Connection String For Pg Sql From <see cref="PgSqlSqlServerDbConnectionInfo"/>
        /// </summary>
        /// <param name="pgSqlConnectionInfo"><see cref="PgSqlDbConnectionInfo"/></param>
        /// <returns>Connection String</returns>
        public static string GetConnectionString(this PgSqlDbConnectionInfo pgSqlConnectionInfo)
         => $"Server={pgSqlConnectionInfo.Server};Port={pgSqlConnectionInfo.Port};User Id={pgSqlConnectionInfo.UserId};Passwrod={pgSqlConnectionInfo.Password}";

        /// <summary>
        /// Create Connection String For Pg Sql From <see cref="PgSqlSqlServerDbConnectionInfo"/>
        /// Use 'await'
        /// </summary>
        /// <param name="pgSqlConnectionInfo"><see cref="PgSqlDbConnectionInfo"/></param>
        /// <returns>Task Connection String</returns>
        public static async Task<string> GetConnectionStringAsync(this PgSqlDbConnectionInfo pgSqlConnectionInfo)
          => await Task.Run(() => pgSqlConnectionInfo.GetConnectionString());
    }
}
