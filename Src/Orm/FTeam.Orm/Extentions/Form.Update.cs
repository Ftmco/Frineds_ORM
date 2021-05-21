using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static partial class Form
    {
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

        #region :: Update List ::

        /// <summary>
        /// Try For Update Object From Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        public static IEnumerable<QueryStatus> TryUpdateRange<T>(this TableInfoResult tableInfo, IEnumerable<T> instances)
          => _tableUpdate.TryUpdatetRange<T>(tableInfo, instances);

        /// <summary>
        /// Update Object From Data Base
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<QueryStatus> UpdateRange<T>(this TableInfoResult tableInfo, IEnumerable<T> instances)
          => _tableUpdate.UpdatetRange<T>(tableInfo, instances);

        /// <summary>
        /// Try For Update Object From Data Base
        /// Use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema Result <see cref="TableInfoResult"/></param>
        /// <param name="instance">TModel Instance</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        public static async Task<IEnumerable<QueryStatus>> TryUpdateRangeAsync<T>(this TableInfoResult tableInfo, IEnumerable<T> instances)
            => await Task.FromResult(await _tableUpdate.TryUpdatetRangeAsync<T>(tableInfo, instances));

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
        public static async Task<IEnumerable<QueryStatus>> UpdateRangeAsync<T>(this TableInfoResult tableInfo, IEnumerable<T> instances)
           => await Task.FromResult(await _tableUpdate.UpdatetRangeAsync<T>(tableInfo, instances));

        #endregion
    }
}
