using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableUpdateRules
    {
        Task<QueryStatus> UpdatetAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus Updatet<T>(TableInfoResult tableInfo, T instance);
    }
}
