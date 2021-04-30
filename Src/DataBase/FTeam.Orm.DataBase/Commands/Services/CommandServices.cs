using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace FTeam.Orm.DataBase.Commands
{
    public class CommandServices : ICommandRules
    {
        public CreateCommandStatus TryGenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
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

                sqlCommand = cmd;
                return CreateCommandStatus.Success;
            }
            catch
            {
                sqlCommand = default;
                return CreateCommandStatus.Exception;
            }
        }
    }
}
