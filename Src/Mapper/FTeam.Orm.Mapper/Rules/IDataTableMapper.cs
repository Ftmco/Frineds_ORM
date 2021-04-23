using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FTeam.Orm.Mapper.Rules
{
    public interface IDataTableMapper
    {
        Task<IEnumerable<T>> MapAsync<T>(DataTable dataTable);

        IEnumerable<T> Map<T>(DataTable dataTable);
    }
}
