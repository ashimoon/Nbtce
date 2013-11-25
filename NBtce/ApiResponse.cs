using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NBtce
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiResponse<TResponse>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("return")]
        public TResponse Return { get; set; }

        [JsonProperty("error")]
        public string ErrorText { get; set; }
    }
}
