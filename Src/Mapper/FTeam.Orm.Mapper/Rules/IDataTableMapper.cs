using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FTeam.Orm.Mapper.Rules
{
    public interface IDataTableMapper
    {
        Task<IEnumerable<T>> MapListAsync<T>(DataTable dataTable);

        Task<T> MapAsync<T>(DataTable dataTable);

        IEnumerable<T> MapList<T>(DataTable dataTable);

        T Map<T>(DataTable dataTable);
    }
}
