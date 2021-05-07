using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using FTeam.Orm.PgSql.Cosmos.QueryBase;
using FTeam.Orm.PgSql.DataBase.Extentions;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables.Services
{
    public class TableCrudBaseServices : ITableCrudBase
    {
        #region :: Dependency ::

        /// <summary>
        /// Query Base Services
        /// </summary>
        private readonly IPgSqlQueryBase _queryBase;

        /// <summary>
        /// Data Table Mapper
        /// </summary>
        private readonly IDataTableMapper _dataTableMapper;

        public TableCrudBaseServices()
        {
            _queryBase = new PgSqlQueryBase();
            _dataTableMapper = new DataTableMapper();
        }

        #endregion

        public IEnumerable<T> TryGetAllBase<T>(PgSqlTableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.TryRunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<T>(runQuery.DataTable),

                _ => null
            };
        }

        public async Task<IEnumerable<T>> TryGetAllBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.TryRunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapListAsync<T>(runQuery.DataTable),

                     _ => null
                 };
             });

        public T TryGetBase<T>(PgSqlTableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.TryRunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.Map<T>(runQuery.DataTable),

                _ => default
            };
        }

        public async Task<T> TryGetBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.TryRunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapAsync<T>(runQuery.DataTable),

                     _ => default
                 };
             });

        public QueryStatus TryCrudBase(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand)
        {
            string connectionString = PgSqlDbConnectionInfo.GetConnectionString();

            return _queryBase.TryRunVoidQuery(connectionString, sqlCommand);
        }

        public async Task<QueryStatus> TryCrudBaseAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand)
            => await Task.Run(async () =>
            {
                string connectionString = PgSqlDbConnectionInfo.GetConnectionString();

                return await _queryBase.TryRunVoidQueryAsync(connectionString, sqlCommand);
            });

        public IEnumerable<T> GetAllBase<T>(PgSqlTableInfoResult tableInfoResult, string query)
        {
            try
            {
                string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
                RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);
                return _dataTableMapper.MapList<T>(runQuery.DataTable);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
         => await Task.Run(async () =>
         {
             try
             {
                 string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.RunQueryAsync(connectionString, query);

                 return await _dataTableMapper.MapListAsync<T>(runQuery.DataTable);
             }
             catch
             {
                 throw;
             }
         });

        public async Task<T> GetBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query)
         => await Task.Run(async () =>
         {
             try
             {
                 string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.RunQueryAsync(connectionString, query);

                 return await _dataTableMapper.MapAsync<T>(runQuery.DataTable);
             }
             catch
             {
                 throw;
             }
         });

        public T GetBase<T>(PgSqlTableInfoResult tableInfoResult, string query)
        {
            try
            {
                string connectionString = tableInfoResult.PgSqlDbConnectionInfo.GetConnectionString();
                RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);

                return _dataTableMapper.Map<T>(runQuery.DataTable);
            }
            catch
            {
                throw;
            }
        }

        public async Task<QueryStatus> CrudBaseAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand)
        => await Task.Run(async () =>
        {
            try
            {
                string connectionString = PgSqlDbConnectionInfo.GetConnectionString();

                return await _queryBase.RunVoidQueryAsync(connectionString, sqlCommand);
            }
            catch
            {
                throw;
            }
        });

        public QueryStatus CrudBase(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand)
        {
            try
            {
                string connectionString = PgSqlDbConnectionInfo.GetConnectionString();

                return _queryBase.RunVoidQuery(connectionString, sqlCommand);
            }
            catch
            {
                throw;
            }
        }
    }
}
