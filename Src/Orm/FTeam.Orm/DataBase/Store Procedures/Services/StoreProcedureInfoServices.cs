using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Domains.DataBase.StoreProcedure;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.StoreProcedures
{
    public class StoreProcedureInfoServices : IStoreProcedureInfoRules
    {
        private readonly IQueryBase _query;

        private readonly IDataTableMapper _mapper;

        public StoreProcedureInfoServices()
        {
            _query = new QueryBase();
            _mapper = new DataTableMapper();
        }

        public async Task<StoreProcedureModel> GetProcedureInfoAsync(string spName, string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    return new StoreProcedureModel
                    {
                        Name = spName,
                        Inputs = await GetStoreProcedureInputsAsync(spName, connectionString)
                    };
                }
                catch
                {
                    throw;
                }
            });

        public async Task<StoreProcedureModel> GetProcedureInfoAsync(string spName, DbConnectionInfo dbConnectionInfo)
            => await Task.FromResult(await GetProcedureInfoAsync(spName, dbConnectionInfo.GetConnectionString()));

        public async Task<IEnumerable<StoreProcedureInputs>> GetStoreProcedureInputsAsync(string spName, string connectionString)
            => await Task.Run(async () =>
            {
                try
                {
                    string inputsQuery = $"SELECT (sys.parameters.name) as [Name],(sys.types.name) as [Type], (sys.parameters.is_nullable) as [Nullable],(sys.types.is_nullable) as [TypeNullable] " +
                                 $"FROM sys.parameters " +
                                 $"join sys.types on sys.parameters.system_type_id = sys.types.system_type_id " +
                                 $"WHERE object_id = object_id('{spName}')";

                    RunQueryResult queryResult = await _query.RunQueryAsync(connectionString, inputsQuery);

                    return await _mapper.MapListAsync<StoreProcedureInputs>(queryResult.DataTable);
                }
                catch
                {
                    throw;
                }
            });
    }
}
