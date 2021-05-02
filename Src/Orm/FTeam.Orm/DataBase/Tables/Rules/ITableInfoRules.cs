using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInfoRules
    {
        TableInfoResult TryGetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName);

        TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName);

        Task<TableInfoResult> TryGetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName);

        Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName);
    }
}
