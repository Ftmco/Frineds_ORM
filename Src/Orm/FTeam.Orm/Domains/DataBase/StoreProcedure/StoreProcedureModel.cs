using System.Collections.Generic;

namespace FTeam.Orm.Domains.DataBase.StoreProcedure
{
    public record StoreProcedureModel
    {
        public string Name { get; set; }

        public IEnumerable<StoreProcedureInputs> Inputs { get; set; }
    }

    public record StoreProcedureInputs
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Nullable { get; set; }

        public bool TypeNullable { get; set; }
    }
}
