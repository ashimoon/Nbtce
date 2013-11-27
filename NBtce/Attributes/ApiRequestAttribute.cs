using System;

namespace NBtce.Attributes
{
    public class ApiRequestAttribute : Attribute
    {
        private readonly string _methodName;

        public ApiRequestAttribute(string methodName)
        {
            _methodName = methodName;
        }

        public string MethodName
        {
            get { return _methodName; }
        }
    }
}