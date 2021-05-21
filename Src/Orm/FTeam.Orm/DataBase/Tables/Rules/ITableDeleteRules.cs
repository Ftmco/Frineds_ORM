using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableDeleteRules
    {
        Task<QueryStatus> TryDeleteAsync<T>(TableInfoResult tableInfo, T instance);

        Task<QueryStatus> DeleteAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus TryDelete<T>(TableInfoResult tableInfo, T instance);

        QueryStatus Delete<T>(TableInfoResult tableInfo, T instance);

        Task<IEnumerable<QueryStatus>> TryDeleteRangeAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        Task<IEnumerable<QueryStatus>> DeleteRangeAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        IEnumerable<QueryStatus> TryDeleteRange<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        IEnumerable<QueryStatus> DeleteRange<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
    }
}
