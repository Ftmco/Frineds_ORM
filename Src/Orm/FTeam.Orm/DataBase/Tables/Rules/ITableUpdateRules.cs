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

        Task<IEnumerable<QueryStatus>> TryUpdatetRangeAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        Task<IEnumerable<QueryStatus>> UpdatetRangeAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        IEnumerable<QueryStatus> UpdatetRange<T>(TableInfoResult tableInfo, IEnumerable<T> instances);

        IEnumerable<QueryStatus> TryUpdatetRange<T>(TableInfoResult tableInfo, IEnumerable<T> instances);
    }
}
