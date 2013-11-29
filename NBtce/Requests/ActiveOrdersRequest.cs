using NBtce.Attributes;
using NBtce.Mappers;
using NBtce.Model;

namespace NBtce.Requests
{
    [ApiRequest("ActiveOrders")]
    public class ActiveOrdersRequest : ApiMethod<ActiveOrders>
    {
        [ApiParameter("pair", ParameterMapper = typeof(EnumMapper<TradingPair>))]
        public TradingPair? TradingPair { get; set; }
    }
}