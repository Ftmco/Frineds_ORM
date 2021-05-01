using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableColumnsServices : ITableColumnsRules
    {
        #region --:: Dependency ::--

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

        public TableColumnsServices()
        {
            _dataTableMapper = new DataTableMapper();
            _crudBase = new TableCrudBaseServices();
            _queryBase = new QueryBase();
        }


        #endregion

        public PrimaryKey TryGetTablePrimaryKey(DbConnectionInfo dbConnectionInfo, TableInfoResult tableInfoResult)
        {
            string query = $"SELECT COLUMN_NAME AS [Column] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_NAME = '{tableInfoResult.TableInfo.TableName}'";

            RunQueryResult queryResult = _queryBase.TryRunQuery(dbConnectionInfo.GetConnectionString(), query);

            PrimaryKey primaryKey = new();

            switch (queryResult.QueryStatus)
            {
                case QueryStatus.Success:
                    {
                        primaryKey = _dataTableMapper.Map<PrimaryKey>(queryResult.DataTable);
                        if (primaryKey != null)
                            primaryKey.Type = tableInfoResult.TableInfo.TableColumns.FirstOrDefault(p => p.Column == primaryKey.Column).Type;
                        return primaryKey;
                    }
                case QueryStatus.Exception:
                    return primaryKey;

                case QueryStatus.InvalidOperationException:
                    return primaryKey;

                case QueryStatus.SqlException:
                    return primaryKey;

                case QueryStatus.DbException:
                    return primaryKey;

                default:
                    return primaryKey;
            }
        }

        public async Task<PrimaryKey> TryGetTablePrimaryKeyAsync(DbConnectionInfo dbConnectionInfo, TableInfoResult tableInfoResult)
             => await Task.Run(async () =>
             {
                 string query = $"SELECT COLUMN_NAME AS [Column] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_NAME = '{tableInfoResult.TableInfo.TableName}'";

                 RunQueryResult queryResult = await _queryBase.TryRunQueryAsync(dbConnectionInfo.GetConnectionString(), query);

                 PrimaryKey primaryKey = new();

                 switch (queryResult.QueryStatus)
                 {
                     case QueryStatus.Success:
                         {
                             primaryKey = await _dataTableMapper.MapAsync<PrimaryKey>(queryResult.DataTable);
                             if (primaryKey != null)
                                 primaryKey.Type = tableInfoResult.TableInfo.TableColumns.FirstOrDefault(p => p.Column == primaryKey.Column).Type;
                             return primaryKey;
                         }
                     case QueryStatus.Exception:
                         return primaryKey;

                     case QueryStatus.InvalidOperationException:
                         return primaryKey;

                     case QueryStatus.SqlException:
                         return primaryKey;

                     case QueryStatus.DbException:
                         return primaryKey;

                     default:
                         return primaryKey;
                 }
             });

        public async Task<IEnumerable<TableColumns>> TryGetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo)
            => await Task.Run(async () =>
            {
                string query = $"SELECT ISNULLABLE as Nullable,DATATYPE as Type,Column_name as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.TryRunQueryAsync(dbConnectionInfo.GetConnectionString(), query);

                QueryStatus status = queryResult.QueryStatus;

                return status switch
                {
                    QueryStatus.Success => await _dataTableMapper.MapListAsync<TableColumns>(queryResult.DataTable),

                    _ => null
                };
            });

        public IEnumerable<TableColumns> TryGetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo)
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

    }
}
