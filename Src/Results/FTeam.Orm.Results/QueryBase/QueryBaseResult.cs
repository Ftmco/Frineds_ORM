using System.Data;

namespace FTeam.Orm.Results.QueryBase
{

    /// <summary>
    /// Run Query Result
    /// </summary>
    public record RunQueryResult
    {
        /// <summary>
        /// Data Table Result
        /// </summary>
        public DataTable DataTable { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public QueryStatus QueryStatus { get; set; }
    }

    public enum QueryStatus
    {
        Success,
        Exception,
        InvalidOperationException,
        SqlException,
        DbException
    }
}
