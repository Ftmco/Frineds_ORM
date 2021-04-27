using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public class TableServices : ITableRules
    {
        #region __Dependency__

        private readonly IQueryBase _queryBase;

        private readonly IDataTableMapper _dataTableMapper;

        public TableServices()
        {
            _queryBase = new QueryBase();
            _dataTableMapper = new DataTableMapper();
        }


        #endregion

        public TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            RunQueryResult queryResult = _queryBase.RunQuery(dbConnectionInfo.GetConnectionString(), query);

            TableInfoResult result = new();
            if (queryResult.QueryStatus == QueryStatus.Success)
            {
                result = new()
                {
                    TableInfo = _dataTableMapper.Map<TableInfo>(queryResult.DataTable),
                    Status = QueryStatus.Success,
                    DbConnectionInfo = dbConnectionInfo
                };

                result.TableInfo.TableColumns = GetTableColumns(tableName, dbConnectionInfo);
            }

            return queryResult.QueryStatus switch
            {
                QueryStatus.Success => result,

                QueryStatus.Exception => new() { TableInfo = null, Status = QueryStatus.Exception },

                QueryStatus.InvalidOperationException => new() { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                QueryStatus.SqlException => new() { TableInfo = null, Status = QueryStatus.SqlException },

                QueryStatus.DbException => new() { TableInfo = null, Status = QueryStatus.DbException },

                _ => new() { TableInfo = null, Status = QueryStatus.Exception }
            };
        }

        public async Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(async () =>
            {
                string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.RunQueryAsync(dbConnectionInfo.GetConnectionString(), query);

                TableInfoResult result = new();
                if (queryResult.QueryStatus == QueryStatus.Success)
                {
                    result = new()
                    {
                        TableInfo = await _dataTableMapper.MapAsync<TableInfo>(queryResult.DataTable),
                        Status = QueryStatus.Success,
                        DbConnectionInfo = dbConnectionInfo
                    };

                    result.TableInfo.TableColumns = await GetTableColumnsAsync(tableName, dbConnectionInfo);
                }

                return queryResult.QueryStatus switch
                {
                    QueryStatus.Success => result,

                    QueryStatus.Exception => new() { TableInfo = null, Status = QueryStatus.Exception },

                    QueryStatus.InvalidOperationException => new() { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                    QueryStatus.SqlException => new() { TableInfo = null, Status = QueryStatus.SqlException },

                    QueryStatus.DbException => new() { TableInfo = null, Status = QueryStatus.DbException },

                    _ => new() { TableInfo = null, Status = QueryStatus.Exception }
                };
            });

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult)
            => GetEnumerable<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]");

        public IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query)
            => GetEnumerable<T>(tableInfoResult,
                $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        private IEnumerable<T> GetEnumerable<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<T>(runQuery.DataTable),

                _ => null
            };
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult)
            => await Task.FromResult(await
                GetEnumerableAsync<T>(tableInfoResult,
                    $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}]"));

        public async Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await
                GetEnumerableAsync<T>(tableInfoResult,
                     $"SELECT * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));

        private async Task<IEnumerable<T>> GetEnumerableAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.Run(async () =>
            {
                string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
                RunQueryResult runQuery = await _queryBase.RunQueryAsync(connectionString, query);

                return runQuery.QueryStatus switch
                {
                    QueryStatus.Success => await _dataTableMapper.MapListAsync<T>(runQuery.DataTable),

                    _ => null
                };

            });

        public async Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo)
            => await Task.Run(async () =>
            {
                string query = $"SELECT ISNULLABLE as Nullable,DATATYPE as Type,Column_name as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = _queryBase.RunQuery(dbConnectionInfo.GetConnectionString(), query);

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

            RunQueryResult queryResult = _queryBase.RunQuery(dbConnectionInfo.GetConnectionString(), query);

            QueryStatus status = queryResult.QueryStatus;

            return status switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<TableColumns>(queryResult.DataTable),

                _ => null
            };
        }
    }
}
