using System;
using System.Globalization;

namespace NBtce.Mappers
{
    public class UnixTimeMapper : IApiParameterMapper
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public string MapToString(object parameter)
        {
            return ((long) (((DateTime)parameter).ToUniversalTime() - UnixEpoch).TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }
    }
}