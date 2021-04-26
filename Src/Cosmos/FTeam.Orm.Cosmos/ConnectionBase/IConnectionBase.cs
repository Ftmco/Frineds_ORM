using FTeam.Orm.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.ConnectionBase
{
    public interface IConnectionBase
    {
        Task<OpenConnectionResult> OpenConnectionAsync(string connectionString);

        OpenConnectionResult OpenConnection(string connectionString);

        Task<OpenConnectionResult> OpenConnectionAsync(SqlConnection sqlConnection);

        OpenConnectionResult OpenConnection(SqlConnection sqlConnection);

        Task<CloseConnectionResult> CloseConnectionAsync(string connectionString);

        CloseConnectionResult CloseConnection(string connectionString);

        Task<CloseConnectionResult> CloseConnectionAsync(SqlConnection sqlConnection);

        CloseConnectionResult CloseConnection(SqlConnection sqlConnection);
    }
}
