using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NBtce.Converters
{
    public class EnumValueConverter<TEnum> : JsonConverter
    {
        private readonly IDictionary<TEnum,string> _toStringMapping = new EnumToStringMapping<TEnum>();
        private readonly IDictionary<string,TEnum> _toEnumMapping = new StringToEnumMapping<TEnum>();
 
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(_toStringMapping[(TEnum)value]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = serializer.Deserialize<string>(reader);
            return _toEnumMapping[enumString];
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (TEnum).IsAssignableFrom(objectType);
        }
    }
}