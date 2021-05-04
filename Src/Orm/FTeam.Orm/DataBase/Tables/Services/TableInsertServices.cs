﻿using FTeam.Orm.DataBase.Commands;
using FTeam.Orm.Domains;
using FTeam.Orm.Domains.DataBase.Table.SqlServer;
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
            SqlCommand command = new();

            CreateCommandStatus status = _cmd.GenerateInsertCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.CrudBase(tableInfo.SqlServerDbConnectionInfo, command);
        }

        public async Task<QueryStatus> InsertAsync<T>(TableInfoResult tableInfo, T instance)
         => await Task.Run(async () =>
         {
             SqlCommand command = new();

             CreateCommandStatus status = _cmd.GenerateInsertCommand(tableInfo, instance, out command);

             return status != CreateCommandStatus.Success ? QueryStatus.Exception :
             await _tableCrudBase.CrudBaseAsync(tableInfo.SqlServerDbConnectionInfo, command);
         });

        #endregion

        public QueryStatus TryInsert<T>(TableInfoResult tableInfo, T instance)
        {
            SqlCommand command = new();

            CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.TryCrudBase(tableInfo.SqlServerDbConnectionInfo, command);
        }

        public async Task<QueryStatus> TryInsertAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                SqlCommand command = new();

                CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out command);

                return status != CreateCommandStatus.Success ? QueryStatus.Exception :
                await _tableCrudBase.TryCrudBaseAsync(tableInfo.SqlServerDbConnectionInfo, command);
            });
    }
}
