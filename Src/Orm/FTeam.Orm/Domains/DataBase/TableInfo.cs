using System;
using System.Collections.Generic;

namespace FTeam.Orm.Models
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

    public record PrimaryKey
    {
        public string Column { get; set; }

        public string Type { get; set; }
    }

    public record TableColumns
    {
        public string Nullable { get; set; }

        public string Type { get; set; }

        public string Column { get; set; }
    }

    public record TableLastId
    {
        public int Id { get; set; }
    }
}
