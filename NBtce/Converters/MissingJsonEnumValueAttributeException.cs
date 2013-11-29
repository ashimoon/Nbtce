using System;

namespace NBtce.Converters
{
    public class MissingJsonEnumValueAttributeException : Exception
    {
        private readonly Type _enumType;
        private readonly string _member;

        public MissingJsonEnumValueAttributeException(Type enumType, string member)
        {
            _enumType = enumType;
            _member = member;
        }

        public Type EnumType
        {
            get { return _enumType; }
        }

        public string Member
        {
            get { return _member; }
        }
    }
}