using FTeam.Orm.DataBase.Models;
using FTeam.Orm.DataBase.Table.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table
{
    public static class TableAsyncExtentions
    {
        private readonly static ITableServices _tableServices = new TableServices();
                
        public static async Task<TableInfo> TableAsync(this DbConnectionInfo connectionInfo, string tableName)
            => await Task.FromResult(await _tableServices.GetTableInfoAsync(connectionInfo, tableName));

        public static Task<IEnumerable<TEntity>> GetAllAasync<TEntity>(this TableInfo dataTable)
        {
            throw new Exception();
        }

        public static Task<IEnumerable<TEntity>> GetAllAasync<TEntity>(this TableInfo dataTable, string query)
        {
            throw new Exception();
        }

        public static Task<TEntity> GetAsync<TEntity>(this TableInfo dataTable)
        {
            throw new Exception();
        }

        public static Task<TEntity> GetAsync<TEntity>(this TableInfo dataTable, string query)
        {
            throw new Exception();
        }
    }
}
