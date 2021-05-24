using System;

namespace FTeam.Orm.DataBase.Extentions
{
    public class Table
    {
        public static Guid CreateGuidId() => Guid.NewGuid();

        public static string CreateStringId() => $"{CreateGuidId()}";
    }
}
