using System;

namespace NBtce
{
    public class BtcePortalException : Exception
    {
        public BtcePortalException(string message, Exception exception) : base(message, exception)
        {
        }

        public BtcePortalException(string message) : base(message)
        {
        }
    }
}