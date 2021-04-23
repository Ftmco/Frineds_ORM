using FTeam.DependencyController.Kernel;
using FTeam.Orm.DataBase.Models;
using FTeam.Orm.Results.Connection;
using FTeam.Orm.Rules;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.Impelements
{
    public class Form : IForm
    {

        public OpenConnectionResult Connect(DbConnectionInfo dbConnectionInfo)
        {

        }

        public Task<OpenConnectionResult> ConnectAsync(DbConnectionInfo dbConnectionInfo)
        {
            throw new NotImplementedException();
        }

        private string CreateConnectionString(DbConnectionInfo dbConnectionInfo)
        {
            string connectionString = $"Server={dbConnectionInfo.Server};Initial Catalog={dbConnectionInfo.DataBaseName}";

            connectionString = dbConnectionInfo.Authentication switch
            {
                Authentication.SqlServerAuthentication => $"User Id={dbConnectionInfo.UserId};Password={dbConnectionInfo.Password}",
                _=> $""
            };

            return connectionString;
        }
    }
}
