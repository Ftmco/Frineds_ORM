using FTeam.Orm.DataBase.Tables;
using FTeam.Orm.DataBase.Tables.Services;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Data.Common;
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
        private static readonly ITableDeleteRules _tableDelete = new TableDeleteServices();

        /// <summary>
        /// Table Update Services
        /// </summary>
        private static readonly ITableUpdateRules _tableUpdate = new TableUpdateServices();

        /// <summary>
        /// Table Insert Services
        /// </summary>
        private static readonly ITableInsertRules _tableInsert = new TableInsertServices();

        /// <summary>
        /// Table Information Schema Services
        /// </summary>
        private static readonly ITableInfoRules _tableInfo = new TableInfoServices();

        #endregion

        #region :: Insert ::

        /// <summary>
        /// Try For Insert New Instance To Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">Instance Object</param>
        /// <returns><see cref="QueryStatus"/></returns>
        public static QueryStatus TryInsert<T>(this TableInfoResult tableInfo, T instance)
           => _tableInsert.TryInsert<T>(tableInfo, instance);

        /// <summary>
        /// Insert New Instance To Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">Instance Object</param>
        /// <returns><see cref="QueryStatus"/></returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static QueryStatus Insert<T>(this TableInfoResult tableInfo, T instance)
          => _tableInsert.Insert<T>(tableInfo, instance);

        /// <summary>
        /// Try For Insert New Instance To Data Base 
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">Instance Object</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        public static async Task<QueryStatus> TryInsertAsync<T>(this TableInfoResult tableInfo, T instance)
           => await Task.FromResult(await _tableInsert.TryInsertAsync<T>(tableInfo, instance));

        /// <summary>
        /// Insert New Instance To Data Base 
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">Instance Object</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<QueryStatus> InsertAsync<T>(this TableInfoResult tableInfo, T instance)
          => await Task.FromResult(await _tableInsert.InsertAsync<T>(tableInfo, instance));

        #endregion

        #region :: Delete ::

        /// <summary>
        /// Try For Delete Object From Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        public static QueryStatus TryDelete<T>(this TableInfoResult tableInfo, T instance)
          => _tableDelete.TryDelete<T>(tableInfo, instance);

        /// <summary>
        /// Delete Object From Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static QueryStatus Delete<T>(this TableInfoResult tableInfo, T instance)
          => _tableDelete.Delete<T>(tableInfo, instance);

        /// <summary>
        /// Try For Delete Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        public static async Task<QueryStatus> TryDeleteAsync<T>(this TableInfoResult tableInfo, T instance)
          => await Task.FromResult(await _tableDelete.TryDeleteAsync<T>(tableInfo, instance));

        /// <summary>
        /// Delete Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<QueryStatus> DeleteAsync<T>(this TableInfoResult tableInfo, T instance)
         => await Task.FromResult(await _tableDelete.DeleteAsync<T>(tableInfo, instance));

        #endregion

        #region :: Update ::

        /// <summary>
        /// Try For Update Object From Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        public static QueryStatus TryUpdate<T>(this TableInfoResult tableInfo, T instance)
          => _tableUpdate.TryUpdatet<T>(tableInfo, instance);

        /// <summary>
        /// Update Object From Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static QueryStatus Update<T>(this TableInfoResult tableInfo, T instance)
          => _tableUpdate.Updatet<T>(tableInfo, instance);

        /// <summary>
        /// Try For Update Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        public static async Task<QueryStatus> TryUpdateAsync<T>(this TableInfoResult tableInfo, T instance)
            => await Task.FromResult(await _tableUpdate.TryUpdatetAsync<T>(tableInfo, instance));

        /// <summary>
        ///  Update Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<QueryStatus> UpdateAsync<T>(this TableInfoResult tableInfo, T instance)
           => await Task.FromResult(await _tableUpdate.UpdatetAsync<T>(tableInfo, instance));

        #endregion

        #region :: Get List ::

        /// <summary>
        /// Try To Get All Items From Table
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        public static async Task<IEnumerable<T>> TryGetAllAsync<T>(this TableInfoResult tableInfo)
          => await Task.FromResult(await _tableGet.TryGetAllAsync<T>(tableInfo));

        /// <summary>
        /// Get All Items From Table
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo)
          => await Task.FromResult(await _tableGet.GetAllAsync<T>(tableInfo));

        public static IEnumerable<T> TryGetAll<T>(this TableInfoResult tableInfo)
            => _tableGet.TryGetAll<T>(tableInfo);

        /// <summary>
        /// Get All Items From Table
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo)
           => _tableGet.GetAll<T>(tableInfo);

        /// <summary>
        /// Try Get All Items From Table
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        public static async Task<IEnumerable<T>> TryGetAllAsync<T>(this TableInfoResult tableInfo, string query)
            => await Task.FromResult(await _tableGet.TryGetAllAsync<T>(tableInfo, query));

        /// <summary>
        /// Get All Items From Table
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo, string query)
           => await Task.FromResult(await _tableGet.GetAllAsync<T>(tableInfo, query));

        /// <summary>
        /// Try Get All Items From Table
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        public static IEnumerable<T> TryGetAll<T>(this TableInfoResult tableInfo, string query)
            => _tableGet.TryGetAll<T>(tableInfo, query);

        /// <summary>
        /// Get All Items From Table
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo, string query)
           => _tableGet.GetAll<T>(tableInfo, query);

        #endregion

        #region :: Table :: 

        /// <summary>
        /// Try Get <see cref="TableInfoResult"/>
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        public static TableInfoResult TryTable(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
           => _tableInfo.TryGetTableInfo(dbConnectionInfo, tableName, tableType);

        /// <summary>
        /// Get <see cref="TableInfoResult"/>
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static TableInfoResult Table(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
          => _tableInfo.GetTableInfo(dbConnectionInfo, tableName, tableType);

        /// <summary>
        /// Try Get <see cref="TableInfoResult"/>
        /// Use 'await'
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        public static async Task<TableInfoResult> TryTableAsync(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
            => await Task.FromResult(await _tableInfo.TryGetTableInfoAsync(dbConnectionInfo, tableName, tableType));

        /// <summary>
        /// Get <see cref="TableInfoResult"/>
        /// Use 'await'
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<TableInfoResult> TableAsync(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
          => await Task.FromResult(await _tableInfo.GetTableInfoAsync(dbConnectionInfo, tableName, tableType));

        #endregion

        #region :: Get ::

        /// <summary>
        /// Try Get Single Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Result Target Type</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">T-Sql Query</param>
        /// <returns>Task <typeparamref name="T"/></returns>
        public static async Task<T> TryGetAsync<T>(this TableInfoResult tableInfo, string query)
          => await Task.FromResult(await _tableGet.TryGetAsync<T>(tableInfo, query));

        /// <summary>
        /// Get Single Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Result Target Type</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">T-Sql Query</param>
        /// <returns>Task <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<T> GetAsync<T>(this TableInfoResult tableInfo, string query)
         => await Task.FromResult(await _tableGet.GetAsync<T>(tableInfo, query));

        /// <summary>
        /// Try Get Single Object From Data Base
        /// </summary>
        /// <typeparam name="T">Result Target Type</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">T-Sql Query</param>
        /// <returns>Task <typeparamref name="T"/></returns>
        public static T TryGet<T>(this TableInfoResult tableInfo, string query)
            => _tableGet.TryGet<T>(tableInfo, query);

        /// <summary>
        /// Get Single Object From Data Base
        /// </summary>
        /// <typeparam name="T">Result Target Type</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">T-Sql Query</param>
        /// <returns>Task <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static T Get<T>(this TableInfoResult tableInfo, string query)
          => _tableGet.Get<T>(tableInfo, query);

        #endregion
    }
}
