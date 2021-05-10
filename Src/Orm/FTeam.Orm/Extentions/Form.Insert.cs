﻿using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static partial class Form
    {
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
    }
}