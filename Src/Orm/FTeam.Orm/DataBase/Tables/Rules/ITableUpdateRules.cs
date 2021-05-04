using FTeam.Orm.Domains.DataBase.Table.SqlServer;
using FTeam.Orm.Models.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableUpdateRules
    {
        Task<QueryStatus> TryUpdatetAsync<T>(TableInfoResult tableInfo, T instance);

        Task<QueryStatus> UpdatetAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus Updatet<T>(TableInfoResult tableInfo, T instance);

        QueryStatus TryUpdatet<T>(TableInfoResult tableInfo, T instance);
    }
}
