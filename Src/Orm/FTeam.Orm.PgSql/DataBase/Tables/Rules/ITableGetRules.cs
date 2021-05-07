using FTeam.Orm.Models.DataBase.Table.PgSql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public interface ITableGetRules
    {
        IEnumerable<T> TryGetAll<T>(PgSqlTableInfoResult tableInfoResult);

        IEnumerable<T> GetAll<T>(PgSqlTableInfoResult tableInfoResult);

        IEnumerable<T> TryGetAll<T>(PgSqlTableInfoResult tableInfoResult, string query);

        IEnumerable<T> GetAll<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> TryGetAllAsync<T>(PgSqlTableInfoResult tableInfoResult);

        Task<IEnumerable<T>> GetAllAsync<T>(PgSqlTableInfoResult tableInfoResult);

        Task<IEnumerable<T>> TryGetAllAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> GetAllAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<T> TryGetAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<T> GetAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        T TryGet<T>(PgSqlTableInfoResult tableInfoResult, string query);

        T Get<T>(PgSqlTableInfoResult tableInfoResult, string query);

    }
}
