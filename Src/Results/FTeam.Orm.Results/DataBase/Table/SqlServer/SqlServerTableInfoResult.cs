using FTeam.Orm.Domains.Connection.SqlServer;
using FTeam.Orm.Domains.DataBase.Table.Base;
using FTeam.Orm.Models.QueryBase;

namespace FTeam.Orm.Models.DataBase.Table.SqlServer
{
    public record SqlServerTableInfoResult : ITableInfoResult
    {
        public QueryStatus Status { get; set; }

        public TableInfo TableInfo { get; set; }

        public SqlServerDbConnectionInfo SqlServerDbConnectionInfo { get; set; }
    }
}
