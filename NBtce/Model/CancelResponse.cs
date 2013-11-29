using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject]
    public class CancelResponse
    {
        [JsonProperty("order_id")]
        public decimal OrderId { get; set; }

        [JsonProperty("funds")]
        public Funds Funds { get; set; }
    }
}