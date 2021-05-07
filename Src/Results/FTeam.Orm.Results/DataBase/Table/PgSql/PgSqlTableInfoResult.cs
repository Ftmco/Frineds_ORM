using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.Domains.DataBase.Table.Base;
using FTeam.Orm.Models.QueryBase;

namespace FTeam.Orm.Models.DataBase.Table.PgSql
{
    public record PgSqlTableInfoResult : ITableInfoResult
    {
        public QueryStatus Status { get; set; }

        public TableInfo TableInfo { get; set; }

        public PgSqlDbConnectionInfo PgSqlDbConnectionInfo { get; set; }
    }
}
