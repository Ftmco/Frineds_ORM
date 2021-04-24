using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables
{
    public class TableServices : ITableRules
    {
        #region __Dependency__

        private readonly IQueryBase _queryBase;

        private readonly IDataTableMapper _dataTableMapper;

        public TableServices()
        {
            _queryBase = new QueryBase();
            _dataTableMapper = new DataTableMapper();
        }

        #endregion

        public TableInfoResult GetTableInfo(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            string query = $"SELECT TABLE_NAME as TableName,Schema,Catalog FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            RunQueryResult queryResult = _queryBase.RunQuery(dbConnectionInfo.GetConnectionString(), query);

            return queryResult.QueryStatus switch
            {
                QueryStatus.Success => new TableInfoResult { TableInfo = _dataTableMapper.Map<TableInfo>(queryResult.DataTable), Status = QueryStatus.Success },

                QueryStatus.Exception => new TableInfoResult { TableInfo = null, Status = QueryStatus.Exception },

                QueryStatus.InvalidOperationException => new TableInfoResult { TableInfo = null, Status = QueryStatus.InvalidOperationException },

                QueryStatus.SqlException => new TableInfoResult { TableInfo = null, Status = QueryStatus.SqlException },

                QueryStatus.DbException => new TableInfoResult { TableInfo = null, Status = QueryStatus.DbException },

                _ => new TableInfoResult { TableInfo = null, Status = QueryStatus.Exception }
            };
        }

        public Task<TableInfoResult> GetTableInfoAsync(DbConnectionInfo dbConnectionInfo, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
