using FTeam.Orm.Mapper.Rules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FTeam.Orm.Mapper.Impelement
{
    public class DataTableMapper : IDataTableMapper
    {
        public T Map<T>(DataTable dataTable)
        {

            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower());

            PropertyInfo[] properties = typeof(T).GetProperties();

            IList<T> result = new List<T>();

            foreach (var row in dataTable.AsEnumerable())
            {
                T objT = Activator.CreateInstance<T>();
                for (int i = 0; i < properties.Length; i += 1)
                {
                    if (columnNames.Contains(properties[i].Name.ToLower()))
                    {
                        try
                        {
                            properties[i].SetValue(objT, row[properties[i].Name]);
                        }
                        catch
                        {

                        }
                    }
                }
                result.Add(objT);
            }
            return result.FirstOrDefault();
        }

        public async Task<T> MapAsync<T>(DataTable dataTable)
            => await Task.Run(() => Map<T>(dataTable));

        public IEnumerable<T> MapList<T>(DataTable dataTable)
        {
            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower());

            PropertyInfo[] properties = typeof(T).GetProperties();
            IList<T> result = new List<T>();

            foreach (DataRow row in dataTable.AsEnumerable())
            {
                T objT = Activator.CreateInstance<T>();
                foreach (PropertyInfo item in properties)
                {
                    if (columnNames.Contains(item.Name.ToLower()))
                    {
                        try
                        {
                            item.SetValue(objT, row[item.Name]);
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                }
                result.Add(objT);
            }

            return result;
        }

        public async Task<IEnumerable<T>> MapListAsync<T>(DataTable dataTable)
            => await Task.Run(() => MapList<T>(dataTable));

    }
}
