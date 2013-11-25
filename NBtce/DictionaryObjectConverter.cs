using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NBtce
{
    public class DictionaryObjectConverter<TObject, TKey, TValue> : JsonConverter where TObject : IDictionary<TKey, TValue>, new()
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<IDictionary<TKey, TValue>>(reader);
            var obj = new TObject();
            foreach (var item in dictionary)
            {
                obj.Add(item);
            }
            return obj;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (TObject).IsAssignableFrom(objectType);
        }
    }
}