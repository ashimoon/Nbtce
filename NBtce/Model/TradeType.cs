using NBtce.Attributes;

namespace NBtce.Model
{
    [JsonEnum]
    public enum TradeType
    {
        [JsonEnumValue("buy")]
        Buy,
        [JsonEnumValue("sell")]
        Sell
    }
}