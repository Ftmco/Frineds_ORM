using FTeam.Orm.Domains.Connection.SqlServer;
using FTeam.Orm.Models.Connection.Shared;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.ConnectionBase
{
    public interface IConnectionBase
    {
        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Task <see cref="OpenConnectionResult"/></returns>
        Task<OpenConnectionResult> TryOpenConnectionAsync(string connectionString);

        Task<OpenConnectionResult> OpenConnectionAsync(string connectionString);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns><see cref="OpenConnectionResult"/></returns>
        OpenConnectionResult TryOpenConnection(string connectionString);

        OpenConnectionResult OpenConnection(string connectionString);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns>Task <see cref="OpenConnectionResult"/></returns>
        Task<OpenConnectionResult> TryOpenConnectionAsync(SqlConnection sqlConnection);

        Task<OpenConnectionResult> OpenConnectionAsync(SqlConnection sqlConnection);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns><see cref="OpenConnectionResult"/></returns>
        OpenConnectionResult TryOpenConnection(SqlConnection sqlConnection);

        OpenConnectionResult OpenConnection(SqlConnection sqlConnection);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Task <see cref="CloseConnectionResult"/></returns>
        Task<CloseConnectionResult> TryCloseConnectionAsync(string connectionString);

        Task<CloseConnectionResult> CloseConnectionAsync(string connectionString);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns><see cref="CloseConnectionResult"/></returns>
        CloseConnectionResult TryCloseConnection(string connectionString);

        CloseConnectionResult CloseConnection(string connectionString);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns>Task <see cref="CloseConnectionResult"/></returns>
        Task<CloseConnectionResult> TryCloseConnectionAsync(SqlConnection sqlConnection);

        Task<CloseConnectionResult> CloseConnectionAsync(SqlConnection sqlConnection);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns><see cref="CloseConnectionResult"/></returns>
        CloseConnectionResult TryCloseConnection(SqlConnection sqlConnection);

        CloseConnectionResult CloseConnection(SqlConnection sqlConnection);
    }
}
