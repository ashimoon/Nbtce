using System;

namespace NBtce.Attributes
{
    public class JsonEnumValueAttribute : Attribute
    {
        private readonly string _name;

        public JsonEnumValueAttribute(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}