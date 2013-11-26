using System;
using System.Collections.Generic;
using System.Linq;
using NBtce.Attributes;

namespace NBtce.Converters
{
    public class EnumToStringMapping<TEnum> : Dictionary<TEnum, string>
    {
        public EnumToStringMapping()
        {
            foreach (var enumValue in Enum.GetValues(typeof (TEnum)).Cast<TEnum>())
            {
                var attribute =
                    typeof (TEnum).GetMember(enumValue.ToString())
                                  .Single()
                                  .GetCustomAttributes(typeof (JsonEnumValueAttribute), false)
                                  .Cast<JsonEnumValueAttribute>()
                                  .Single();
                Add(enumValue, attribute.Name);
            }
        }
    }
}