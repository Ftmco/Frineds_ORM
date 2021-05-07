using FTeam.Orm.Domains;
using FTeam.Orm.Domains.DataBase.Table.Base;
using FTeam.Orm.Models.DataBase.Table.PgSql;
using Npgsql;
using System.Linq;
using System.Reflection;

namespace FTeam.Orm.PgSql.DataBase.Commands
{
    public class CommandServices : ICommandRules
    {
        public CreateCommandStatus TryGenerateUpdateCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand)
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

        public CreateCommandStatus TryGenerateInsertCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand)
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

        public CreateCommandStatus TryGenerateDeleteCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand)
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

        public CreateCommandStatus GenerateInsertCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand)
        {
            try
            {
                string columns = string.Join(",", tableInfo.TableInfo.TableColumns.Select(tc => $"[{tc.Column}]").ToList());

                PropertyInfo[] instanceProperties = instance.GetType().GetProperties();

                string values = string.Join(",",
                    tableInfo.TableInfo.TableColumns.Select(ip => $"@{ip.Column}"));

                string query = $"INSERT INTO public.\"{tableInfo.TableInfo.TableName}\" ({columns})VALUES({values})";

                NpgsqlCommand cmd = new(query);

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

        public CreateCommandStatus GenerateUpdateCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand)
        {
            try
            {
                string columns = string.Join(",", tableInfo.TableInfo.TableColumns.Select(tc => $"[{tc.Column}] = @{tc.Column.ToLower()}").ToList());

                string query = $"UPDATE public.\"{tableInfo.TableInfo.TableName}\" SET {columns} WHERE [{tableInfo.TableInfo.TableName}].[{tableInfo.TableInfo.PrimaryKey.Column}] = @primaryKey";

                NpgsqlCommand cmd = new(query);
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

        public CreateCommandStatus GenerateDeleteCommand<T>(PgSqlTableInfoResult tableInfo, T instance, out NpgsqlCommand sqlCommand)
        {
            try
            {
                string query = $"DELETE FROM public.\"{tableInfo.TableInfo.TableName}\" WHERE [{tableInfo.TableInfo.TableName}].[{tableInfo.TableInfo.PrimaryKey.Column}] = @primaryKey";

                NpgsqlCommand cmd = new(query);
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
