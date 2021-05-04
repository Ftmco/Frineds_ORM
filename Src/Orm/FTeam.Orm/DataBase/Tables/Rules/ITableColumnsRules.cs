using FTeam.Orm.Domains.DataBase.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FTeam.Orm.Domains.Connection;

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

        IEnumerable<TableColumns> TryGetTableColumns(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo);

        IEnumerable<TableColumns> GetTableColumns(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo);

        Task<IEnumerable<TableColumns>> TryGetTableColumnsAsync(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo);

        Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, SqlServerDbConnectionInfo SqlServerDbConnectionInfo);
    }
}
