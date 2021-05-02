using FTeam.Orm.Models;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInfoRules
    {
        TableInfoResult TryGetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName,Type tableType);

        TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> TryGetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName, Type tableType);
    }
}
