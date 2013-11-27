using NBtce.Converters;

namespace NBtce.Mappers
{
    public class EnumMapper<TEnum> : IApiParameterMapper
    {
        public string MapToString(object parameter)
        {
            var mapping = new EnumToStringMapping<TEnum>();
            return mapping[(TEnum) parameter];
        }
    }
}