using System.Collections.Generic;

namespace FTeam.Orm.Domains.CashVarabiles
{
    public class CacheVariables
    {
        private static IDictionary<string, object> cacheKeys = new Dictionary<string, object>();

        public static IDictionary<string, object> CacheKeys { get => cacheKeys; set => cacheKeys = value; }
    }
}
