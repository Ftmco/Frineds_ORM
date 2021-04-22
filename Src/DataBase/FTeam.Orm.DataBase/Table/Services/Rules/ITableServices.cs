using FTeam.Orm.DataBase.Models;
using FTeam.Orm.DataBase.Models.Tables;
using FTeam.Orm.Results.QueryBase;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table.Services
{
    public interface ITableServices : ITableQuery
    {
        Task<TableInfo> GetTableInfoAsync(DbConnectionInfo dbConnection, string tableName);

        Task<TableInfo> GetTableInfoAsync(RunQueryResult runQueryResult);

        Task<InformationSchema> GetInformationSchemaAsync(TableInfo tableInfo);
    }
}
