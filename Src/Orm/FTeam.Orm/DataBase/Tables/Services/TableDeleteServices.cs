using FTeam.Orm.DataBase.Commands;
using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using FTeam.Orm.Models.QueryBase;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
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

        public QueryStatus TryDelete<T>(TableInfoResult tableInfo, T instance)
        {
            IDbCommand command = new();

            CreateCommandStatus status = _cmd.TryGenerateDeleteCommand(tableInfo, instance, out command);

            return status == CreateCommandStatus.Success ? _crudBase.TryCrudBase(tableInfo.DbConnectionInfo, command)
                : QueryStatus.Exception;
        }

        public async Task<QueryStatus> TryDeleteAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                IDbCommand command = new();

                CreateCommandStatus status = _cmd.TryGenerateDeleteCommand(tableInfo, instance, out command);

                return status == CreateCommandStatus.Success ? await _crudBase.TryCrudBaseAsync(tableInfo.DbConnectionInfo, command)
                : QueryStatus.Exception;
            });

        public QueryStatus Delete<T>(TableInfoResult tableInfo, T instance)
        {
            IDbCommand command = new();

            CreateCommandStatus status = _cmd.GenerateDeleteCommand(tableInfo, instance, out command);

            return status == CreateCommandStatus.Success ? _crudBase.CrudBase(tableInfo.DbConnectionInfo, command)
                : QueryStatus.Exception;
        }

        public async Task<QueryStatus> DeleteAsync<T>(TableInfoResult tableInfo, T instance)
          => await Task.Run(async () =>
          {
              IDbCommand command = new();

              CreateCommandStatus status = _cmd.GenerateDeleteCommand(tableInfo, instance, out command);

              return status == CreateCommandStatus.Success ? await _crudBase.CrudBaseAsync(tableInfo.DbConnectionInfo, command)
              : QueryStatus.Exception;
          });
    }
}
