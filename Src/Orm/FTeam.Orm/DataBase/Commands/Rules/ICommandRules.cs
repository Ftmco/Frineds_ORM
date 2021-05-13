using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Commands
{
    public interface ICommandRules
    {
        CreateCommandStatus TryGenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand);
        CreateCommandStatus GenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand);

        CreateCommandStatus TryGenerateUpdateCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand);
        CreateCommandStatus GenerateUpdateCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand);

        CreateCommandStatus TryGenerateDeleteCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand);
        CreateCommandStatus GenerateDeleteCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand);

        Task<IEnumerable<TableColumns>> GetRelasedColumnsAsync<T>(TableInfoResult tableInfo,T instance);
    }
}
