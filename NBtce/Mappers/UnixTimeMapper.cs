using System;
using System.Globalization;

namespace NBtce.Mappers
{
    public class UnixTimeMapper : IApiParameterMapper
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public string MapToString(object parameter)
        {
            return UnixTime.At((DateTime)parameter).ToString(CultureInfo.InvariantCulture);
        }
    }
}