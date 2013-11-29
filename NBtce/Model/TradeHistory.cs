using System.Collections.Generic;
using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject]
    [JsonConverter(typeof(DictionaryObjectConverter<int, ExecutedTrade>))]
    public class TradeHistory : Dictionary<int,ExecutedTrade>
    {
        
    }
}