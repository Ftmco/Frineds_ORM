using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static partial class Form
    {
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
    }
}
