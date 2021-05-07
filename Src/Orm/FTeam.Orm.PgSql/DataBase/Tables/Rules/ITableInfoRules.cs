using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables
{
    public interface ITableInfoRules
    {
        PgSqlTableInfoResult TryGetTableInfo(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName,Type tableType);

        PgSqlTableInfoResult GetTableInfo(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName, Type tableType);

        Task<PgSqlTableInfoResult> TryGetTableInfoAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName, Type tableType);

        Task<PgSqlTableInfoResult> GetTableInfoAsync(PgSqlDbConnectionInfo PgSqlDbConnectionInfo, string tableName, Type tableType);
    }
}
