using FTeam.Orm.Domains.DataBase.Table;
using FTeam.Orm.Models.QueryBase;
using FTeam.Orm.Domains.Connection;

namespace FTeam.Orm.Models
{
    public record TableInfoResult
    {
        public QueryStatus Status { get; set; }

        public TableInfo TableInfo { get; set; }

        public SqlServerDbConnectionInfo SqlServerDbConnectionInfo { get; set; }

    }
}
