using FTeam.Orm.Results.QueryBase;

namespace FTeam.Orm.Models
{
    public record TableInfoResult
    {
        public QueryStatus Status { get; set; }

        public TableInfo TableInfo { get; set; }

        public DbConnectionInfo DbConnectionInfo { get; set; }

    }
}
