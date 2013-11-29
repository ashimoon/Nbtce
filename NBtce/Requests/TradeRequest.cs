using NBtce.Attributes;
using NBtce.Mappers;
using NBtce.Model;

namespace NBtce.Requests
{
    [ApiRequest("Trade")]
    public class TradeRequest
    {
        [ApiParameter("pair", ParameterMapper = typeof(EnumMapper<TradingPair>), Required = true)]
        public TradingPair? TradingPair { get; set; }

        [ApiParameter("type", ParameterMapper = typeof(EnumMapper<TradeType>), Required = true)]
        public TradeType? TradeType { get; set; }

        [ApiParameter("rate", Required = true)]
        public decimal? Rate { get; set; }

        [ApiParameter("amount", Required = true)]
        public decimal? Amount { get; set; }
    }
}