using FTeam.Orm.Domains.Connection.SqlServer;
using FTeam.Orm.Domains.DataBase.Table.SqlServer;
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
