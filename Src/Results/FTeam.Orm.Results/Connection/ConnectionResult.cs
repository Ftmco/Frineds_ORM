using System.Data.SqlClient;

namespace FTeam.Orm.Models
{

    /// <summary>
    /// Open Sql Connection Result
    /// </summary>
    public record OpenConnectionResult
    {
        /// <summary>
        /// SqlConnection Model
        /// </summary>
        public SqlConnection SqlConnection { get; set; }

        /// <summary>
        /// Connection Status
        /// </summary>
        public OpenConnectionStatus ConnectionStatus { get; set; }
    }

    public enum OpenConnectionStatus
    {
        Success,
        Exception,
        InvalidOperationException,
        SqlException
    }

    public enum CloseConnectionResult
    {
        Success,
        Exception,
        SqlException
    }
}
