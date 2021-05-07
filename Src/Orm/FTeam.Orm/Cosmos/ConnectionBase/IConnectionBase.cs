using FTeam.Orm.Models;
using System.Data;
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
        /// <param name="sqlConnection"><see cref="IDbConnection"/></param>
        /// <returns>Task <see cref="OpenConnectionResult"/></returns>
        Task<OpenConnectionResult> TryOpenConnectionAsync(IDbConnection sqlConnection);
        Task<OpenConnectionResult> OpenConnectionAsync(IDbConnection sqlConnection);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="IDbConnection"/></param>
        /// <returns><see cref="OpenConnectionResult"/></returns>
        OpenConnectionResult TryOpenConnection(IDbConnection sqlConnection);
        OpenConnectionResult OpenConnection(IDbConnection sqlConnection);

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
        /// <param name="sqlConnection"><see cref="IDbConnection"/></param>
        /// <returns>Task <see cref="CloseConnectionResult"/></returns>
        Task<CloseConnectionResult> TryCloseConnectionAsync(IDbConnection sqlConnection);
        Task<CloseConnectionResult> CloseConnectionAsync(IDbConnection sqlConnection);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="IDbConnection"/></param>
        /// <returns><see cref="CloseConnectionResult"/></returns>
        CloseConnectionResult TryCloseConnection(IDbConnection sqlConnection);
        CloseConnectionResult CloseConnection(IDbConnection sqlConnection);
    }
}
