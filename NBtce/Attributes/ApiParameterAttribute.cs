using System;

namespace NBtce.Attributes
{
    public class ApiParameterAttribute : Attribute
    {
        public bool Required { get; set; }

        public string Name { get; set; }

        public Type ParameterMapper { get; set; }

        public ApiParameterAttribute(string name)
        {
            Name = name;
        }
    }
}