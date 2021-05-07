//Friends Sql Orm

namespace FTeam.Orm.Models
{
    /// <summary>
    /// Connection String Data Base Model
    /// </summary>
    public record DbConnectionInfo
    {
        /// <summary>
        /// Data Base Connection Info 
        /// </summary>
        /// <param name="server">Server Address</param>
        /// <param name="dataBase">Data Base Name</param>
        /// <param name="authentication">Authentication Type</param>
        /// <param name="dataBaseType">Data Base Type</param>
        /// <param name="userId">Login User Id</param>
        /// <param name="password">Password</param>
        /// <param name="port">Data Base Port</param>
        public DbConnectionInfo(string server, string dataBase, Authentication authentication, DataBaseType dataBaseType, string userId = null, string password = null, string port = "")
        {
            Server = server;
            DataBaseName = dataBase;
            UserId = userId;
            Password = password;
            Authentication = authentication;
            Port = port;
            DataBaseType = dataBaseType;
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
        /// Data Base Port
        /// </summary>
        public string Port { get; }

        /// <summary>
        /// Authentication Type
        /// </summary>
        public Authentication Authentication { get; }

        /// <summary>
        /// Data Base Type
        /// </summary>
        public DataBaseType DataBaseType { get; set; }
    }
}
