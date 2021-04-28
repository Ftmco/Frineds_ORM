using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableUpdateServices : ITableUpdateRules
    {
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
