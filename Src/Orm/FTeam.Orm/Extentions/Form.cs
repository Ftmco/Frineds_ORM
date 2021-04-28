using FTeam.Orm.DataBase.Tables;
using FTeam.Orm.DataBase.Tables.Services;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static class Form
    {

        #region --:: Dependencies ::--

        /// <summary>
        /// Table Get Services
        /// </summary>
        private static readonly ITableGetRules _tableGet = new TableGetServices();

        /// <summary>
        /// Table Delete Services
        /// </summary>
        private static readonly ITableDeleteRules _tableDelete = new TableCrudServices();

        /// <summary>
        /// Table Update Services
        /// </summary>
        private static readonly ITableUpdateRules _tableUpdate = new TableCrudServices();

        /// <summary>
        /// Table Insert Services
        /// </summary>
        private static readonly ITableInsertRules _tableInsert = new TableCrudServices();

        #endregion

        #region :: Insert ::

        public static QueryStatus Insert<T>(this TableInfoResult tableInfo, T instance)
           => _tableInsert.Insert<T>(tableInfo, instance);
        public static async Task<QueryStatus> InsertAsync<T>(this TableInfoResult tableInfo, T instance)
           => await Task.FromResult(await _tableInsert.InsertAsync<T>(tableInfo, instance));

        #endregion

        #region :: Delete ::

        public static QueryStatus Delete<T>(this TableInfoResult tableInfo, T instance)
          => _tableDelete.Delete<T>(tableInfo, instance);

        public static async Task<QueryStatus> DeleteAsync<T>(this TableInfoResult tableInfo, T instance)
          => await Task.FromResult(await _tableDelete.DeleteAsync<T>(tableInfo, instance));

        #endregion

        #region :: Update ::

        public static QueryStatus Update<T>(this TableInfoResult tableInfo, T instance)
          => _tableUpdate.Updatet<T>(tableInfo, instance);

        public static async Task<QueryStatus> UpdateAsync<T>(this TableInfoResult tableInfo, T instance)
            => await Task.FromResult(await _tableUpdate.UpdatetAsync<T>(tableInfo, instance));

        #endregion

        #region :: Get List ::

        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo)
          => await Task.FromResult(await _tableGet.GetAllAsync<T>(tableInfo));

        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo)
            => _tableGet.GetAll<T>(tableInfo);

        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo, string query)
            => await Task.FromResult(await _tableGet.GetAllAsync<T>(tableInfo, query));

        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo, string query)
            => _tableGet.GetAll<T>(tableInfo, query);

        #endregion

        #region :: Table :: 

        public static TableInfoResult Table(this DbConnectionInfo dbConnectionInfo, string tableName)
           => _tableGet.GetTableInfo(dbConnectionInfo, tableName);

        public static async Task<TableInfoResult> TableAsync(this DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.FromResult(await _tableGet.GetTableInfoAsync(dbConnectionInfo, tableName));

        #endregion

        #region :: Get ::

        public static async Task<T> GetAsync<T>(this TableInfoResult tableInfo, string query)
          => await Task.FromResult(await _tableGet.GetAsync<T>(tableInfo, query));

        public static T Get<T>(this TableInfoResult tableInfo, string query)
            => _tableGet.Get<T>(tableInfo, query);

        #endregion
    }
}
