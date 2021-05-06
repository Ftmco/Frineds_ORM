using FTeam.Orm.Domains;
using FTeam.Orm.Domains.DataBase.Table.SqlServer;
using Npgsql;
using System.Data.SqlClient;

namespace FTeam.Orm.DataBase.Commands
{
    public interface ICommandRules
    {
        CreateCommandStatus TryGenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out NpgsqlCommand  sqlCommand);
        CreateCommandStatus GenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);

        CreateCommandStatus TryGenerateUpdateCommand<T>(TableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);
        CreateCommandStatus GenerateUpdateCommand<T>(TableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);

        CreateCommandStatus TryGenerateDeleteCommand<T>(TableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);
        CreateCommandStatus GenerateDeleteCommand<T>(TableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);
    }
}
