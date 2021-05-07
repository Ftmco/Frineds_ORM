using FTeam.Orm.DataBase.Commands;
using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using FTeam.Orm.Models.QueryBase;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableUpdateServices : ITableUpdateRules
    {
        #region --:: Dependency ::--

        /// <summary>
        /// Table Crud Base Services
        /// </summary>
        private readonly ITableCrudBase _tableCrudBase;

        /// <summary>
        /// Sql Command Servcices
        /// </summary>
        private readonly ICommandRules _cmd;

        public TableUpdateServices()
        {
            _tableCrudBase = new TableCrudBaseServices();
            _cmd = new CommandServices();
        }

        #endregion

        public QueryStatus TryUpdatet<T>(TableInfoResult tableInfo, T instance)
        {
            IDbCommand command = new();

            CreateCommandStatus status = _cmd.GenerateUpdateCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.TryCrudBase(tableInfo.DbConnectionInfo, command);
        }

        public async Task<QueryStatus> TryUpdatetAsync<T>(TableInfoResult tableInfo, T instance)
         => await Task.Run(async () =>
         {
             IDbCommand command = new();

             CreateCommandStatus status = _cmd.GenerateUpdateCommand(tableInfo, instance, out command);

             return status != CreateCommandStatus.Success ? QueryStatus.Exception :
             await _tableCrudBase.TryCrudBaseAsync(tableInfo.DbConnectionInfo, command);
         });

        public QueryStatus Updatet<T>(TableInfoResult tableInfo, T instance)
        {
            IDbCommand command = new();

            CreateCommandStatus status = _cmd.GenerateUpdateCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.CrudBase(tableInfo.DbConnectionInfo, command);
        }

        public async Task<QueryStatus> UpdatetAsync<T>(TableInfoResult tableInfo, T instance)
          => await Task.Run(async () =>
          {
              IDbCommand command = new();

              CreateCommandStatus status = _cmd.GenerateUpdateCommand(tableInfo, instance, out command);

              return status != CreateCommandStatus.Success ? QueryStatus.Exception :
              await _tableCrudBase.CrudBaseAsync(tableInfo.DbConnectionInfo, command);
          });
    }
}
