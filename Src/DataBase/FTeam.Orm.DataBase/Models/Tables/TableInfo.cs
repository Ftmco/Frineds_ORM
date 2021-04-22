using FTeam.Orm.Results.Connection;

namespace FTeam.Orm.DataBase.Models.Tables
{
    public record TableInfo
    {
        public InformationSchema InformationSchema { get; set; }

        public OpenConnectionStatus Status { get; set; }
    }
}
