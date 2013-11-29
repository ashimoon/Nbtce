using NBtce.Attributes;

namespace NBtce.Requests
{
    [ApiRequest("CancelOrder")]
    public class CancelOrderRequest
    {
        [ApiParameter("order_id", Required = true)]
        public long? OrderId { get; set; }
    }
}