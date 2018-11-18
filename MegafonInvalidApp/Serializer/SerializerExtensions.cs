using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidAppHttpClient.Serializer
{
    public static class SerializerExtensions
    {
        public static IDictionary<string, string> Serialize(this object obj)
        {
            return ObjectSerializer.Serialize(obj);
        }
    }
}
