using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public interface ITablePrimaryKeyRules
    {
        Task<PrimaryKey> TryGetTablePrimaryKeyAsync(DbConnectionInfo dbConnectionInfo, TableInfoResult tableInfoResult);

        PrimaryKey TryGetTablePrimaryKey(DbConnectionInfo dbConnectionInfo, TableInfoResult tableInfoResult);
    }
}
