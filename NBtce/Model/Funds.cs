using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Funds
    {
        [JsonProperty("usd")]
        public decimal Usd { get; set; }

        [JsonProperty("rur")]
        public decimal Rur { get; set; }

        [JsonProperty("eur")]
        public decimal Eur { get; set; }

        [JsonProperty("btc")]
        public decimal Btc { get; set; }

        [JsonProperty("ltc")]
        public decimal Ltc { get; set; }

        [JsonProperty("nmc")]
        public decimal Nmc { get; set; }

        [JsonProperty("nvc")]
        public decimal Nvc { get; set; }

        [JsonProperty("trc")]
        public decimal Trc { get; set; }

        [JsonProperty("ppc")]
        public decimal Ppc { get; set; }

        [JsonProperty("ftc")]
        public decimal Ftc { get; set; }
    }
}