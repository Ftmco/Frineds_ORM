using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static class Form
    {
        public static TableInfoResult Table(this DbConnectionInfo dbConnectionInfo, string tableName)
        {
            return new TableInfoResult();
        }

        public static async Task<TableInfoResult> TableAsync(this DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(() => dbConnectionInfo.Table(tableName));

        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo)
        {

        }

        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo)
        {

        }

        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo, string query)
        {

        }

        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo, string query)
        {

        }

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

        public static QueryStatus Insert<T>(this TableInfoResult tableInfo,T instance)
        {

        }

        public static QueryStatus Update<T>(this TableInfoResult tableInfo, T instance)
        {

        }

        public static QueryStatus Delete<T>(this TableInfoResult tableInfo,T instance)
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
