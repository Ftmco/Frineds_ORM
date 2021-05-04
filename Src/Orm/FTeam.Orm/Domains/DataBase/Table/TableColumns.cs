namespace FTeam.Orm.Domains.DataBase.Table
{
    public record TableColumns
    {
        public bool Nullable { get; set; }

        public string Type { get; set; }

        public string Column { get; set; }
    }
}
