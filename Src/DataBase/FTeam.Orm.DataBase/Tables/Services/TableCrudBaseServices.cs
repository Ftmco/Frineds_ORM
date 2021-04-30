using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableCrudBaseServices : ITableCrudBase
    {
        #region :: Dependency ::

        /// <summary>
        /// Query Base Services
        /// </summary>
        private readonly IQueryBase _queryBase;

        /// <summary>
        /// Data Table Mapper
        /// </summary>
        private readonly IDataTableMapper _dataTableMapper;

        public TableCrudBaseServices()
        {
            _queryBase = new QueryBase();
            _dataTableMapper = new DataTableMapper();
        }

        #endregion

        public IEnumerable<T> TryGetAllBase<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.TryRunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<T>(runQuery.DataTable),

                _ => null
            };
        }

        public async Task<IEnumerable<T>> TryGetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.TryRunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapListAsync<T>(runQuery.DataTable),

                     _ => null
                 };
             });

        public T TryGetBase<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.TryRunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.Map<T>(runQuery.DataTable),

                _ => default
            };
        }

        public async Task<T> TryGetBaseAsync<T>(TableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.TryRunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapAsync<T>(runQuery.DataTable),

                     _ => default
                 };
             });

        public QueryStatus TryCrudBase(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand)
        {
            string connectionString = dbConnectionInfo.GetConnectionString();

            return _queryBase.TryRunVoidQuery(connectionString, sqlCommand);
        }

        public async Task<QueryStatus> TryCrudBaseAsync(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand)
            => await Task.Run(async () =>
            {
                string connectionString = dbConnectionInfo.GetConnectionString();

                return await _queryBase.TryRunVoidQueryAsync(connectionString, sqlCommand);
            });

    }
}
