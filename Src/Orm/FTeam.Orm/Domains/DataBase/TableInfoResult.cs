using FTeam.Orm.Models.QueryBase;

namespace FTeam.Orm.Models
{
    public record TableInfoResult
    {
        public QueryStatus Status { get; set; }

        public TableInfo TableInfo { get; set; }

        public SqlServerDbConnectionInfo SqlServerDbConnectionInfo { get; set; }

    }
}
