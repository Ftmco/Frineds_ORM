using System.Data;

namespace FTeam.Orm.Models
{

    /// <summary>
    /// Open Sql Connection Result
    /// </summary>
    public record OpenConnectionResult
    {
        /// <summary>
        /// IDbConnection Model
        /// </summary>
        public IDbConnection DbConnection { get; set; }

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
