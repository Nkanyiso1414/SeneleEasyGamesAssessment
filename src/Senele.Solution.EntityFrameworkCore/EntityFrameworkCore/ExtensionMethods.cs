using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Senele.Solution.EntityFrameworkCore
{
    public static class ExtensionMethods
    {
        public static async Task<List<T>> MapToList<T>(this DbDataReader dr, CancellationToken cancellationToken = default)
        {
            var list = new List<T>();
            while (await dr.ReadAsync(cancellationToken))
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static async Task<T> MapToObject<T>(this DbDataReader dr, CancellationToken cancellationToken = default)
        {
            var obj = Activator.CreateInstance<T>();
            while (await dr.ReadAsync(cancellationToken))
            {
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            }
            return obj;
        }
    }
}
