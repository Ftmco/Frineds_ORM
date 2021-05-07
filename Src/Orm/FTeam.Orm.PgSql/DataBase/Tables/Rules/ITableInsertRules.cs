using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public interface ITableInsertRules
    {
        /// <summary>
        /// Try Insert Model To Table 
        /// use 'await'
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="PgSqlTableInfoResult"/></param>
        /// <param name="instance">Model Instance</param>
        /// <returns>Task <see cref="QueryStatus"/></returns>
        Task<QueryStatus> TryInsertAsync<T>(PgSqlTableInfoResult tableInfo, T instance);

        Task<QueryStatus> InsertAsync<T>(PgSqlTableInfoResult tableInfo, T instance);

        /// <summary>
        /// Try Insert Model To Table 
        /// </summary>
        /// <typeparam name="T">TModel</typeparam>
        /// <param name="tableInfo">Table Information Schema <see cref="PgSqlTableInfoResult"/></param>
        /// <param name="instance">Model Instance</param>
        /// <returns><see cref="QueryStatus"/></returns>
        QueryStatus TryInsert<T>(PgSqlTableInfoResult tableInfo, T instance);

        QueryStatus Insert<T>(PgSqlTableInfoResult tableInfo, T instance);
    }
}
