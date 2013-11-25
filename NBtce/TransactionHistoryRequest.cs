using System;

namespace NBtce
{
    [ApiRequest]
    public class TransactionHistoryRequest
    {
        [ApiParameter("from_id")]
        public int FromId { get; set; }

        [ApiParameter("end_id")]
        public int EndId { get; set; }

        [ApiParameter("count")]
        public int Count { get; set; }

        [ApiParameter("order", ParameterConverter = typeof(SortOrderParameterConverter))]
        public SortOrder SortOrder { get; set; }

        [ApiParameter("since", ParameterConverter = typeof(UnixTimeParameterConverter))]
        public DateTime Since { get; set; }

        [ApiParameter("end", ParameterConverter = typeof(UnixTimeParameterConverter))]
        public DateTime Until { get; set; }
    }
}