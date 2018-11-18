using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvalidAppHttpClient.Serializer.SerializeAttribute;

namespace MegafonInvalidApp
{
    public class AuthUser
    {
        [CustomSerializeName("mail")]
        public string Mail;
        [CustomSerializeName("password")]
        public string Password;
    }
}
