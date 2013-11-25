using System;
using System.Globalization;

namespace NBtce
{
    public class UnixTimeParameterConverter : IApiParameterConverter<DateTime>
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public string Convert(DateTime input)
        {
            return ((long) (input.ToUniversalTime() - UnixEpoch).TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }
    }
}