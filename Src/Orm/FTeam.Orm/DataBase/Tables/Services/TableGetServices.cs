using FTeam.Orm.DataBase.Tables.Services;
using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public class TableGetServices : ITableGetRules
    {
        #region __Dependency__

        /// <summary>
        /// Crud Base Services
        /// </summary>
        private readonly ITableCrudBase _crudBase;

        public TableGetServices()
        {
            _crudBase = new TableCrudBaseServices();
        }

        #endregion

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult)
            => _crudBase.GetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]");

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query)
            => _crudBase.GetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult)
            => await Task.FromResult(await
                _crudBase.GetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]"));

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await
                _crudBase.GetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public async Task<T> GetAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await _crudBase.GetBaseAsync<T>(tableInfoResult,
                $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public T Get<T>(TableInfoResult tableInfoResult, string query)
            => _crudBase.GetBase<T>(tableInfoResult,
                 $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult)
          => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]");

        public IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult, string query)
         => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public async Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult)
          => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]"));

        public async Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult, string query)
         => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public async Task<T> TryGetAsync<T>(TableInfoResult tableInfoResult, string query)
         => await Task.FromResult(await _crudBase.TryGetBaseAsync<T>(tableInfoResult,
                $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public T TryGet<T>(TableInfoResult tableInfoResult, string query)
         => _crudBase.GetBase<T>(tableInfoResult,
                 $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");
    }
}
