//Friends Sql Orm

namespace FTeam.Orm.DataBase.Models
{
    /// <summary>
    /// Connection String Data Base Model
    /// </summary>
    public record DbConnectionInfo
    {
        string _server, _dataBase, _userId, _password = "";
        Authentication _authentication;

        /// <summary>
        /// Data Base Connection Info 
        /// </summary>
        /// <param name="server">Server Address</param>
        /// <param name="dataBase">Data Base Name</param>
        /// <param name="authentication">Authentication Type</param>
        /// <param name="userId">Login User Id</param>
        /// <param name="password">Password</param>
        public DbConnectionInfo(string server, string dataBase, Authentication authentication, string userId = null, string password = null)
        {
            _server = server;
            _dataBase = dataBase;
            _userId = userId;
            _password = password;
            _authentication = authentication;
        }

        /// <summary>
        /// Server Name
        /// </summary>
        public string Server { get => _server; }

        /// <summary>
        /// Data Base Name
        /// </summary>
        public string DataBaseName { get => _dataBase; }

        /// <summary>
        /// Login User Name 
        /// </summary>
        public string UserId { get => _userId; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get => _password; }

        /// <summary>
        /// Authentication Type
        /// </summary>
        public Authentication Authentication { get => _authentication; }
    }
}
