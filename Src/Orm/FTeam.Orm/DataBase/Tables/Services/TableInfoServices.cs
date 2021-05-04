using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Domains.Connection;
using FTeam.Orm.Domains.DataBase.Table;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
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

        public TableInfoResult TryGetTableInfo(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType)
        {
            string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            RunQueryResult queryResult = _queryBase.TryRunQuery(SqlServerDbConnectionInfo.GetConnectionString(), query);

            return TryReturnResult(queryResult, SqlServerDbConnectionInfo, tableName, tableType);
        }

        private TableInfoResult TryReturnResult(RunQueryResult runQueryResult, SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType)
            => runQueryResult.QueryStatus switch
            {
                QueryStatus.Success => TryGetTableInfoResult(SqlServerDbConnectionInfo, tableName, runQueryResult, tableType),

                QueryStatus.Exception => new() { TableInfo = null, Status = QueryStatus.Exception },

                QueryStatus.InvalidOperationException => new() { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                QueryStatus.SqlException => new() { TableInfo = null, Status = QueryStatus.SqlException },

                QueryStatus.DbException => new() { TableInfo = null, Status = QueryStatus.DbException },

                _ => new() { TableInfo = null, Status = QueryStatus.Exception }
            };

        public async Task<TableInfoResult> TryGetTableInfoAsync(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType)
            => await Task.Run(async () =>
            {
                string query = $"SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.TryRunQueryAsync(SqlServerDbConnectionInfo.GetConnectionString(), query);

                //Return Result
                return await TryReturnResultAsync(queryResult, SqlServerDbConnectionInfo, tableName, tableType);
            });

        private async Task<TableInfoResult> TryReturnResultAsync(RunQueryResult runQueryResult, SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType)
            => await Task.Run(async () =>
             runQueryResult.QueryStatus switch
             {
                 //Success Status
                 //Return Table Info
                 QueryStatus.Success => await TryGetTableInfoResultAsync(SqlServerDbConnectionInfo, tableName, runQueryResult, tableType),

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

        private async Task<TableInfoResult> TryGetTableInfoResultAsync(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, RunQueryResult queryResult, Type tableType)
            => await Task.Run(async () =>
            {
                TableInfoResult tableInfoResult = new()
                {
                    TableInfo = await _dataTableMapper.MapAsync<TableInfo>(queryResult.DataTable),
                    Status = QueryStatus.Success,
                    SqlServerDbConnectionInfo = SqlServerDbConnectionInfo,
                };
                tableInfoResult.TableInfo.TableType = tableType;
                tableInfoResult.TableInfo.TableColumns = await _tableColumns.TryGetTableColumnsAsync(tableName, SqlServerDbConnectionInfo);
                tableInfoResult.TableInfo.PrimaryKey = await _tableColumns.TryGetTablePrimaryKeyAsync(tableInfoResult.TableInfo);
                return tableInfoResult;
            });

        private TableInfoResult TryGetTableInfoResult(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, RunQueryResult queryResult, Type tableType)
        {
            TableInfoResult tableInfoResult = new()
            {
                TableInfo = _dataTableMapper.Map<TableInfo>(queryResult.DataTable),
                Status = QueryStatus.Success,
                SqlServerDbConnectionInfo = SqlServerDbConnectionInfo
            };
            tableInfoResult.TableInfo.TableType = tableType;
            tableInfoResult.TableInfo.TableColumns = _tableColumns.TryGetTableColumns(tableName, SqlServerDbConnectionInfo);
            tableInfoResult.TableInfo.PrimaryKey = _tableColumns.TryGetTablePrimaryKey(tableInfoResult.TableInfo);
            return tableInfoResult;
        }

        public TableInfoResult GetTableInfo(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType)
        {
            string query = $"USE [{SqlServerDbConnectionInfo.DataBaseName}] SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            RunQueryResult queryResult = _queryBase.RunQuery(SqlServerDbConnectionInfo.GetConnectionString(), query);

            return TryReturnResult(queryResult, SqlServerDbConnectionInfo, tableName, tableType);
        }

        public async Task<TableInfoResult> GetTableInfoAsync(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType)
         => await Task.Run(async () =>
         {
             string query = $"USE [{SqlServerDbConnectionInfo.DataBaseName}] SELECT TABLE_NAME as [TableName], TABLE_SCHEMA as [Schema],TABLE_CATALOG as [Catalog] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

             RunQueryResult queryResult = await _queryBase.RunQueryAsync(SqlServerDbConnectionInfo.GetConnectionString(), query);

             //Return Result
             return await TryReturnResultAsync(queryResult, SqlServerDbConnectionInfo, tableName, tableType);
         });
    }
}
