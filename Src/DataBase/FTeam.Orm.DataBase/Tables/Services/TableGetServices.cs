using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.DataBase.Tables.Services;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public class TableGetServices : ITableGetRules
    {
        #region __Dependency__

        /// <summary>
        /// Query Base Services
        /// </summary>
        private readonly IQueryBase _queryBase;

        /// <summary>
        /// Data Table Mapper
        /// </summary>
        private readonly IDataTableMapper _dataTableMapper;

        /// <summary>
        /// Crud Base Services
        /// </summary>
        private readonly ITableCrudBase _crudBase;

        private readonly ITablePrimaryKeyRules _tablePrimaryKey;

        public TableGetServices()
        {
            _dataTableMapper = new DataTableMapper();
            _crudBase = new TableCrudBaseServices();
            _queryBase = new QueryBase();
            _tablePrimaryKey = new TablePrimaryKeyServices();
        }


        #endregion

        public TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            RunQueryResult queryResult = _queryBase.TryRunQuery(dbConnectionInfo.GetConnectionString(), query);

            return ReturnResult(queryResult, dbConnectionInfo, tableName);
        }

        private TableInfoResult ReturnResult(RunQueryResult runQueryResult, DbConnectionInfo dbConnectionInfo, string tableName)
            => runQueryResult.QueryStatus switch
            {
                QueryStatus.Success => GetTableInfoResult(dbConnectionInfo, tableName, runQueryResult),

                QueryStatus.Exception => new() { TableInfo = null, Status = QueryStatus.Exception },

                QueryStatus.InvalidOperationException => new() { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                QueryStatus.SqlException => new() { TableInfo = null, Status = QueryStatus.SqlException },

                QueryStatus.DbException => new() { TableInfo = null, Status = QueryStatus.DbException },

                _ => new() { TableInfo = null, Status = QueryStatus.Exception }
            };

        public async Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(async () =>
            {
                string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.TryRunQueryAsync(dbConnectionInfo.GetConnectionString(), query);

                //Return Result
                return await ReturnResultAsync(queryResult, dbConnectionInfo, tableName);
            });

        private async Task<TableInfoResult> ReturnResultAsync(RunQueryResult runQueryResult, DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(async () =>
             runQueryResult.QueryStatus switch
             {
                 //Success Status
                 //Return Table Info
                 QueryStatus.Success => await GetTableInfoResultAsync(dbConnectionInfo, tableName, runQueryResult),

                 //System Exceptions
                 QueryStatus.Exception => new TableInfoResult() { TableInfo = null, Status = QueryStatus.Exception },

                 //InvalidOperationException Ado.Net Exceptions
                 QueryStatus.InvalidOperationException => new TableInfoResult { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                 //Connection Or Query Execute Exceptions
                 QueryStatus.SqlException => new TableInfoResult() { TableInfo = null, Status = QueryStatus.SqlException },

                 //Data Base Exceptions
                 QueryStatus.DbException => new TableInfoResult() { TableInfo = null, Status = QueryStatus.DbException },

                 //default
                 _ => new TableInfoResult() { TableInfo = null, Status = QueryStatus.Exception }
             });

        private async Task<TableInfoResult> GetTableInfoResultAsync(DbConnectionInfo dbConnectionInfo, string tableName, RunQueryResult queryResult)
            => await Task.Run(async () =>
            {
                TableInfoResult tableInfoResult = new()
                {
                    TableInfo = await _dataTableMapper.MapAsync<TableInfo>(queryResult.DataTable),
                    Status = QueryStatus.Success,
                    DbConnectionInfo = dbConnectionInfo
                };
                tableInfoResult.TableInfo.TableColumns = await GetTableColumnsAsync(tableName, dbConnectionInfo);
                tableInfoResult.TableInfo.PrimaryKey = await _tablePrimaryKey.TryGetTablePrimaryKeyAsync(dbConnectionInfo, tableInfoResult);
                tableInfoResult.TableInfo.PrimaryKey.Type = tableInfoResult.TableInfo.TableColumns.FirstOrDefault(c => c.Column ==
                tableInfoResult.TableInfo.PrimaryKey.Column).Type;
                return tableInfoResult;
            });

        private TableInfoResult GetTableInfoResult(DbConnectionInfo dbConnectionInfo, string tableName, RunQueryResult queryResult)
        {
            TableInfoResult tableInfoResult = new()
            {
                TableInfo = _dataTableMapper.Map<TableInfo>(queryResult.DataTable),
                Status = QueryStatus.Success,
                DbConnectionInfo = dbConnectionInfo
            };
            tableInfoResult.TableInfo.TableColumns = GetTableColumns(tableName, dbConnectionInfo);
            tableInfoResult.TableInfo.PrimaryKey = _tablePrimaryKey.TryGetTablePrimaryKey(dbConnectionInfo, tableInfoResult);
            return tableInfoResult;
        }



        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult)
            => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]");

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query)
            => _crudBase.TryGetAllBase<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult)
            => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]"));

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await
                _crudBase.TryGetAllBaseAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public async Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo)
            => await Task.Run(async () =>
            {
                string query = $"SELECT ISNULLABLE as Nullable,DATATYPE as Type,Column_name as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = _queryBase.TryRunQuery(dbConnectionInfo.GetConnectionString(), query);

                QueryStatus status = queryResult.QueryStatus;

                return status switch
                {
                    QueryStatus.Success => await _dataTableMapper.MapListAsync<TableColumns>(queryResult.DataTable),

                    _ => null
                };
            });

        public IEnumerable<TableColumns> GetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo)
        {
            string query = $"SELECT IS_NULLABLE as [Nullable],DATA_TYPE as [Type],COLUMN_NAME as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME =  '{tableName}'";

            RunQueryResult queryResult = _queryBase.TryRunQuery(dbConnectionInfo.GetConnectionString(), query);

            QueryStatus status = queryResult.QueryStatus;

            return status switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<TableColumns>(queryResult.DataTable),

                _ => null
            };
        }

        public async Task<T> GetAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await _crudBase.TryGetBaseAsync<T>(tableInfoResult,
                $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        public T Get<T>(TableInfoResult tableInfoResult, string query)
            => _crudBase.TryGetBase<T>(tableInfoResult,
                 $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

    }
}
