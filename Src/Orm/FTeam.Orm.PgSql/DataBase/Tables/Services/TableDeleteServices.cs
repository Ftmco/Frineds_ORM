using FTeam.Orm.Domains;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using FTeam.Orm.PgSql.DataBase.Commands;
using Npgsql;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables.Services
{
    public class TableDeleteServices : ITableDeleteRules
    {
        #region --:: Dependency ::--

        private readonly ICommandRules _cmd;

        private readonly ITableCrudBase _crudBase;

        public TableDeleteServices()
        {
            _cmd = new CommandServices();
            _crudBase = new TableCrudBaseServices();
        }

     

        #endregion

        public QueryStatus TryDelete<T>(PgSqlTableInfoResult tableInfo, T instance)
        {
            NpgsqlCommand command = new();

            CreateCommandStatus status = _cmd.TryGenerateDeleteCommand(tableInfo, instance, out command);

            return status == CreateCommandStatus.Success ? _crudBase.TryCrudBase(tableInfo.PgSqlDbConnectionInfo, command)
                : QueryStatus.Exception;
        }

        public async Task<QueryStatus> TryDeleteAsync<T>(PgSqlTableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                NpgsqlCommand command = new();

                CreateCommandStatus status = _cmd.TryGenerateDeleteCommand(tableInfo, instance, out command);

                return status == CreateCommandStatus.Success ? await _crudBase.TryCrudBaseAsync(tableInfo.PgSqlDbConnectionInfo, command)
                : QueryStatus.Exception;
            });

        public QueryStatus Delete<T>(PgSqlTableInfoResult tableInfo, T instance)
        {
            NpgsqlCommand command = new();

            CreateCommandStatus status = _cmd.GenerateDeleteCommand(tableInfo, instance, out command);

            return status == CreateCommandStatus.Success ? _crudBase.CrudBase(tableInfo.PgSqlDbConnectionInfo, command)
                : QueryStatus.Exception;
        }

        public async Task<QueryStatus> DeleteAsync<T>(PgSqlTableInfoResult tableInfo, T instance)
          => await Task.Run(async () =>
          {
              NpgsqlCommand command = new();

              CreateCommandStatus status = _cmd.GenerateDeleteCommand(tableInfo, instance, out command);

              return status == CreateCommandStatus.Success ? await _crudBase.CrudBaseAsync(tableInfo.PgSqlDbConnectionInfo, command)
              : QueryStatus.Exception;
          });
    }
}
