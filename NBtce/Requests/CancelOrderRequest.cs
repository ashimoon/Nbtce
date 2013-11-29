using NBtce.Attributes;
using NBtce.Model;

namespace NBtce.Requests
{
    [ApiRequest("CancelOrder")]
    public class CancelOrderRequest : ApiMethod<CancelResponse>
    {
        [ApiParameter("order_id", Required = true)]
        public long? OrderId { get; set; }
    }
}