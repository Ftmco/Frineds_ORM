using FTeam.Orm.Domains.Connection;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSql.Cosmos.ConnectionBase
{
    public interface IPgSqlConnectionBase
    {
        Task<OpenConnectionResult> OpenConnectionAsync(string connectionString);

        Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString);
    }
}
