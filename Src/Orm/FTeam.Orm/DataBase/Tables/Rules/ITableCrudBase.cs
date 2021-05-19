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

        #region --:: Crud Base ::--

        Task<QueryStatus> TryCrudBaseAsync(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand);

        Task<QueryStatus> CrudBaseAsync(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand);

        QueryStatus TryCrudBase(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand);

        QueryStatus CrudBase(DbConnectionInfo dbConnectionInfo, SqlCommand sqlCommand);

        #endregion

        #region --:: Crud Base List ::--

        Task<QueryStatus> TryCrudBaseAsync(DbConnectionInfo dbConnectionInfo, IEnumerable<SqlCommand> sqlCommands);

        Task<QueryStatus> CrudBaseAsync(DbConnectionInfo dbConnectionInfo, IEnumerable<SqlCommand> sqlCommands);

        QueryStatus TryCrudBase(DbConnectionInfo dbConnectionInfo, IEnumerable<SqlCommand> sqlCommands);

        QueryStatus CrudBase(DbConnectionInfo dbConnectionInfo, IEnumerable<SqlCommand> sqlCommands);

        #endregion
    }
}
