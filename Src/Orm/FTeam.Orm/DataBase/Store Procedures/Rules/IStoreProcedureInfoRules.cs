using FTeam.Orm.Domains.DataBase.StoreProcedure;
using FTeam.Orm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.StoreProcedures
{
    public interface IStoreProcedureInfoRules
    {
        Task<StoreProcedureModel> GetProcedureInfoAsync(string spName,string connectionString);

        Task<StoreProcedureModel> GetProcedureInfoAsync(string spName,DbConnectionInfo dbConnectionInfo);

        Task<IEnumerable<StoreProcedureInputs>> GetStoreProcedureInputsAsync(string spName, string connectionString);
    }
}
