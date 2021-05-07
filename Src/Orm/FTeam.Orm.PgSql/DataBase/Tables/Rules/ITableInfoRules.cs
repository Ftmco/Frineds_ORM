using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Domains.DataBase.Table.SqlServer;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableInfoRules
    {
        TableInfoResult TryGetTableInfo(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName,Type tableType);

        TableInfoResult GetTableInfo(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> TryGetTableInfoAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName, Type tableType);

        Task<TableInfoResult> GetTableInfoAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName, Type tableType);
    }
}
