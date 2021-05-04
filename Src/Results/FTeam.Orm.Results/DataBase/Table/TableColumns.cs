namespace FTeam.Orm.Domains.DataBase.Table.SqlServer
{
    public record TableColumns
    {
        public bool Nullable { get; set; }

        public string Type { get; set; }

        public string Column { get; set; }
    }
}
