using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableInfoServices : ITableInfoRules
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
        /// Table Comuns Services
        /// </summary>
        private readonly ITableColumnsRules _tableColumns;

        public TableInfoServices()
        {
            _dataTableMapper = new DataTableMapper();
            _queryBase = new QueryBase();
            _tableColumns = new TableColumnsServices();
        }

        #endregion

        public TableInfoResult TryGetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            RunQueryResult queryResult = _queryBase.TryRunQuery(dbConnectionInfo.GetConnectionString(), query);

            return TryReturnResult(queryResult, dbConnectionInfo, tableName);
        }

        private TableInfoResult TryReturnResult(RunQueryResult runQueryResult, DbConnectionInfo dbConnectionInfo, string tableName)
            => runQueryResult.QueryStatus switch
            {
                QueryStatus.Success => TryGetTableInfoResult(dbConnectionInfo, tableName, runQueryResult),

                QueryStatus.Exception => new() { TableInfo = null, Status = QueryStatus.Exception },

                QueryStatus.InvalidOperationException => new() { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                QueryStatus.SqlException => new() { TableInfo = null, Status = QueryStatus.SqlException },

                QueryStatus.DbException => new() { TableInfo = null, Status = QueryStatus.DbException },

                _ => new() { TableInfo = null, Status = QueryStatus.Exception }
            };

        public async Task<TableInfoResult> TryGetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(async () =>
            {
                string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.TryRunQueryAsync(dbConnectionInfo.GetConnectionString(), query);

                //Return Result
                return await TryReturnResultAsync(queryResult, dbConnectionInfo, tableName);
            });

        private async Task<TableInfoResult> TryReturnResultAsync(RunQueryResult runQueryResult, DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(async () =>
             runQueryResult.QueryStatus switch
             {
                 //Success Status
                 //Return Table Info
                 QueryStatus.Success => await TryGetTableInfoResultAsync(dbConnectionInfo, tableName, runQueryResult),

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

        private async Task<TableInfoResult> TryGetTableInfoResultAsync(DbConnectionInfo dbConnectionInfo, string tableName, RunQueryResult queryResult)
            => await Task.Run(async () =>
            {
                TableInfoResult tableInfoResult = new()
                {
                    TableInfo = await _dataTableMapper.MapAsync<TableInfo>(queryResult.DataTable),
                    Status = QueryStatus.Success,
                    DbConnectionInfo = dbConnectionInfo
                };
                tableInfoResult.TableInfo.TableColumns = await _tableColumns.TryGetTableColumnsAsync(tableName, dbConnectionInfo);
                tableInfoResult.TableInfo.PrimaryKey = await _tableColumns.TryGetTablePrimaryKeyAsync(dbConnectionInfo, tableInfoResult);
                return tableInfoResult;
            });

        private TableInfoResult TryGetTableInfoResult(DbConnectionInfo dbConnectionInfo, string tableName, RunQueryResult queryResult)
        {
            TableInfoResult tableInfoResult = new()
            {
                TableInfo = _dataTableMapper.Map<TableInfo>(queryResult.DataTable),
                Status = QueryStatus.Success,
                DbConnectionInfo = dbConnectionInfo
            };
            tableInfoResult.TableInfo.TableColumns = _tableColumns.TryGetTableColumns(tableName, dbConnectionInfo);
            tableInfoResult.TableInfo.PrimaryKey = _tableColumns.TryGetTablePrimaryKey(dbConnectionInfo, tableInfoResult);
            return tableInfoResult;
        }

        public TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            throw new System.NotImplementedException();
        }

        public Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            throw new System.NotImplementedException();
        }
    }
}
