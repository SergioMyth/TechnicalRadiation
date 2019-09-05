using System.Collections.Generic;
using System.Dynamic;

namespace WebApplication5.Models.Extensions
{
    public static class Extensions 
    {
        public static void AddListReference<T>(this ExpandoObject item, string key, IEnumerable<T> list) => ((IDictionary<string, object>)item).Add(key, list);
        public static void AddReference<T>(this ExpandoObject item, string key, T value) => ((IDictionary<string, object>)item).Add(key, value);
    }
}