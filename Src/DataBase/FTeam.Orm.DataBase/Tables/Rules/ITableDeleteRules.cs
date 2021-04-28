using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Rules
{
    public interface ITableDeleteRules
    {
        Task<QueryStatus> DeleteAsync<T>(TableInfoResult tableInfo, T instance);

        QueryStatus Delete<T>(TableInfoResult tableInfo, T instance);
    }
}
