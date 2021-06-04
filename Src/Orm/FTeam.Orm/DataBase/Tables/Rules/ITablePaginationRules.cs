using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITablePaginationRules
    {
        IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult,string orderColumn, int index , int count );

        IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult,string orderColumn, int index , int count );

        IEnumerable<T> TryGetAll<T>(TableInfoResult tableInfoResult, string query,string orderColumn, int index , int count );

        IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query,string orderColumn, int index , int count );

        Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult,string orderColumn, int index , int count );

        Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult,string orderColumn, int index , int count );

        Task<IEnumerable<T>> TryGetAllAsync<T>(TableInfoResult tableInfoResult, string query,string orderColumn, int index , int count );

        Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query,string orderColumn, int index , int count );
    }
}
