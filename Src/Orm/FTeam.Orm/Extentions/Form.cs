using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Models;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static class Form
    {
        public static TableInfoResult Table(this DbConnectionInfo dbConnectionInfo, string tableName)
        {
            return new TableInfoResult();
        }

        public static async Task<TableInfoResult> TableAsync(this DbConnectionInfo dbConnectionInfo, string tableName)
            => await Task.Run(() => dbConnectionInfo.Table(tableName));

    }
}
