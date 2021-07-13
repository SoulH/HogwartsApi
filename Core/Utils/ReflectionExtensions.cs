using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utils
{
    public static class ReflectionExtensions
    {
        public static T CreateFrom<T>(params T[] sources) where T : new()
        {
            var ret = new T();
            MergeWith(ret, sources);
            return ret;
        }

        public static void MergeWith<T>(this T target, params T[] sources)
        {
            Func<PropertyInfo, T, bool> predicate = (p, s) =>
            {
                return  !p.GetValue(s).Equals(GetDefault(p.PropertyType));
            };

            MergeWith(target, predicate, sources);
        }

        public static void MergeWith<T>(T target, Func<PropertyInfo, T, bool> predicate, params T[] sources)
        {
            foreach (var propertyInfo in typeof(T).GetProperties().Where(prop => prop.CanRead && prop.CanWrite))
            {
                foreach (var source in sources)
                {
                    if (predicate(propertyInfo, source))
                    {
                        propertyInfo.SetValue(target, propertyInfo.GetValue(source));
                    }
                }
            }
        }

        private static object GetDefault(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
