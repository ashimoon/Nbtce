using NBtce.Attributes;
using NBtce.Mappers;
using NBtce.Model;

namespace NBtce.Requests
{
    [ApiRequest("Trade")]
    public class TradeRequest : ApiRequest<TradeReceipt>
    {
        private readonly TradingPair _tradingPair;
        private readonly TradeType _tradeType;
        private readonly decimal _rate;
        private readonly decimal _amount;

        [ApiParameter("pair", ParameterMapper = typeof(EnumMapper<TradingPair>), Required = true)]
        public TradingPair TradingPair
        {
            get { return _tradingPair; }
        }

        [ApiParameter("type", ParameterMapper = typeof(EnumMapper<TradeType>), Required = true)]
        public TradeType TradeType
        {
            get { return _tradeType; }
        }

        [ApiParameter("rate", Required = true)]
        public decimal Rate
        {
            get { return _rate; }
        }

        [ApiParameter("amount", Required = true)]
        public decimal Amount
        {
            get { return _amount; }
        }

        public TradeRequest(TradingPair tradingPair, TradeType tradeType, decimal rate, decimal amount)
        {
            _tradingPair = tradingPair;
            _tradeType = tradeType;
            _rate = rate;
            _amount = amount;
        }
    }
}