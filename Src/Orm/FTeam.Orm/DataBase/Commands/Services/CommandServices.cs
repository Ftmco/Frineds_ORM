using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Mapper.Impelement;
using FTeam.Orm.Mapper.Rules;
using FTeam.Orm.Models;
using FTeam.Orm.Models.DataBase;
using FTeam.Orm.Models.QueryBase;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static FTeam.Orm.Domains.CashVarabiles.CacheVariables;


namespace FTeam.Orm.DataBase.Commands
{
    public class CommandServices : ICommandRules
    {
        #region -- Dependency --

        private readonly IQueryBase _queryBase;

        private readonly IDataTableMapper _tableMapper;

        public CommandServices()
        {
            _queryBase = new QueryBase();
            _tableMapper = new DataTableMapper();
        }

        #endregion

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
                    SetValueForPrimaryKey(ref key, instance, tableInfo);

                string columns = string.Join(",", relasedColumns.Select(tc => $"[{tc.Column}]").ToList());

                string values = string.Join(",",
                    relasedColumns.Select(ip => $"@{ip.Column}"));

                string query = $"INSERT INTO [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] ({columns})VALUES({values})";

                ReleaseQuery(ref query, tableInfo, instance);
                SqlCommand cmd = new(query);
                foreach (TableColumns item in relasedColumns)
                {
                    object value = instanceProperties.FirstOrDefault(ip => ip.Name == item.Column).GetValue(instance);
                    if (value != null)
                        cmd.Parameters.AddWithValue($"@{item.Column}", value);
                }

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
                IEnumerable<TableColumns> relasedColumns = GetRelasedColumnsAsync(tableInfo, instance).Result;

                string columns = string.Join(",", relasedColumns.Select(tc => $"[{tc.Column}] = @{tc.Column.ToLower()}").ToList());

                string query = $"UPDATE [{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}] SET {columns} WHERE [{tableInfo.TableInfo.TableName}].[{tableInfo.TableInfo.PrimaryKey.Column}] = @primaryKey";

                ReleaseQuery(ref query, tableInfo, instance);
                SqlCommand cmd = new(query);
                cmd.Parameters.AddWithValue($"@primaryKey", GetInstancePrimaryKey(tableInfo.TableInfo.PrimaryKey, instance));
                foreach (TableColumns item in relasedColumns)
                {
                    object value = instanceProperties.FirstOrDefault(ip => ip.Name == item.Column).GetValue(instance);
                    if (value != null)
                        cmd.Parameters.AddWithValue($"@{item.Column}", value);
                }

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
                IEnumerable<TableColumns> collection()
                {
                    foreach (TableColumns column in tableInfo.TableInfo.TableColumns)
                    {
                        PropertyInfo submitColumn = instanceProperties.FirstOrDefault(ip => ip.Name == column.Column);
                        if (submitColumn != null)
                        {
                            object value = submitColumn.GetValue(instance);
                            if (value != null)
                                yield return column;
                        }
                    }
                }

                relasedColumns.AddRange(collection());
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

        public void SetValueForPrimaryKey<T>(ref PropertyInfo key, T instance, TableInfoResult tableInfo)
        {
            object value = key.GetValue(instance);

            Type keyType = key.PropertyType;

            if (keyType == typeof(string) && string.IsNullOrEmpty(value.ToString()))
                value = Table.CreateStringId();

            if (keyType == typeof(Guid) && Guid.Empty == Guid.Parse(value.ToString()))
                value = Table.CreateGuidId();

            if (keyType == typeof(int))
                value = GetPrimaryKeyInt(tableInfo);

            key.SetValue(instance, value);
        }

        public int GetPrimaryKeyInt(TableInfoResult tableInfo)
        {
            try
            {
                string tableName = $"[{tableInfo.TableInfo.Catalog}].[{tableInfo.TableInfo.Schema}].[{tableInfo.TableInfo.TableName}]";
                string query = $"SELECT TOP 1 [{tableInfo.TableInfo.PrimaryKey.Column}] FROM " + tableName +
                    $"ORDER BY {tableInfo.TableInfo.PrimaryKey.Column} DESC";

                if (CacheKeys.Keys.Any(s => s == tableName))
                    return int.Parse(CacheKeys[tableName].ToString()) + 1;

                RunQueryResult queryResult = _queryBase.RunQuery(tableInfo.DbConnectionInfo.GetConnectionString(), query);
                TableLastId existId = new() { Id = 0 };
                if (queryResult.DataTable.Columns.Count != 0)
                    existId = _tableMapper.Map<TableLastId>(queryResult.DataTable);

                int newId = existId != null ? existId.Id + 2 : +1;
                CacheKeys.Add(tableName, newId);
                return newId;
            }
            catch
            {
                throw;
            }
        }

        public void ReleaseQuery<T>(ref string query, TableInfoResult tableInfo, T instance)
        {
            string onIdentity = $"  IF (OBJECTPROPERTY(OBJECT_ID('{tableInfo.TableInfo.TableName}'), 'TableHasIdentity') = 1)SET identity_insert {tableInfo.TableInfo.TableName} ON  ";
            string offIdentity = $" IF (OBJECTPROPERTY(OBJECT_ID('{tableInfo.TableInfo.TableName}'), 'TableHasIdentity') = 1)SET identity_insert {tableInfo.TableInfo.TableName} OFF  ";

            query = onIdentity + query + offIdentity;
        }
    }
}
