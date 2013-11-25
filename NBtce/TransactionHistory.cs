using System.Collections.Generic;
using Newtonsoft.Json;

namespace NBtce
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TransactionHistory : Dictionary<int, Transaction>
    {
    }
}