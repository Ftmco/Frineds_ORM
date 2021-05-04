using FTeam.Orm.Models;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInfoRules
    {
        TableInfoResult TryGetTableInfo(SqlServerSqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName,Type tableType);

        TableInfoResult GetTableInfo(SqlServerSqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> TryGetTableInfoAsync(SqlServerSqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> GetTableInfoAsync(SqlServerSqlServerDbConnectionInfo SqlServerDbConnectionInfo, string tableName, Type tableType);
    }
}
