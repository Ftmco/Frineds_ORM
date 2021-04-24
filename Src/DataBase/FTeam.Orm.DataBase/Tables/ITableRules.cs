using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableRules
    {
        Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo,string tableName);

        TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName);
    }
}
