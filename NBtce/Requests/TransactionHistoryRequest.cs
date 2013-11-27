using System;
using NBtce.Attributes;
using NBtce.Mappers;
using NBtce.Model;

namespace NBtce.Requests
{
    [ApiRequest("TransHistory")]
    public class TransactionHistoryRequest : ApiMethod<TransactionHistory>
    {
        [ApiParameter("from_id")]
        public int FromId { get; set; }

        [ApiParameter("end_id")]
        public int EndId { get; set; }

        [ApiParameter("count")]
        public int Count { get; set; }

        [ApiParameter("order")]
        public SortOrder SortOrder { get; set; }

        [ApiParameter("since", ParameterMapper = typeof(UnixTimeMapper))]
        public DateTime Since { get; set; }

        [ApiParameter("end", ParameterMapper = typeof(UnixTimeMapper))]
        public DateTime Until { get; set; }
    }
}
