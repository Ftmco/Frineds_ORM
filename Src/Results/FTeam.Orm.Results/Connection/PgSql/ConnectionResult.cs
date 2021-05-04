using FTeam.Orm.Models.Connection.Shared;
using Npgsql;

namespace FTeam.Orm.Domains.Connection.PgSql
{

    /// <summary>
    /// Open Sql Connection Result
    /// </summary>
    public record OpenConnectionResult
    {
        /// <summary>
        /// SqlConnection Model
        /// </summary>
        public NpgsqlConnection SqlConnection { get; set; }

        /// <summary>
        /// Connection Status
        /// </summary>
        public OpenConnectionStatus ConnectionStatus { get; set; }
    }
}
