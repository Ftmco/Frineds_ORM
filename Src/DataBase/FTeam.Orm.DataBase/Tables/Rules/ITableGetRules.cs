using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableGetRules
    {
        IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult);
        IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult);

        IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult, string query);
        IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult);
        Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult);

        Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult, string query);
        Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<T> TryGetAsync<T>(TableInfoResult tableInfoResult, string query);
        Task<T> GetAsync<T>(TableInfoResult tableInfoResult, string query);

        T TryGet<T>(TableInfoResult tableInfoResult, string query);
        T Get<T>(TableInfoResult tableInfoResult, string query);

    }
}
