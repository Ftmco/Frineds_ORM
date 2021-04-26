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

            return dataTable.AsEnumerable().Select(row =>
            {
                T objT = Activator.CreateInstance<T>();
                foreach (var item in properties)
                {
                    if (columnNames.Contains(item.Name.ToLower()))
                    {
                        try
                        {
                            item.SetValue(objT, row[item.Name]);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                return objT;
            }).FirstOrDefault();
        }

        public async Task<T> MapAsync<T>(DataTable dataTable)
            => await Task.Run(() => Map<T>(dataTable));

        public IEnumerable<T> MapList<T>(DataTable dataTable)
        {
            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower());

            PropertyInfo[] properties = typeof(T).GetProperties();

            return dataTable.AsEnumerable().Select(row =>
            {
                T objT = Activator.CreateInstance<T>();
                foreach (var item in properties)
                {
                    if (columnNames.Contains(item.Name.ToLower()))
                    {
                        try
                        {
                            item.SetValue(objT, row[item.Name]);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                return objT;
            }).ToList();
        }

        public async Task<IEnumerable<T>> MapListAsync<T>(DataTable dataTable)
            => await Task.Run(() => MapList<T>(dataTable));

    }
}
