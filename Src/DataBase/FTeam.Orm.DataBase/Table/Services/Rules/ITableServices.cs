using FTeam.Orm.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table.Services
{
    public interface ITableServices : ITableQuery
    {
        Task<TableInfo> GetTableInfoAsync(DbConnectionInfo dbConnection,string tableName);
    }
}
