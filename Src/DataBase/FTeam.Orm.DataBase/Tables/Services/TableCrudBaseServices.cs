using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableCrudBaseServices : ITableCrudBase
    {
        #region :: Dependency ::

        private readonly IQueryBase _queryBase;

        private readonly IDataTableMapper _dataTableMapper;

        #endregion

        public IEnumerable<T> GetAllBase<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<T>(runQuery.DataTable),

                _ => null
            };
        }

        public async Task<IEnumerable<T>> GetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query)
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

        public T GetBase<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.Map<T>(runQuery.DataTable),

                _ => default
            };
        }

        public async Task<T> GetBaseAsync<T>(TableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.RunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapAsync<T>(runQuery.DataTable),

                     _ => default
                 };
             });
    }
}
