using FTeam.Orm.Models.QueryBase;

namespace FTeam.Orm.Domains.DataBase.Table.Base
{
    public interface ITableInfoResult
    {
        QueryStatus Status { get; set; }

        TableInfo TableInfo { get; set; }
    }
}
