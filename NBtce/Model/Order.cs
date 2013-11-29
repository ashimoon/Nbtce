using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject]
    public class Order
    {
        [JsonProperty("pair")]
        [JsonConverter(typeof(EnumValueConverter<TradingPair>))]
        public TradingPair TradingPair { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(EnumValueConverter<TradeType>))]
        public TradeType Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("timestamp_created")]
        public long TimestampCreated { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}