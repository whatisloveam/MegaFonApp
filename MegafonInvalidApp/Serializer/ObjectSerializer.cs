using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InvalidAppHttpClient.Serializer.SerializeAttribute;

namespace InvalidAppHttpClient.Serializer
{
    public static class ObjectSerializer
    {
        public static Dictionary<string, string> Serialize(object obj)
        {
            var fields = obj
                .GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(
                    e => (e.GetCustomAttribute(typeof(CustomSerializeNameAttribute)) as CustomSerializeNameAttribute)
                         ?.Name ?? e.Name, fieldInfo => fieldInfo.GetValue(obj).ToString());
            return fields;
        }
    }
}
