using FTeam.Orm.Models;
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
        Task<OpenConnectionResult> OpenConnectionAsync(string connectionString);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns><see cref="OpenConnectionResult"/></returns>
        OpenConnectionResult OpenConnection(string connectionString);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns>Task <see cref="OpenConnectionResult"/></returns>
        Task<OpenConnectionResult> OpenConnectionAsync(SqlConnection sqlConnection);

        /// <summary>
        /// Open Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns><see cref="OpenConnectionResult"/></returns>
        OpenConnectionResult OpenConnection(SqlConnection sqlConnection);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Task <see cref="CloseConnectionResult"/></returns>
        Task<CloseConnectionResult> CloseConnectionAsync(string connectionString);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns><see cref="CloseConnectionResult"/></returns>
        CloseConnectionResult CloseConnection(string connectionString);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns>Task <see cref="CloseConnectionResult"/></returns>
        Task<CloseConnectionResult> CloseConnectionAsync(SqlConnection sqlConnection);

        /// <summary>
        /// Close Data Base Connection
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/></param>
        /// <returns><see cref="CloseConnectionResult"/></returns>
        CloseConnectionResult CloseConnection(SqlConnection sqlConnection);
    }
}
