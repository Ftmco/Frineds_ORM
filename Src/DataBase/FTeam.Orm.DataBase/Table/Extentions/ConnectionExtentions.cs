using FTeam.Orm.DataBase.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table.Extentions
{
    public static class ConnectionExtentions
    {
        public static async Task<string> GetConnectionStringAsync(this DbConnectionInfo dbConnectionInfo)
            => await Task.Run(() =>
            {
                string connectionString = $"Server={dbConnectionInfo.Server};Initial Catalog={dbConnectionInfo.DataBaseName}";

                connectionString += dbConnectionInfo.Authentication switch
                {
                    Authentication.WindowsAuthentication => $"Integrated Security=True",
                    Authentication.SqlServerAuthentication => $"User Id={dbConnectionInfo.UserId};Password={dbConnectionInfo.Password}",
                    _ => ""
                };

                return connectionString;
            });

        public static string GetConnectionString(this DbConnectionInfo dbConnectionInfo)
        {
            string connectionString = $"Server={dbConnectionInfo.Server};Initial Catalog={dbConnectionInfo.DataBaseName}";

            connectionString += dbConnectionInfo.Authentication switch
            {
                Authentication.WindowsAuthentication => $"Integrated Security=True",
                Authentication.SqlServerAuthentication => $"User Id={dbConnectionInfo.UserId};Password={dbConnectionInfo.Password}",
                _ => ""
            };

            return connectionString;
        }
    }
}
