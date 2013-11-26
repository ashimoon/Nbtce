using System.Collections.Generic;
using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(DictionaryObjectConverter<int,Transaction>))]
    public class TransactionHistory : Dictionary<int, Transaction>
    {
    }
}