using System;

namespace InvalidAppHttpClient.Serializer.SerializeAttribute
{
    public class CustomSerializeNameAttribute : Attribute
    {
        public string Name { get; }
        public CustomSerializeNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
