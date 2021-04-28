using FTeam.DependencyController.Kernel;
using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableCrudBaseServices : ITableCrudBase
    {
        #region :: Dependency ::

        /// <summary>
        /// Friends Dependency Injector Kernel
        /// </summary>
        public static readonly IFkernel _fkernel = new Fkernel();

        /// <summary>
        /// Query Base Services
        /// </summary>
        private readonly IQueryBase _queryBase;

        /// <summary>
        /// Data Table Mapper
        /// </summary>
        private readonly IDataTableMapper _dataTableMapper;

        public TableCrudBaseServices()
        {
            RegisterDependency();
            _queryBase = _fkernel.Get<IQueryBase>();
            _dataTableMapper = _fkernel.Get<IDataTableMapper>();
        }

        #endregion

        public IEnumerable<T> GetAllBase<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.MapList<T>(runQuery.DataTable),

                _ => null
            };
        }

        public async Task<IEnumerable<T>> GetAllBaseAsync<T>(TableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.RunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapListAsync<T>(runQuery.DataTable),

                     _ => null
                 };
             });

        public T GetBase<T>(TableInfoResult tableInfoResult, string query)
        {
            string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
            RunQueryResult runQuery = _queryBase.RunQuery(connectionString, query);

            return runQuery.QueryStatus switch
            {
                QueryStatus.Success => _dataTableMapper.Map<T>(runQuery.DataTable),

                _ => default
            };
        }

        public async Task<T> GetBaseAsync<T>(TableInfoResult tableInfoResult, string query)
             => await Task.Run(async () =>
             {
                 string connectionString = tableInfoResult.DbConnectionInfo.GetConnectionString();
                 RunQueryResult runQuery = await _queryBase.RunQueryAsync(connectionString, query);

                 return runQuery.QueryStatus switch
                 {
                     QueryStatus.Success => await _dataTableMapper.MapAsync<T>(runQuery.DataTable),

                     _ => default
                 };
             });

        /// <summary>
        /// Register Dependency In FKernel
        /// </summary>
        private static void RegisterDependency()
        {
            _fkernel.Inject<IQueryBase, QueryBase>();
            _fkernel.Inject<IDataTableMapper, DataTableMapper>();
        }
    }
}
