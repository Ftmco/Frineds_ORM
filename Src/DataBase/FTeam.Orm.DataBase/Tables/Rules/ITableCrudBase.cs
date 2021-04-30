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

        Task<IEnumerable<T>> TryGetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<T> TryGetBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        T TryGetBase<T>(TableInfoResult tableInfoResult, string query);

        #endregion

        #region --:: Insert ::--

        Task<QueryStatus> TryCrudBaseAsync(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand);

        QueryStatus TryCrudBase(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand);

        #endregion

    }
}
