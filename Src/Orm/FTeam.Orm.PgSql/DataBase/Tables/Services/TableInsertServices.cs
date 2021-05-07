using FTeam.Orm.Domains;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using FTeam.Orm.Models.QueryBase;
using FTeam.Orm.PgSql.DataBase.Commands;
using Npgsql;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.DataBase.Tables.Services
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

        public QueryStatus Insert<T>(PgSqlTableInfoResult tableInfo, T instance)
        {
            NpgsqlCommand command = new();

            CreateCommandStatus status = _cmd.GenerateInsertCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.CrudBase(tableInfo.PgSqlDbConnectionInfo, command);
        }

        public async Task<QueryStatus> InsertAsync<T>(PgSqlTableInfoResult tableInfo, T instance)
         => await Task.Run(async () =>
         {
             NpgsqlCommand command = new();

             CreateCommandStatus status = _cmd.GenerateInsertCommand(tableInfo, instance, out command);

             return status != CreateCommandStatus.Success ? QueryStatus.Exception :
             await _tableCrudBase.CrudBaseAsync(tableInfo.PgSqlDbConnectionInfo, command);
         });

        #endregion

        public QueryStatus TryInsert<T>(PgSqlTableInfoResult tableInfo, T instance)
        {
            NpgsqlCommand command = new();

            CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out command);

            return status != CreateCommandStatus.Success ? QueryStatus.Exception :
           _tableCrudBase.TryCrudBase(tableInfo.PgSqlDbConnectionInfo, command);
        }

        public async Task<QueryStatus> TryInsertAsync<T>(PgSqlTableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                NpgsqlCommand command = new();

                CreateCommandStatus status = _cmd.TryGenerateInsertCommand(tableInfo, instance, out command);

                return status != CreateCommandStatus.Success ? QueryStatus.Exception :
                await _tableCrudBase.TryCrudBaseAsync(tableInfo.PgSqlDbConnectionInfo, command);
            });
    }
}
