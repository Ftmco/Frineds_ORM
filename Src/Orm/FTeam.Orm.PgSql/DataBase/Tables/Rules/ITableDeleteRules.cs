using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public interface ITableDeleteRules
    {
        Task<QueryStatus> TryDeleteAsync<T>(PgSqlTableInfoResult tableInfo, T instance);

        Task<QueryStatus> DeleteAsync<T>(PgSqlTableInfoResult tableInfo, T instance);

        QueryStatus TryDelete<T>(PgSqlTableInfoResult tableInfo, T instance);

        QueryStatus Delete<T>(PgSqlTableInfoResult tableInfo, T instance);
    }
}
