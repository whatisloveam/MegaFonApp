using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegafonInvalidApp
{
    public class User
    {
        [JsonProperty("user_id")]
        public string Id;
        [JsonProperty("user_surname")]
        public string Surname;
        [JsonProperty("user_name")]
        public string Name;
        [JsonProperty("user_problem")]
        public string Problem;
    }
}
