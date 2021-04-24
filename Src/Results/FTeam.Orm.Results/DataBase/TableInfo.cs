namespace FTeam.Orm.Models
{
    public record TableInfo
    {
        public string Catalog { get; set; }

        public string Schema { get; set; }

        public string TableName { get; set; }
    }
}
