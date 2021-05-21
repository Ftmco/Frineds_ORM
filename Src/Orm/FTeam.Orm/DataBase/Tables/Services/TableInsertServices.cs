using FTeam.Orm.DataBase.Commands;
using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
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
            CreateCommandStatus status = _cmd.GenerateInsertCommand(tableInfo, instance, out SqlCommand command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.CrudBase(tableInfo.DbConnectionInfo, command);
        }

        public IEnumerable<QueryStatus> InsertRange<T>(TableInfoResult tableInfo, IEnumerable<T> instances)
        {
            _cmd.GenerateInsertCommand(tableInfo, instances, out IEnumerable<SqlCommand> command);
            return _tableCrudBase.CrudBase(tableInfo.DbConnectionInfo, command);
        }

        public async Task<QueryStatus> InsertAsync<T>(TableInfoResult tableInfo, T instance)
         => await Task.Run(async () =>
         {
        
             CreateCommandStatus status = _cmd.GenerateInsertCommand(tableInfo, instance, out SqlCommand command);

             return status != CreateCommandStatus.Success ? QueryStatus.Exception :
             await _tableCrudBase.CrudBaseAsync(tableInfo.DbConnectionInfo, command);
         });

        public async Task<IEnumerable<QueryStatus>> InsertRangeAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances)
                  => await Task.Run(async () =>
                  {
                      _cmd.GenerateInsertCommand(tableInfo, instances, out IEnumerable<SqlCommand> command);
                      return await _tableCrudBase.CrudBaseAsync(tableInfo.DbConnectionInfo, command);
                  });

        #endregion

        public QueryStatus TryInsert<T>(TableInfoResult tableInfo, T instance)
        {       
            CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out SqlCommand command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.TryCrudBase(tableInfo.DbConnectionInfo, command);
        }

        public IEnumerable<QueryStatus> TryInsertRange<T>(TableInfoResult tableInfo, IEnumerable<T> instances)
        {
            _cmd.TryGenerateInsertCommand(tableInfo, instances, out IEnumerable<SqlCommand> command);
            return _tableCrudBase.TryCrudBase(tableInfo.DbConnectionInfo, command);
        }

        public async Task<QueryStatus> TryInsertAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {           
                CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out SqlCommand command);

                return status != CreateCommandStatus.Success ? QueryStatus.Exception :
                await _tableCrudBase.TryCrudBaseAsync(tableInfo.DbConnectionInfo, command);
            });

        public async Task<IEnumerable<QueryStatus>> TryInsertRangeAsync<T>(TableInfoResult tableInfo, IEnumerable<T> instances)
            => await Task.Run(async () =>
            {
                _cmd.TryGenerateInsertCommand(tableInfo, instances, out IEnumerable<SqlCommand> command);
                return await _tableCrudBase.TryCrudBaseAsync(tableInfo.DbConnectionInfo, command);
            });
    }
}
