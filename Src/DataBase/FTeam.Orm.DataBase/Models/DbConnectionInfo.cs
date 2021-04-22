using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Models
{
    /// <summary>
    /// Connection String Data Base Model
    /// </summary>
    public record DbConnectionInfo
    {

        /// <summary>
        /// Server Name
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Data Base Name
        /// </summary>
        public string DataBaseName { get; set; }

        /// <summary>
        /// Login User Name 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Authentication Type
        /// </summary>
        public Authentication Authentication { get; set; }
    }
}
