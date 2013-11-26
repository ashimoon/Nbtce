using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NBtce.Converters
{
    public class DictionaryObjectConverter<TKey, TValue> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<IDictionary<TKey, TValue>>(reader);
            var obj = (IDictionary<TKey,TValue>)Activator.CreateInstance(objectType);
            foreach (var item in dictionary)
            {
                obj.Add(item);
            }
            return obj;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary<TKey,TValue>).IsAssignableFrom(objectType);
        }
    }
}