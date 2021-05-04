﻿using FTeam.Orm.Domains.Connection.SqlServer;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Extentions
{
    public static class DataBaseExtentions
    {
        public static string GetConnectionString(this SqlServerDbConnectionInfo SqlServerDbConnectionInfo)
        {
            string connectionString = $"Data Source={SqlServerDbConnectionInfo.Server};Initial Catalog={SqlServerDbConnectionInfo.DataBaseName};";

            connectionString += SqlServerDbConnectionInfo.Authentication switch
            {
                Authentication.WindowsAuthentication => "Integrated Security=True;",
                _ => $"User Id={SqlServerDbConnectionInfo.UserId};Password={SqlServerDbConnectionInfo.Password};"
            };

            return connectionString;
        }

        public static async Task<string> GetConnectionStringAsync(this SqlServerDbConnectionInfo SqlServerDbConnectionInfo)
          => await Task.Run(() => SqlServerDbConnectionInfo.GetConnectionString());
    }
}
