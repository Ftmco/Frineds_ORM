using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableUpdateRules
    {
        Task<QueryStatus> TryUpdatetAsync<T>(TableInfoResult tableInfo, T instance);
        Task<QueryStatus> UpdatetAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus Updatet<T>(TableInfoResult tableInfo, T instance);
        QueryStatus TryUpdatet<T>(TableInfoResult tableInfo, T instance);

        Task<QueryStatus> TryUpdatetAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
        Task<QueryStatus> UpdatetAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        QueryStatus Updatet<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
        QueryStatus TryUpdatet<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
    }
}
