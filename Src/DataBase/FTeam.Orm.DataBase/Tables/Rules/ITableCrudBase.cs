using FTeam.Orm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableCrudBase
    {
        #region --:: Get Base Services ::--

        IEnumerable<T> GetAllBase<T>(TableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> GetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<T> GetBaseAsync<T>(TableInfoResult tableInfoResult, string query);

        T GetBase<T>(TableInfoResult tableInfoResult, string query);

        #endregion
    }
}
