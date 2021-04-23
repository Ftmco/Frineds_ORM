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
                RunQueryResult result = await _queryBase.RunQueryAsync(await dbConnection.GetConnectionStringAsync(),
                    $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'");

                return result.QueryStatus switch
                {
                    QueryStatus.Success => await GetTableInfoAsync(result),
                    QueryStatus.Exception => new TableInfo { Status = QueryStatus.Exception },
                    QueryStatus.InvalidOperationException => new TableInfo { Status = QueryStatus.InvalidOperationException },
                    QueryStatus.SqlException => new TableInfo { Status = QueryStatus.SqlException },
                    QueryStatus.DbException => new TableInfo { Status = QueryStatus.DbException },
                    _ => new TableInfo { Status = QueryStatus.Exception },
                };
            });

        public async Task<TableInfo> GetTableInfoAsync(RunQueryResult runQueryResult)
            => await Task.Run(() =>
            {
<<<<<<< Updated upstream
               
                TableInfo tableInfo = new()
=======
                DataTable dataTable = runQueryResult.DataTable;

                TableInfo tableInfo = new();
                return tableInfo;
>>>>>>> Stashed changes
            });

        private void RegisterDependency()
        {
            _kernel.Inject<IQueryBase, QueryBase>();
        }
    }
}
