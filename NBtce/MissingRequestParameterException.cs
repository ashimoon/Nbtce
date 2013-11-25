using System;

namespace NBtce
{
    public class MissingRequestParameterException : Exception
    {
        private readonly string _key;

        public MissingRequestParameterException(string key)
        {
            _key = key;
        }

        public string Key
        {
            get { return _key; }
        }
    }
}