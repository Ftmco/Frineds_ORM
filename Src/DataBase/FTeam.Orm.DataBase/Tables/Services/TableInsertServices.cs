using FTeam.Orm.DataBase.Commands;
using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using FTeam.Orm.Models.QueryBase;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableInsertServices : ITableInsertRules
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

        public TableInsertServices()
        {
            _tableCrudBase = new TableCrudBaseServices();
            _cmd = new CommandServices();
        }

        public QueryStatus Insert<T>(TableInfoResult tableInfo, T instance)
        {
            throw new System.NotImplementedException();
        }

        public Task<QueryStatus> InsertAsync<T>(TableInfoResult tableInfo, T instance)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public QueryStatus TryInsert<T>(TableInfoResult tableInfo, T instance)
        {
            SqlCommand command = new();

            CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.TryCrudBase(tableInfo.DbConnectionInfo, command);
        }

        public async Task<QueryStatus> TryInsertAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                SqlCommand command = new();

                CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out command);

                return status != CreateCommandStatus.Success ? QueryStatus.Exception :
                await _tableCrudBase.TryCrudBaseAsync(tableInfo.DbConnectionInfo, command);
            });
    }
}
