using System;

namespace NBtce
{
    public class UnixTime
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long Now
        {
            get { return (long) (DateTime.Now.ToUniversalTime() - UnixEpoch).TotalSeconds; }
        }

        public static long At(DateTime time)
        {
            return ((long) ((time).ToUniversalTime() - UnixEpoch).TotalSeconds);
        }
    }
}