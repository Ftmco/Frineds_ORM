using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInsertRules
    {
        /// <summary>
        /// Try Insert Model To Table 
        /// use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="TableInfoResult"/></param>
        /// <param name="instance">Model Instance</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        Task<QueryStatus> TryInsertAsync<T>(TableInfoResult tableInfo, T instance);

        /// <summary>
        /// Try Insert Model To Table 
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="TableInfoResult"/></param>
        /// <param name="instance">Model Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        QueryStatus TryInsert<T>(TableInfoResult tableInfo, T instance);
    }
}
