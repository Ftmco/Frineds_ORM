using FTeam.Orm.DataBase.Tables;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static class Form
    {
        private static readonly ITableRules _table = new TableServices();

        public static TableInfoResult Table(this DbConnectionInfo dbConnectionInfo, string tableName)
            => _table.GetTableInfo(dbConnectionInfo, tableName);

        public static async Task<TableInfoResult> TableAsync(this DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.FromResult(await _table.GetTableInfoAsync(dbConnectionInfo, tableName));

        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo)
            => await Task.FromResult(await _table.GetAllAsync<T>(tableInfo));

        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo)
            => _table.GetAll<T>(tableInfo);

        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo, string query)
            => await Task.FromResult(await _table.GetAllAsync<T>(tableInfo, query));

        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo, string query)
            => _table.GetAll<T>(tableInfo, query);

        public static async Task<T> GetAsync<T>(this TableInfoResult tableInfo, string query)
        {

        }

        public static T Get<T>(this TableInfoResult tableInfo, string query)
        {

        }

        public static async Task<T> GetAsync<T>(this TableInfoResult tableInfo)
        {

        }

        public static T Get<T>(this TableInfoResult tableInfo)
        {

        }

        public static QueryStatus Insert<T>(this TableInfoResult tableInfo, T instance)
        {

        }

        public static QueryStatus Update<T>(this TableInfoResult tableInfo, T instance)
        {

        }

        public static QueryStatus Delete<T>(this TableInfoResult tableInfo, T instance)
        {

        }

        public static Task<QueryStatus> InsertAsync<T>(this TableInfoResult tableInfo, T instance)
        {

        }

        public static Task<QueryStatus> UpdateAsync<T>(this TableInfoResult tableInfo, T instance)
        {

        }

        public static Task<QueryStatus> DeleteAsync<T>(this TableInfoResult tableInfo, T instance)
        {

        }
    }
}
