using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Domains.Connection.SqlServer;
using FTeam.Orm.Domains.DataBase.Table.SqlServer;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableCrudBase
    {
        #region --:: Get Base Services ::--

        IEnumerable<T> TryGetAllBase<T>(TableInfoResult tableInfoResult, string query);

        IEnumerable<T> GetAllBase<T>(TableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> TryGetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> GetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<T> TryGetBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<T> GetBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        T TryGetBase<T>(TableInfoResult tableInfoResult, string query);

        T GetBase<T>(TableInfoResult tableInfoResult, string query);

        #endregion

        #region --:: Insert ::--

        Task<QueryStatus> TryCrudBaseAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, SqlCommand sqlCommand);

        Task<QueryStatus> CrudBaseAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, SqlCommand sqlCommand);

        QueryStatus TryCrudBase(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, SqlCommand sqlCommand);

        QueryStatus CrudBase(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, SqlCommand sqlCommand);

        #endregion

    }
}
