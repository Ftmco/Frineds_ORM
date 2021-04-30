using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableDeleteRules
    {
        Task<QueryStatus> TryDeleteAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus TryDelete<T>(TableInfoResult tableInfo, T instance);
    }
}
