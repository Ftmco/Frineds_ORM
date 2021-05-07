using FTeam.Orm.Domains;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using Npgsql;

namespace FTeam.Orm.PgSql.DataBase.Commands
{
    public interface ICommandRules
    {
        CreateCommandStatus TryGenerateInsertCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand  sqlCommand);

        CreateCommandStatus GenerateInsertCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);

        CreateCommandStatus TryGenerateUpdateCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);

        CreateCommandStatus GenerateUpdateCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);

        CreateCommandStatus TryGenerateDeleteCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);

        CreateCommandStatus GenerateDeleteCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand);
    }
}
