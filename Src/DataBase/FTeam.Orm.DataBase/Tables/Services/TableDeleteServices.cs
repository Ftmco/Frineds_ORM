using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableDeleteServices : ITableDeleteRules
    {
        public QueryStatus TryDelete<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> TryDeleteAsync<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }
    }
}
