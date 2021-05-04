﻿namespace FTeam.Orm.Domains.Connection.PgSql
{
    public record PgSqlDbConnectionInfo
    {

        /// <summary>
        /// P
        /// </summary>
        /// <param name="server">specifies the server location</param>
        /// <param name="port">default is 5432</param>
        /// <param name="dataBase">the database name</param>
        /// <param name="userId">the database user</param>
        /// <param name="password">the password for the database user</param>
        public PgSqlDbConnectionInfo(string server, string dataBase, string userId, string password, string port = "5432")
        {
            Server = server;
            Port = port;
            DataBase = dataBase;
            UserId = userId;
            Password = password;
        }

        public string Server { get; }

        public string Port { get; }

        public string DataBase { get; }

        public string UserId { get; }

        public string Password { get; }
    }
}
