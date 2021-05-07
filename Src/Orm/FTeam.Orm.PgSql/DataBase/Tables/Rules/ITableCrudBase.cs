using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public interface ITableCrudBase
    {
        #region --:: Get Base Services ::--

        IEnumerable<T> TryGetAllBase<T>(PgSqlTableInfoResult tableInfoResult, string query);

        IEnumerable<T> GetAllBase<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> TryGetAllBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> GetAllBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<T> TryGetBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        Task<T> GetBaseAsync<T>(PgSqlTableInfoResult tableInfoResult, string query);

        T TryGetBase<T>(PgSqlTableInfoResult tableInfoResult, string query);

        T GetBase<T>(PgSqlTableInfoResult tableInfoResult, string query);

        #endregion

        #region --:: Insert ::--

        Task<QueryStatus> TryCrudBaseAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand);

        Task<QueryStatus> CrudBaseAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand);

        QueryStatus TryCrudBase(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand);

        QueryStatus CrudBase(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, NpgsqlCommand sqlCommand);

        #endregion

    }
}
