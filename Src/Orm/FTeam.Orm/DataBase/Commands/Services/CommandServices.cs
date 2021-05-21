using FTeam.Orm.Attributes;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using System;
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
                IEnumerable<TableColumns> relasedColumns = GetRelasedColumnsAsync(tableInfo, instance).Result;

                PropertyInfo key = instanceProperties.FirstOrDefault(ip => ip.Name == tableInfo.TableInfo.PrimaryKey.Column);
                if (key != null)
                {
                    object value = key.GetValue(instance);

                    Type keyType = key.PropertyType;
                    if (keyType == typeof(string))
                        if (string.IsNullOrEmpty(value.ToString()))
                            value = Table.CreateStringId();


                    if (keyType == typeof(Guid))
                        if (Guid.Empty == Guid.Parse(value.ToString()))
                            value = Table.CreateGuidId();

                    key.SetValue(instance, value);

                }

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

        public IEnumerable<CreateCommandStatus> TryGenerateInsertCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand)
        {
            List<SqlCommand> sqlCommands = new();
            List<CreateCommandStatus> statuses = new();
            foreach (T instance in instances)
            {
                CreateCommandStatus command = TryGenerateInsertCommand<T>(tableInfo, instance, out SqlCommand cmd);
                if (command == CreateCommandStatus.Success)
                    sqlCommands.Add(cmd);
                statuses.Add(command);
            }
            sqlCommand = sqlCommands;
            return statuses;
        }

        public IEnumerable<CreateCommandStatus> GenerateInsertCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand)
        {
            List<SqlCommand> sqlCommands = new();
            List<CreateCommandStatus> statuses = new();
            foreach (T instance in instances)
            {
                CreateCommandStatus command = GenerateInsertCommand<T>(tableInfo, instance, out SqlCommand cmd);
                if (command == CreateCommandStatus.Success)
                    sqlCommands.Add(cmd);
                statuses.Add(command);
            }
            sqlCommand = sqlCommands;
            return statuses;
        }

        public IEnumerable<CreateCommandStatus> TryGenerateUpdateCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand)
        {
            List<SqlCommand> sqlCommands = new();
            List<CreateCommandStatus> statuses = new();
            foreach (T instance in instances)
            {
                CreateCommandStatus command = TryGenerateUpdateCommand<T>(tableInfo, instance, out SqlCommand cmd);
                if (command == CreateCommandStatus.Success)
                    sqlCommands.Add(cmd);
                statuses.Add(command);
            }
            sqlCommand = sqlCommands;
            return statuses;
        }

        public IEnumerable<CreateCommandStatus> GenerateUpdateCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand)
        {
            List<SqlCommand> sqlCommands = new();
            List<CreateCommandStatus> statuses = new();
            foreach (T instance in instances)
            {
                CreateCommandStatus command = GenerateUpdateCommand<T>(tableInfo, instance, out SqlCommand cmd);
                if (command == CreateCommandStatus.Success)
                    sqlCommands.Add(cmd);
                statuses.Add(command);
            }
            sqlCommand = sqlCommands;
            return statuses;
        }

        public IEnumerable<CreateCommandStatus> TryGenerateDeleteCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand)
        {
            List<SqlCommand> sqlCommands = new();
            List<CreateCommandStatus> statuses = new();
            foreach (T instance in instances)
            {
                CreateCommandStatus command = TryGenerateDeleteCommand<T>(tableInfo, instance, out SqlCommand cmd);
                if (command == CreateCommandStatus.Success)
                    sqlCommands.Add(cmd);
                statuses.Add(command);
            }
            sqlCommand = sqlCommands;
            return statuses;
        }

        public IEnumerable<CreateCommandStatus> GenerateDeleteCommand<T>(TableInfoResult tableInfo, IEnumerable<T> instances, out IEnumerable<SqlCommand> sqlCommand)
        {
            List<SqlCommand> sqlCommands = new();
            List<CreateCommandStatus> statuses = new();
            foreach (T instance in instances)
            {
                CreateCommandStatus command = GenerateDeleteCommand<T>(tableInfo, instance, out SqlCommand cmd);
                if (command == CreateCommandStatus.Success)
                    sqlCommands.Add(cmd);
                statuses.Add(command);
            }
            sqlCommand = sqlCommands;
            return statuses;
        }
    }
}
