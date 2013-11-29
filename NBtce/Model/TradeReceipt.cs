using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject]
    public class TradeReceipt
    {
        [JsonProperty("received")]
        public decimal Received { get; set; }

        [JsonProperty("remains")]
        public decimal Remains { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("funds")]
        public Funds Funds { get; set; }
    }
}
