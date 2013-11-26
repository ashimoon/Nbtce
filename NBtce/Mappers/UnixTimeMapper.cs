using System;
using System.Globalization;

namespace NBtce.Mappers
{
    public class UnixTimeMapper : IApiParameterMapper<DateTime>
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public string ToString(DateTime parameter)
        {
            return ((long) (parameter.ToUniversalTime() - UnixEpoch).TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }
    }
}