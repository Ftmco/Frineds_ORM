using FTeam.Orm.Attributes;
using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        #region --:: Table Columns Services ::--

        public async Task<IEnumerable<TableColumns>> TryGetTableColumnsAsync(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo)
            => await Task.Run(async () =>
            {
                string query = $"SELECT IS_NULLABLE as Nullable,DATA_TYPE as Type,Column_name as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.TryRunQueryAsync(SqlServerDbConnectionInfo.GetConnectionString(), query);

                QueryStatus status = queryResult.QueryStatus;

                return status switch
                {
                    QueryStatus.Success => await _dataTableMapper.MapListAsync<TableColumns>(queryResult.DataTable),

                    _ => null
                };
            });

        public IEnumerable<TableColumns> TryGetTableColumns(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo)
        {
            string query = $"SELECT IS_NULLABLE as [Nullable],DATA_TYPE as [Type],COLUMN_NAME as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME =  '{tableName}'";

            RunQueryResult queryResult = _queryBase.TryRunQuery(SqlServerDbConnectionInfo.GetConnectionString(), query);

            QueryStatus status = queryResult.QueryStatus;

            return status switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<TableColumns>(queryResult.DataTable),

                _ => null
            };
        }

        public IEnumerable<TableColumns> GetTableColumns(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo)
        {
            try
            {
                string query = $"SELECT ISNULLABLE as Nullable,DATATYPE as Type,Column_name as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = _queryBase.RunQuery(SqlServerDbConnectionInfo.GetConnectionString(), query);

                return _dataTableMapper.MapList<TableColumns>(queryResult.DataTable);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo)
        => await Task.Run(async () =>
        {
            try
            {
                string query = $"SELECT ISNULLABLE as Nullable,DATATYPE as Type,Column_name as [Column] FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                RunQueryResult queryResult = await _queryBase.RunQueryAsync(SqlServerDbConnectionInfo.GetConnectionString(), query);

                return await _dataTableMapper.MapListAsync<TableColumns>(queryResult.DataTable);
            }
            catch
            {
                throw;
            }
        });

        #endregion

        #region --:: Table Primary Key Services ::--

        public async Task<PrimaryKey> TryGetTablePrimaryKeyAsync<T>()
            => await Task.Run(async () =>
            {
                try
                {
                    return await GetTablePrimaryKeyAsync<T>();
                }
                catch
                {
                    return default;
                }
            });

        public async Task<PrimaryKey> GetTablePrimaryKeyAsync<T>()
            => await Task.Run(() => GetTablePrimaryKey<T>());

        public PrimaryKey TryGetTablePrimaryKey<T>()
        {
            try
            {
                return GetTablePrimaryKey<T>();
            }
            catch
            {
                return default;
            }
        }

        public PrimaryKey GetTablePrimaryKey<T>()
            => GetTablePrimaryKey(typeof(T));

        public async Task<PrimaryKey> TryGetTablePrimaryKeyAsync(TableInfo tableInfo)
            => await Task.Run(() => TryGetTablePrimaryKey(tableInfo));

        public async Task<PrimaryKey> GetTablePrimaryKeyAsync(TableInfo tableInfo)
            => await Task.Run(() => GetTablePrimaryKey(tableInfo));

        public PrimaryKey TryGetTablePrimaryKey(TableInfo tableInfo)
            => TryGetTablePrimaryKey(tableInfo.TableType);

        public PrimaryKey GetTablePrimaryKey(TableInfo tableInfo)
            => GetTablePrimaryKey(tableInfo.TableType);

        public async Task<PrimaryKey> TryGetTablePrimaryKeyAsync(Type tableType)
            => await Task.Run(() => TryGetTablePrimaryKey(tableType));

        public async Task<PrimaryKey> GetTablePrimaryKeyAsync(Type tableType)
            => await Task.Run(() => GetTablePrimaryKey(tableType));

        public PrimaryKey TryGetTablePrimaryKey(Type tableType)
        {
            try
            {
                return GetTablePrimaryKey(tableType);
            }
            catch
            {
                return default;
            }
        }

        public PrimaryKey GetTablePrimaryKey(Type tableType)
        {
            PropertyInfo[] tableProperties = tableType.GetProperties();
            PropertyInfo primaryKey = tableProperties.FirstOrDefault(tp => tp.GetCustomAttribute(typeof(FKey)) != null);
            if (primaryKey != null)
                return new PrimaryKey
                {
                    Column = primaryKey.Name,
                    Type = primaryKey.PropertyType.ToString()
                };
            throw new NullReferenceException();
        }

        #endregion
    }
}
