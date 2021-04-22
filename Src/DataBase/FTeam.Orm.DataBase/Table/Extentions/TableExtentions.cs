using FTeam.Orm.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace FTeam.Orm.DataBase.Table
{
    public static class TableExtentions
    {
        public static DataTable Table(this DbConnectionInfo connectionString, string tableName)
        {
            throw new Exception();
        }

        public static IEnumerable<TEntity> GetAll<TEntity>(this TableInfo dataTable)
        {
            throw new Exception();
        }

        public static IEnumerable<TEntity> GetAll<TEntity>(this TableInfo dataTable, string query)
        {
            throw new Exception();
        }

        public static TEntity Get<TEntity>(this TableInfo dataTable)
        {
            throw new Exception();
        }

        public static TEntity Get<TEntity>(this TableInfo dataTable, string query)
        {
            throw new Exception();
        }
    }
}
