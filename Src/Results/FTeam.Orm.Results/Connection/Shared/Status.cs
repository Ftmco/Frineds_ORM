namespace FTeam.Orm.Models.Connection.Shared
{
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
