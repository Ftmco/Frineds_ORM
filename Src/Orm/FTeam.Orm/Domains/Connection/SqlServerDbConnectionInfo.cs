//Friends Sql Orm

namespace FTeam.Orm.Domains.Connection
{
    /// <summary>
    /// Connection String Data Base Model
    /// </summary>
    public record SqlServerDbConnectionInfo
    {
        /// <summary>
        /// Data Base Connection Info 
        /// </summary>
        /// <param name="server">Server Address</param>
        /// <param name="dataBase">Data Base Name</param>
        /// <param name="authentication">Authentication Type</param>
        /// <param name="userId">Login User Id</param>
        /// <param name="password">Password</param>
        public SqlServerDbConnectionInfo(string server, string dataBase, Authentication authentication, string userId = null, string password = null)
        {
            Server = server;
            DataBaseName = dataBase;
            UserId = userId;
            Password = password;
            Authentication = authentication;
        }

        /// <summary>
        /// Server Name
        /// </summary>
        public string Server { get; }

        /// <summary>
        /// Data Base Name
        /// </summary>
        public string DataBaseName { get; }

        /// <summary>
        /// Login User Name 
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Authentication Type
        /// </summary>
        public Authentication Authentication { get; }
    }


}
