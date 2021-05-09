using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LBSampleFramework.Helpers
{
    public static class Extensions
    {
        public static T Get<T>(this IDataRecord reader, string column)
        {
            List<string> allColumns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();

            if (!allColumns.Contains(column) || reader[column] == DBNull.Value)
            {
                return default(T);
            }
            var t = typeof(T);
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                t = Nullable.GetUnderlyingType(t);
            }
            return (T)Convert.ChangeType(reader[column], t);
        }
    }
}
