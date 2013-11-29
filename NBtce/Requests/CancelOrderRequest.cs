using NBtce.Attributes;
using NBtce.Model;

namespace NBtce.Requests
{
    [ApiRequest("CancelOrder")]
    public class CancelOrderRequest : ApiRequest<CancelResponse>
    {
        private readonly long _orderId;
        
        [ApiParameter("order_id", Required = true)]
        public long OrderId
        {
            get { return _orderId; }
        }
        
        public CancelOrderRequest(long orderId)
        {
            _orderId = orderId;
        }
    }
}