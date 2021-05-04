using FTeam.Orm.Models.QueryBase;
using FTeam.Orm.Domains.Connection.SqlServer;

namespace FTeam.Orm.Domains.DataBase.Table.SqlServer
{
    public record TableInfoResult
    {
        public QueryStatus Status { get; set; }

        public TableInfo TableInfo { get; set; }

        public SqlServerDbConnectionInfo SqlServerDbConnectionInfo { get; set; }

    }
}
