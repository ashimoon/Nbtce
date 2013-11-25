using Newtonsoft.Json;

namespace NBtce
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiPermissions
    {
        [JsonProperty("info")]
        public bool Information { get; set; }

        [JsonProperty("trade")]
        public bool Trade { get; set; }
    }
}