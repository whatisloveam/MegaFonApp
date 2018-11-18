using InvalidAppHttpClient.Serializer.SerializeAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegafonInvalidApp
{
    public class Id
    {
        [CustomSerializeName("id")]
        public string Identificator;
    }
}
