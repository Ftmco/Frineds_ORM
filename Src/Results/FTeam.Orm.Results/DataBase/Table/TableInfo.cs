using System;
using System.Collections.Generic;

namespace FTeam.Orm.Domains.DataBase.Table.SqlServer
{
    public record TableInfo
    {
        public string Catalog { get; set; }

        public string Schema { get; set; }

        public string TableName { get; set; }

        public Type TableType { get; set; }

        public PrimaryKey PrimaryKey { get; set; }

        public IEnumerable<TableColumns> TableColumns { get; set; }
    }   
}
