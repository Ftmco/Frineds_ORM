using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Domains.DataBase.Table.SqlServer;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableColumnsRules
    {
        Task<PrimaryKey> TryGetTablePrimaryKeyAsync<T>();

        Task<PrimaryKey> TryGetTablePrimaryKeyAsync(TableInfo tableInfo);

        Task<PrimaryKey> TryGetTablePrimaryKeyAsync(Type tableType);

        Task<PrimaryKey> GetTablePrimaryKeyAsync<T>();

        Task<PrimaryKey> GetTablePrimaryKeyAsync(TableInfo tableInfo);

        Task<PrimaryKey> GetTablePrimaryKeyAsync(Type tableType);

        PrimaryKey TryGetTablePrimaryKey<T>();

        PrimaryKey TryGetTablePrimaryKey(TableInfo tableInfo);

        PrimaryKey TryGetTablePrimaryKey(Type tableType);

        PrimaryKey GetTablePrimaryKey<T>();

        PrimaryKey GetTablePrimaryKey(TableInfo tableInfo);

        PrimaryKey GetTablePrimaryKey(Type tableType);

        IEnumerable<TableColumns> TryGetTableColumns(string tableName, PgSqlDbConnectionInfo pgSqlDbConnectionInfo);

        IEnumerable<TableColumns> GetTableColumns(string tableName, PgSqlDbConnectionInfo pgSqlDbConnectionInfo);

        Task<IEnumerable<TableColumns>> TryGetTableColumnsAsync(string tableName, PgSqlDbConnectionInfo pgSqlDbConnectionInfo);

        Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, PgSqlDbConnectionInfo pgSqlDbConnectionInfo);
    }
}
