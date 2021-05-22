using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
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

        IEnumerable<CreateCommandStatus> TryGenerateInsertCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand);

        IEnumerable<CreateCommandStatus> GenerateInsertCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand);

        IEnumerable<CreateCommandStatus> TryGenerateUpdateCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand);

        IEnumerable<CreateCommandStatus> GenerateUpdateCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand);

        IEnumerable<CreateCommandStatus> TryGenerateDeleteCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand);

        IEnumerable<CreateCommandStatus> GenerateDeleteCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand);

        Task<IEnumerable<TableColumns>> GetRelasedColumnsAsync<T>(TableInfoResult tableInfo, T instance);

        void SetValueForPrimaryKey<T>(ref PropertyInfo key, T instance,TableInfoResult tableInfo);

        int GetPrimaryKeyInt(TableInfoResult tableInfo);

        void ReleaseQuery(ref string query,TableInfoResult tableInfo);
    }
}
