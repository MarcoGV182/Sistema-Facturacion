using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public static class Conversiones
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }


        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        object value = dr[pro.Name];
                        if (value == DBNull.Value) value = null;
                        PropertyInfo property = temp.GetProperty(column.ColumnName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                        try
                        {
                            if (property !=null && property.CanWrite)
                                pro.SetValue(obj, value, null);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }  
                    else
                        continue;
                }
            }
            return obj;
        }


        
    }
}
