using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NBtce.Attributes;

namespace NBtce.Converters
{
    public class StringToEnumMapping<TEnum> : Dictionary<string, TEnum>
    {
        public StringToEnumMapping()
        {
            foreach (var enumValue in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                var attribute = typeof(TEnum).GetMember(enumValue.ToString())
                                             .Single()
                                             .GetCustomAttribute<JsonEnumValueAttribute>();
                if (attribute == null)
                {
                    throw new MissingJsonEnumValueAttributeException(typeof(TEnum), enumValue.ToString());
                }
                Add(attribute.Name, enumValue);
            }
        }
    }
}