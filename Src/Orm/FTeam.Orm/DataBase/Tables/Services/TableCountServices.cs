using FTeam.Orm.Domains.DataBase;
using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableCountServices : ITableCountRules
    {
        #region __Dependency__

        /// <summary>
        /// Crud Base Services
        /// </summary>
        private readonly ITableCrudBase _crudBase;

        public TableCountServices()
        {
            _crudBase = new TableCrudBaseServices();
        }

        #endregion

        public int Count(TableInfoResult tableInfo)
        => _crudBase.GetBase<TableCountModel>(tableInfo,
                $"SELECT COUNT(*) as [Count] FROM [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}]").Count;

        public async Task<int> CountAsync(TableInfoResult tableInfo)
        => await Task.Run(() =>
             _crudBase.GetBaseAsync<TableCountModel>(tableInfo,
                $"SELECT COUNT(*) as [Count] FROM [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}]").Result.Count);

        public int TryCount(TableInfoResult tableInfo)
            => _crudBase.TryGetBase<TableCountModel>(tableInfo,
                $"SELECT COUNT(*) as [Count] FROM [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}]").Count;

        public async Task<int> TryCountAsync(TableInfoResult tableInfo)
            => await Task.Run(() =>
             _crudBase.TryGetBaseAsync<TableCountModel>(tableInfo,
                $"SELECT COUNT(*) as [Count] FROM [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}]").Result.Count);
    }
}
