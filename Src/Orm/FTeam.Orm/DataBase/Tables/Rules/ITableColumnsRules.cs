using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableColumnsRules
    {
        Task<PrimaryKey> TryGetTablePrimaryKeyAsync<T>();

        Task<PrimaryKey> GetTablePrimaryKeyAsync<T>();

        PrimaryKey TryGetTablePrimaryKey<T>();

        PrimaryKey GetTablePrimaryKey<T>();

        IEnumerable<TableColumns> TryGetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo);

        IEnumerable<TableColumns> GetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo);

        Task<IEnumerable<TableColumns>> TryGetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo);

        Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo);
    }
}
