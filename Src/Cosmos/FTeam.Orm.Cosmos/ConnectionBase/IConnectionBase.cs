using FTeam.Orm.Results.Connection;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.ConnectionBase
{
    public interface IConnectionBase
    {
        Task<OpenConnectionResult> OpenConnectionAsync(string connectionString);

        Task<CloseConnectionResult> CloseConnectionAsync(string connectionString);
    }
}
