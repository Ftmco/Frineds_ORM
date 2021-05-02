using FTeam.Orm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        IEnumerable<TableColumns> TryGetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo);

        IEnumerable<TableColumns> GetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo);

        Task<IEnumerable<TableColumns>> TryGetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo);

        Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo);
    }
}
