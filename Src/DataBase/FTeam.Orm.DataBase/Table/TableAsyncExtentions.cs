using FTeam.Orm.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Table
{
    public static class TableAsyncExtentions
    {
        public static Task<DataTable> TableAsync(this ConnectionStringModel connectionString,string tableName)
        {
            throw new Exception();
        } 

        public static Task<IEnumerable<TEntity>> GetAllAasync<TEntity>(this DataTable dataTable)
        {
            throw new Exception();
        }

        public static Task<IEnumerable<TEntity>> GetAllAasync<TEntity>(this DataTable dataTable,string query)
        {
            throw new Exception();
        }

        public static Task<TEntity> GetAsync<TEntity>(this DataTable dataTable)
        {
            throw new Exception();
        }

        public static Task<TEntity> GetAsync<TEntity>(this DataTable dataTable,string query)
        {
            throw new Exception();
        }
    }
}
