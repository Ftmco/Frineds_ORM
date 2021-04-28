using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableCrudServices : ITableInsertRules, ITableDeleteRules, ITableUpdateRules
    {
        public QueryStatus Delete<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> DeleteAsync<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public QueryStatus Insert<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> InsertAsync<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public QueryStatus Updatet<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> UpdatetAsync<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }
    }
}
