using FTeam.Orm.Models;
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

        Task<QueryStatus> TryCrudBaseAsync(DbConnectionInfo dbConnectionInfo, IDbCommand sqlCommand);

        Task<QueryStatus> CrudBaseAsync(DbConnectionInfo dbConnectionInfo, IDbCommand sqlCommand);

        QueryStatus TryCrudBase(DbConnectionInfo dbConnectionInfo, IDbCommand sqlCommand);

        QueryStatus CrudBase(DbConnectionInfo dbConnectionInfo, IDbCommand sqlCommand);

        #endregion

    }
}
