using FTeam.Orm.Results.QueryBase;

namespace FTeam.Orm.DataBase.Models.Tables
{
    public record TableInfo
    {
        public InformationSchema InformationSchema { get; set; }

        public QueryStatus Status { get; set; }
    }
}
