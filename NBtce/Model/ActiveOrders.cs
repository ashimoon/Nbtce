using System.Collections.Generic;
using NBtce.Converters;
using Newtonsoft.Json;

namespace NBtce.Model
{
    [JsonObject]
    [JsonConverter(typeof(DictionaryObjectConverter<int,Order>))]
    public class ActiveOrders : Dictionary<int,Order>
    {    
    }
}