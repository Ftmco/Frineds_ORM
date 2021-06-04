using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableCountRules
    {
        Task<int> TryCountAsync(TableInfoResult tableInfo);

        Task<int> CountAsync(TableInfoResult tableInfo);

        int TryCount(TableInfoResult tableInfo);

        int Count(TableInfoResult tableInfo);
    }
}
