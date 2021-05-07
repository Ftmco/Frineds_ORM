using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.PgSql.Cosmos.QueryBase;
using FTeam.Orm.PgSql.DataBase.Tables.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public class TableGetServices : ITableGetRules
    {
        #region __Dependency__

        /// <summary>
        /// Query Base Services
        /// </summary>
        private readonly IPgSqlQueryBase _queryBase;

        /// <summary>
        /// Data Table Mapper
        /// </summary>
        private readonly IDataTableMapper _dataTableMapper;

        /// <summary>
        /// Crud Base Services
        /// </summary>
        private readonly ITableCrudBase _crudBase;

        /// <summary>
        /// Table Comuns Services
        /// </summary>
        private readonly ITableColumnsRules _tableColumns;

        public TableGetServices()
        {
            _dataTableMapper = new DataTableMapper();
            _crudBase = new TableCrudBaseServices();
            _queryBase = new PgSqlQueryBase();
            _tableColumns = new TableColumnsServices();
        }


        #endregion

        public IEnumerable<T> GetAll<T>(PgSqlTableInfoResult tableInfoResult)
            => _crudBase.GetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]");

        public IEnumerable<T> GetAll<T>(PgSqlTableInfoResult tableInfoResult, string query)
            => _crudBase.GetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public async Task<IEnumerable<T>> GetAllAsync<T>(PgSqlTableInfoResult tableInfoResult)
            => await Task.FromResult(await
                _crudBase.GetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]"));

        public async Task<IEnumerable<T>> GetAllAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await
                _crudBase.GetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public async Task<T> GetAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await _crudBase.GetBaseAsync<T>(tableInfoResult,
                $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public T Get<T>(PgSqlTableInfoResult tableInfoResult, string query)
            => _crudBase.GetBase<T>(tableInfoResult,
                 $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public IEnumerable<T> TryGetAll<T>(PgSqlTableInfoResult tableInfoResult)
          => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]");

        public IEnumerable<T> TryGetAll<T>(PgSqlTableInfoResult tableInfoResult, string query)
         => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public async Task<IEnumerable<T>> TryGetAllAsync<T>(PgSqlTableInfoResult tableInfoResult)
          => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]"));

        public async Task<IEnumerable<T>> TryGetAllAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
         => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public async Task<T> TryGetAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
         => await Task.FromResult(await _crudBase.TryGetBaseAsync<T>(tableInfoResult,
                $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public T TryGet<T>(PgSqlTableInfoResult tableInfoResult, string query)
         => _crudBase.GetBase<T>(tableInfoResult,
                 $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");
    }
}
