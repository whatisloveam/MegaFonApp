using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using InvalidAppHttpClient.Serializer;
using InvalidAppHttpClient.Serializer.SerializeAttribute;

namespace InvalidAppHttpClient.Example
{
    public static class ExampleSender
    {
        public static string Send()
        {
            var httpClient = new HttpClientWithRetries(10, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(2000));
            var objToSend = new User { Login = "Slava", Password = "molodec" };
            var serializedObj = objToSend.Serialize();
            var res = httpClient.PostWithRetries(new Uri("засунь сюда адрес сервера"), serializedObj, "text/plain");
            var resValue = res.Value;
            return resValue;
        }
    }

    public class User
    {
        public string Login;
        [CustomSerializeName("pass")]
        public string Password;
    }
}