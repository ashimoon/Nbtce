using Newtonsoft.Json;

namespace NBtce
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Funds
    {
        [JsonProperty("usd")]
        public decimal USD { get; set; }

        [JsonProperty("btc")]
        public decimal BTC { get; set; }

        [JsonProperty("ltc")]
        public decimal LTC { get; set; }
    }
}