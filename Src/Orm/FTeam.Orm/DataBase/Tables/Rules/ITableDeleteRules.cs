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

        Task<QueryStatus> TryDeleteAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
        Task<QueryStatus> DeleteAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        QueryStatus TryDelete<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
        QueryStatus Delete<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
    }
}
