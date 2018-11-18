using InvalidAppHttpClient.Serializer.SerializeAttribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegafonInvalidApp
{
    public class OfferTask
    {
        [JsonProperty("task_id")]
        public string Id { get; set; }
        [JsonProperty("task_name")]
        public string Title { get; set; }
        [JsonProperty("task_desc")]
        public string Description { get; set; }
        [JsonProperty("task_price")]
        public string Price{ get; set; }
        [JsonProperty("task_company")]
        public string Company { get; set; }
        [JsonProperty("task_status_id")]
        public string Status { get; set; }
        [JsonProperty("task_customer_id")]
        public string Customer { get; set; }
        [JsonProperty("task_executor_id")]
        public string Executor { get; set; }
    }
}
