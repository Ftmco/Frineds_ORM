using FTeam.Orm.Models;
using FTeam.Orm.Results.QueryBase;
using System.Data.SqlClient;
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

        public QueryStatus TryInsert<T>(TableInfoResult tableInfo, T instance)
        {
            SqlCommand command = TryGenerateCmd(tableInfo, instance);

            return command == null ? QueryStatus.Exception :
           _tableCrudBase.TryInsert(tableInfo.DbConnectionInfo, command);
        }

        public async Task<QueryStatus> TryInsertAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(async () =>
            {
                SqlCommand command = TryGenerateCmd(tableInfo, instance);

                return command == null ? QueryStatus.Exception :
                await _tableCrudBase.TryInsertAsync(tableInfo.DbConnectionInfo, command);
            });

        private static SqlCommand TryGenerateCmd<T>(TableInfoResult tableInfo, T instance)
        {
            try
            {
                string columns = string.Join(",", tableInfo.TableInfo.TableColumns.Select(tc => $"[{tc.Column}]").ToList());

                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();

                string values = string.Join(",",
                    tableInfo.TableInfo.TableColumns.Select(ip => $"@{ip.Column}"));

                string query = $"INSERT INTO [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] ({columns})VALUES({values})";

                SqlCommand cmd = new(query);

                foreach (var item in tableInfo.TableInfo.TableColumns)
                    cmd.Parameters.AddWithValue($"@{item.Column}", instanceProperties.FirstOrDefault(ip => ip.Name == item.Column).GetValue(instance));

                return cmd;
            }
            catch
            {
                return null;
            }
        }
    }
}
