using System.Collections.Generic;
using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject]
    [JsonConverter(typeof(DictionaryObjectConverter<int,Trade>))]
    public class TradeHistory : Dictionary<int,Trade>
    {
        
    }
}