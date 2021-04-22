using FTeam.Orm.Results.QueryBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.QueryBase
{
    public interface IQueryBase
    {
        Task<VoidQueryStatus> RunVoidQueryAsync(string connectionString, string query);

        Task<VoidQueryStatus> RunVoidQueryAsync(SqlConnection sqlConnection, string query);

        Task RunQueryAsync(string connectionString, string query);
    }
}
