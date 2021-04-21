using FTeam.Orm.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace FTeam.Orm.DataBase.Table
{
    public static class TableExtentions
    {
        public static DataTable Table(this ConnectionStringModel connectionString, string tableName)
        {
            throw new Exception();
        }

        public static IEnumerable<TEntity> GetAll<TEntity>(this DataTable dataTable)
        {
            throw new Exception();
        }

        public static IEnumerable<TEntity> GetAll<TEntity>(this DataTable dataTable, string query)
        {
            throw new Exception();
        }

        public static TEntity Get<TEntity>(this DataTable dataTable)
        {
            throw new Exception();
        }

        public static TEntity Get<TEntity>(this DataTable dataTable, string query)
        {
            throw new Exception();
        }
    }
}
