using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace FTeam.Orm.DataBase.Commands
{
    public class CommandServices : ICommandRules
    {
        public CreateCommandStatus TryGenerateUpdateCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
        {
            try
            {
                return GenerateUpdateCommand(tableInfo, instance, out sqlCommand);
            }
            catch
            {
                sqlCommand = default;
                return CreateCommandStatus.Exception;
            }
        }

        public CreateCommandStatus TryGenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
        {
            try
            {
                return GenerateInsertCommand(tableInfo, instance, out sqlCommand);
            }
            catch
            {
                sqlCommand = default;
                return CreateCommandStatus.Exception;
            }
        }

        public CreateCommandStatus TryGenerateDeleteCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
        {
            try
            {
                return GenerateDeleteCommand(tableInfo, instance, out sqlCommand);
            }
            catch
            {
                sqlCommand = default;
                return CreateCommandStatus.Exception;
            }
        }

        private static object GetInstancePrimaryKey<T>(PrimaryKey primaryKey, T instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties();
            PropertyInfo property = properties.FirstOrDefault(pi => pi.Name == primaryKey.Column);
            return property.GetValue(instance);
        }

        public CreateCommandStatus GenerateInsertCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
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
                throw;
            }
        }

        public CreateCommandStatus GenerateUpdateCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
        {
            try
            {
                string columns = string.Join(",", tableInfo.TableInfo.TableColumns.Select(tc => $"[{tc.Column}] = @{tc.Column.ToLower()}").ToList());

                string query = $"UPDATE [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] SET {columns} WHERE [{tableInfo.TableInfo.TableName}].[{tableInfo.TableInfo.PrimaryKey.Column}] = @primaryKey";

                SqlCommand cmd = new(query);
                cmd.Parameters.AddWithValue($"@primaryKey", GetInstancePrimaryKey(tableInfo.TableInfo.PrimaryKey, instance));

                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();

                foreach (var item in tableInfo.TableInfo.TableColumns)
                    cmd.Parameters.AddWithValue($"@{item.Column.ToLower()}", instanceProperties.FirstOrDefault(ip => ip.Name == item.Column).GetValue(instance));

                sqlCommand = cmd;
                return CreateCommandStatus.Success;
            }
            catch
            {
                throw;
            }
        }

        public CreateCommandStatus GenerateDeleteCommand<T>(TableInfoResult tableInfo, T instance, out SqlCommand sqlCommand)
        {
            try
            {
                string query = $"DELETE FROM [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] WHERE [{tableInfo.TableInfo.TableName}].[{tableInfo.TableInfo.PrimaryKey.Column}] = @primaryKey";

                SqlCommand cmd = new(query);
                cmd.Parameters.AddWithValue($"@primaryKey", GetInstancePrimaryKey(tableInfo.TableInfo.PrimaryKey, instance));

                sqlCommand = cmd;
                return CreateCommandStatus.Success;
            }
            catch
            {
                throw;
            }
        }
    }
}
