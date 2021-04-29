using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableColumnsRules
    {
        Task<PrimaryKey> TryGetTablePrimaryKeyAsync(DbConnectionInfo dbConnectionInfo, TableInfoResult tableInfoResult);

        PrimaryKey TryGetTablePrimaryKey(DbConnectionInfo dbConnectionInfo, TableInfoResult tableInfoResult);

        IEnumerable<TableColumns> GetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo);

        Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo)
    }
}
