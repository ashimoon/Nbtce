using Newtonsoft.Json;

namespace NBtce
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserInfo
    {
        [JsonProperty("transaction_count")]
        public int TransactionCount { get; set; }

        [JsonProperty("open_orders")]
        public int OpenOrderCount { get; set; }

        [JsonProperty("server_time")]
        public int ServerTime { get; set; }

        [JsonProperty("funds")]
        public Funds Funds { get; set; }

        [JsonProperty("rights")]
        public ApiPermissions Permissions { get; set; }
    }
}