using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();
                IEnumerable<TableColumns> relasedColumns = GetRelasedColumnsAsync<T>(tableInfo, instance).Result;

                string columns = string.Join(",", relasedColumns.Select(tc => $"[{tc.Column}]").ToList());

                string values = string.Join(",",
                    relasedColumns.Select(ip => $"@{ip.Column}"));

                string query = $"INSERT INTO [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] ({columns})VALUES({values})";

                SqlCommand cmd = new(query);

                foreach (var item in relasedColumns)
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
                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();
                IEnumerable<TableColumns> relasedColumns = GetRelasedColumnsAsync<T>(tableInfo, instance).Result;

                string columns = string.Join(",", relasedColumns.Select(tc => $"[{tc.Column}] = @{tc.Column.ToLower()}").ToList());

                string query = $"UPDATE [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] SET {columns} WHERE [{tableInfo.TableInfo.TableName}].[{tableInfo.TableInfo.PrimaryKey.Column}] = @primaryKey";

                SqlCommand cmd = new(query);
                cmd.Parameters.AddWithValue($"@primaryKey", GetInstancePrimaryKey(tableInfo.TableInfo.PrimaryKey, instance));


                foreach (TableColumns item in relasedColumns)
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

        public async Task<IEnumerable<TableColumns>> GetRelasedColumnsAsync<T>(TableInfoResult tableInfo, T instance)
            => await Task.Run(() =>
            {
                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();
                List<TableColumns> relasedColumns = new();
                relasedColumns.AddRange(from TableColumns column in tableInfo.TableInfo.TableColumns
                                        let sumbitColumn = instanceProperties.Any(ip => ip.Name == column.Column)
                                        where sumbitColumn
                                        select column);
                return relasedColumns;
            });
    }
}
