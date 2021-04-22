using FTeam.Orm.DataBase.Models;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table.Services
{
    public partial class TableServices : ITableServices
    {
        public Task<TableInfo> GetTableInfoAsync(DbConnectionInfo dbConnection, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
