using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CRUD.Dominio
{
    public static class Conversor
    {
        public static List<T> ConverterParaLista<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().
                Select(c => c.ColumnName.ToLower()).
                ToList();

            var propriedade = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objUsuario = Activator.CreateInstance<T>();
                foreach (var pro in propriedade)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        var value = row[pro.Name];
                        if (System.Convert.IsDBNull(value))
                        {
                            pro.SetValue(objUsuario, null);
                        }
                        else
                        {
                            pro.SetValue(objUsuario, row[pro.Name]);
                        }
                    }
                }
                return objUsuario;
            }).ToList();
        }
    }
}
