using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.StoreProcedures
{
    public interface IStoreProcedureBase
    {
        Task<IEnumerable<T>> ExecStoreProcedureAsync<T>(object inputs);
    }
}
