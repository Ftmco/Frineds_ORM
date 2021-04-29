using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInsertRules
    {
        Task<QueryStatus> TryInsertAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus TryInsert<T>(TableInfoResult tableInfo, T instance);
    }
}
