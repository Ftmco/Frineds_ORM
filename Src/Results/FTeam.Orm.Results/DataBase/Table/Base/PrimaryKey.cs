namespace FTeam.Orm.Domains.DataBase.Table.Base
{
    public record PrimaryKey
    {
        public string Column { get; set; }

        public string Type { get; set; }
    }
}
