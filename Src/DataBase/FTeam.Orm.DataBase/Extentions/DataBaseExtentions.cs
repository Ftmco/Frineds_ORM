using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Extentions
{
    public static class DataBaseExtentions
    {
        public static string GetConnectionString(this DbConnectionInfo dbConnectionInfo)
        {
            string connectionString = $"Server={dbConnectionInfo.Server};Initial Catalog={dbConnectionInfo.DataBaseName}";

            connectionString += dbConnectionInfo.Authentication switch
            {
                Authentication.WindowsAuthentication => "Integrated Security=True",
                _ => $"User Id={dbConnectionInfo.UserId};Password={dbConnectionInfo.Password}"
            };

            return connectionString;
        }

        public static async Task<string> GetConnectionStringAsync(this DbConnectionInfo dbConnectionInfo)
          => await Task.Run(() => dbConnectionInfo.GetConnectionString());
    }
}
