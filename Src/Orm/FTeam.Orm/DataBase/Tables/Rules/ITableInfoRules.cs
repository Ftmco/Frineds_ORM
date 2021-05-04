using FTeam.Orm.Domains.Connection;
using FTeam.Orm.Models;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInfoRules
    {
        TableInfoResult TryGetTableInfo(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName,Type tableType);

        TableInfoResult GetTableInfo(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> TryGetTableInfoAsync(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> GetTableInfoAsync(SqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType);
    }
}
