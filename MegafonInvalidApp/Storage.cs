using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InvalidAppHttpClient.Serializer;

namespace MegafonInvalidApp
{
    public static class Storage
    {
        public static User CurrentProblemUser;
        public static WebClient WebClient;

        public static string SendPost<T>(string url, T obj)
        {
            var data = obj.SerializeToNameValue();
            var response = WebClient.UploadValues(url, "POST", data);
            string responseInString = Encoding.UTF8.GetString(response);
            //Login_Text.Text = responseInString;
            //MessageBox.Show(responseInString);
            return responseInString;
        }
    }
}
