using System;

namespace FTeam.Orm.DataBase.Extentions
{
    public class Table
    {
        public static Guid CreateGuidId()
        {
            return Guid.NewGuid();
        }

        public static string CreateStringId()
        {
            return $"{CreateGuidId()}";
        }
    }
}
