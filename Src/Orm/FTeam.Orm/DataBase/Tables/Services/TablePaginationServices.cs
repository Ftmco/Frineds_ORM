using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TablePaginationServices : ITablePaginationRules
    {
        #region __Dependency__

        /// <summary>
        /// Crud Base Services
        /// </summary>
        private readonly ITableCrudBase _crudBase;

        public TablePaginationServices()
        {
            _crudBase = new TableCrudBaseServices();
        }

        #endregion

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string orderColumn, int index, int count)
            => _crudBase.GetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] {GetPaginationQuery(orderColumn, index, count)}");

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query, string orderColumn, int index, int count)
            => _crudBase.GetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query} {GetPaginationQuery(orderColumn, index, count)}");

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string orderColumn, int index, int count)
            => await Task.FromResult(await
                _crudBase.GetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] {GetPaginationQuery(orderColumn, index, count)}"));

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query, string orderColumn, int index, int count)
            => await Task.FromResult(await
                _crudBase.GetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query} {GetPaginationQuery(orderColumn, index, count)}"));

        public IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult, string orderColumn, int index, int count)
          => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] {GetPaginationQuery(orderColumn, index, count)}");

        public IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult, string query, string orderColumn, int index, int count)
         => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query} {GetPaginationQuery(orderColumn, index, count)}");

        public async Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult, string orderColumn, int index, int count)
          => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] {GetPaginationQuery(orderColumn, index, count)}"));

        public async Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult, string query, string orderColumn, int index, int count)
         => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query} {GetPaginationQuery(orderColumn, index, count)}"));

        private static string GetPaginationQuery(string orderColumn, int index, int count)
            => $"ORDER BY {orderColumn} OFFSET {index} ROWS FETCH NEXT {count} ROWS ONLY";

    }
}
