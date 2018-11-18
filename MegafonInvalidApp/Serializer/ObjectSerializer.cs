using System.Collections.Generic;
using System.Collections.Specialized;
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

        public static NameValueCollection SerializeToNameValue(this object obj)
        {
            var nvCollection = new NameValueCollection();
            foreach(var kv in Serialize(obj))
            {
                nvCollection[kv.Key] = kv.Value;
            }
            return nvCollection;
        }
    }
}
