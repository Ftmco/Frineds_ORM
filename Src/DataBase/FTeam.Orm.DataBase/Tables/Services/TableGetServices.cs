﻿using FTeam.DependencyController.Kernel;
using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.DataBase.Tables.Services;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public class TableGetServices : ITableGetRules
    {
        #region __Dependency__

        /// <summary>
        /// Friends Dependency Injector Kernel
        /// </summary>
        public static readonly IFkernel _fkernel = new Fkernel();

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

        public TableGetServices()
        {
            RegisterDependency();
            _dataTableMapper = _fkernel.Get<IDataTableMapper>();
            _crudBase = _fkernel.Get<ITableCrudBase>();
            _queryBase = _fkernel.Get<IQueryBase>();
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

                switch (queryResult.QueryStatus)
                {
                    case QueryStatus.Success:
                        return await GetTableInfoResultAsync(dbConnectionInfo, tableName, queryResult);
                    case QueryStatus.Exception:
                        return new TableInfoResult() { TableInfo = null, Status = QueryStatus.Exception };
                    case QueryStatus.InvalidOperationException:
                        return new TableInfoResult { TableInfo = null, Status = QueryStatus.InvalidOperationException };
                    case QueryStatus.SqlException:
                        return new TableInfoResult() { TableInfo = null, Status = QueryStatus.SqlException };
                    case QueryStatus.DbException:
                        return new TableInfoResult() { TableInfo = null, Status = QueryStatus.DbException };
                    default:
                        goto case QueryStatus.Exception;
                }

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
                return tableInfoResult;
            });

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

        public async Task<T> GetAsync<T>(TableInfoResult tableInfoResult, string query)
            => await Task.FromResult(await _crudBase.GetBaseAsync<T>(tableInfoResult,
                $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}"));


        public T Get<T>(TableInfoResult tableInfoResult, string query)
            => _crudBase.GetBase<T>(tableInfoResult,
                 $"SELECT TOP 1 * FROM [{tableInfoResult.TableInfo.Catalog}].[{tableInfoResult.TableInfo.Schema}].[{tableInfoResult.TableInfo.TableName}] WHERE {query}");

        /// <summary>
        /// Register Dependency In FKernel
        /// </summary>
        private static void RegisterDependency()
        {
            _fkernel.Inject<IQueryBase, QueryBase>();
            _fkernel.Inject<IDataTableMapper, DataTableMapper>();
            _fkernel.Inject<ITableCrudBase, TableCrudBaseServices>();
        }
    }
}