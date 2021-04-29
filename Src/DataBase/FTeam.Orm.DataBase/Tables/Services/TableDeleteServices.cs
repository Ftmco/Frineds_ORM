using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableDeleteServices : ITableDeleteRules
    {
        public QueryStatus Delete<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public Task<QueryStatus> DeleteAsync<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }
    }
}
