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
    public record ConnectionStringModel
    {
        /// <summary>
        /// Db Connection String
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
