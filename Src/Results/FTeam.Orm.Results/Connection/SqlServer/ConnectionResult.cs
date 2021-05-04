﻿using FTeam.Orm.Models.Connection.Shared;
using System.Data.SqlClient;

namespace FTeam.Orm.Domains.Connection.SqlServer
{

    /// <summary>
    /// Open Sql Connection Result
    /// </summary>
    public record OpenConnectionResult
    {
        /// <summary>
        /// SqlConnection Model
        /// </summary>
        public SqlConnection SqlConnection { get; set; }

        /// <summary>
        /// Connection Status
        /// </summary>
        public OpenConnectionStatus ConnectionStatus { get; set; }
    }
}