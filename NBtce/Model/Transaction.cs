using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}