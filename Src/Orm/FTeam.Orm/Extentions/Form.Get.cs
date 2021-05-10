using FTeam.Orm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static partial class Form
    {
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
