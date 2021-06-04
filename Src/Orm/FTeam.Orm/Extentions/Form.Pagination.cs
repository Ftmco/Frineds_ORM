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
        public static async Task<IEnumerable<T>> TryGetAllAsync<T>(this TableInfoResult tableInfo,string orderColumn, int index = 0, int count = 10)
          => await Task.FromResult(await _tablePagination.TryGetAllAsync<T>(tableInfo,orderColumn, index, count));

        /// <summary>
        /// Get All Items From Table
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo,string orderColumn, int index = 0, int count = 10)
          => await Task.FromResult(await _tablePagination.GetAllAsync<T>(tableInfo, orderColumn, index, count));

        public static IEnumerable<T> TryGetAll<T>(this TableInfoResult tableInfo,string orderColumn, int index = 0, int count = 10)
            => _tablePagination.TryGetAll<T>(tableInfo, orderColumn, index, count);

        /// <summary>
        /// Get All Items From Table
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo,string orderColumn, int index = 0, int count = 10)
           => _tablePagination.GetAll<T>(tableInfo, orderColumn, index, count);

        /// <summary>
        /// Try Get All Items From Table
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        public static async Task<IEnumerable<T>> TryGetAllAsync<T>(this TableInfoResult tableInfo, string query,string orderColumn, int index = 0, int count = 10)
            => await Task.FromResult(await _tablePagination.TryGetAllAsync<T>(tableInfo, query, orderColumn, index, count));

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
        public static async Task<IEnumerable<T>> GetAllAsync<T>(this TableInfoResult tableInfo, string query,string orderColumn, int index = 0, int count = 10)
           => await Task.FromResult(await _tablePagination.GetAllAsync<T>(tableInfo, query, orderColumn, index, count));

        /// <summary>
        /// Try Get All Items From Table
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        public static IEnumerable<T> TryGetAll<T>(this TableInfoResult tableInfo, string query,string orderColumn, int index = 0, int count = 10)
            => _tablePagination.TryGetAll<T>(tableInfo, query, orderColumn, index, count);

        /// <summary>
        /// Get All Items From Table
        /// </summary>
        /// <typeparam name="T">Return Targt Object</typeparam>
        /// <param name="tableInfo">Table Informations Schema <see cref="TableInfoResult"/></param>
        /// <param name="query">Sql Query For Filter Objects</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<T> GetAll<T>(this TableInfoResult tableInfo, string query,string orderColumn, int index = 0, int count = 10)
           => _tablePagination.GetAll<T>(tableInfo, query, orderColumn , index, count);

        #endregion

    }
}
