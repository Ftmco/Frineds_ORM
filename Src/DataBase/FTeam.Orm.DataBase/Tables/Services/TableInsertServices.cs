using FTeam.DependencyController.Kernel;
using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Tables.Services
{
    public class TableInsertServices : ITableInsertRules
    {
        #region --:: Dependency ::--

        private readonly ITableCrudBase _tableCrudBase;

        public TableInsertServices()
        {
            _tableCrudBase = new TableCrudBaseServices();
        }

        #endregion

        public QueryStatus Insert<T>(TableInfoResult tableInfo, T instance)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryStatus> InsertAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                string columns = string.Join(",", tableInfo.TableInfo.TableColumns.Select(tc => $"[{tc.Column}]").ToList());

                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();

                string values = string.Join(",",
                    instanceProperties.Select(ip => $"CAST('{ip.GetValue(instance)}' AS {tableInfo.TableInfo.TableColumns.FirstOrDefault(tc => tc.Column == ip.Name).Type})"));

                string query = $"INSERT INTO [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] ({columns})VALUES({values})";

                return await _tableCrudBase.InsertAsync(tableInfo.DbConnectionInfo, query);
            });

    }
}
