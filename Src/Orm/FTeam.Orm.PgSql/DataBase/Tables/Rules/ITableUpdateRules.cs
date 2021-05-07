using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public interface ITableUpdateRules
    {
        Task<QueryStatus> TryUpdatetAsync<T>(PgSqlTableInfoResult tableInfo, T instance);

        Task<QueryStatus> UpdatetAsync<T>(PgSqlTableInfoResult tableInfo, T instance);

        QueryStatus Updatet<T>(PgSqlTableInfoResult tableInfo, T instance);

        QueryStatus TryUpdatet<T>(PgSqlTableInfoResult tableInfo, T instance);
    }
}
