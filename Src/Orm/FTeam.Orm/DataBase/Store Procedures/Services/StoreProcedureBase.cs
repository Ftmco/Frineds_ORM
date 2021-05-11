using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.StoreProcedures
{
    public class StoreProcedureBase : IStoreProcedureBase
    {
        public Task<IEnumerable<T>> ExecStoreProcedureAsync<T>(object inputs)
        {
            throw new System.NotImplementedException();
        }
    }
}
