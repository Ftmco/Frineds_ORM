using FTeam.Orm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITableGetRules
    {
        Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName);

        TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName);

        IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult);

        IEnumerable<T> GetAll<T>(TableInfoResult tableInfoResult, string query);

        Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult);

        Task<IEnumerable<T>> GetAllAsync<T>(TableInfoResult tableInfoResult, string query);

        Task<IEnumerable<TableColumns>> GetTableColumnsAsync(string tableName, DbConnectionInfo dbConnectionInfo);

        IEnumerable<TableColumns> GetTableColumns(string tableName, DbConnectionInfo dbConnectionInfo);

        Task<T> GetAsync<T>(TableInfoResult tableInfoResult, string query);

        T Get<T>(TableInfoResult tableInfoResult, string query);

    }
}
