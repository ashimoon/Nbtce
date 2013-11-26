using System;
using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Trade
    {
        [JsonProperty("pair")]
        [JsonConverter(typeof(EnumValueConverter<TradingPair>))]
        public TradingPair TradingPair { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("is_your_order")]
        public bool IsYourOrder { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}