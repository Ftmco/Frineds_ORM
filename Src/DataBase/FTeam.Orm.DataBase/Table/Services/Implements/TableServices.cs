using FTeam.DependencyController.Kernel;
using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Models;
using FTeam.Orm.DataBase.Models.Tables;
using FTeam.Orm.DataBase.Table.Extentions;
using FTeam.Orm.Results.Connection;
using FTeam.Orm.Results.QueryBase;
using System.Data;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table.Services
{
    public class TableServices : ITableServices
    {
        private readonly IFkernel _kernel = new Fkernel();

        private readonly IQueryBase _queryBase;

        public TableServices()
        {
            RegisterDependency();
            _queryBase = _kernel.Get<IQueryBase>();
        }

        public async Task<TableInfo> GetTableInfoAsync(DbConnectionInfo dbConnection, string tableName)
            => await Task.Run(async () =>
            {
                string connectionString = await dbConnection.GetConnectionStringAsync();

                RunQueryResult result = await _queryBase.RunQueryAsync(connectionString, $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'");

                switch (result.QueryStatus)
                {
                    case QueryStatus.Success:
                        break;
                    case QueryStatus.Exception:
                        break;
                    case QueryStatus.InvalidOperationException:
                        break;
                    case QueryStatus.SqlException:
                        break;
                    case QueryStatus.DbException:
                        break;
                    default:
                        break;
                }

                return new TableInfo();
            });

        public async Task<TableInfo> GetTableInfoAsync(RunQueryResult runQueryResult)
            => await Task.Run(() =>
            {
               
                TableInfo tableInfo = new()
            });

        private void RegisterDependency()
        {
            _kernel.Inject<IQueryBase, QueryBase>();
        }
    }
}
