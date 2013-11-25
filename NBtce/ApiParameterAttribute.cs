using System;

namespace NBtce
{
    public class ApiParameterAttribute : Attribute
    {
        public bool Required { get; set; }

        public string Name { get; set; }

        public Type ParameterConverter { get; set; }

        public ApiParameterAttribute(string name)
        {
            Name = name;
        }
    }
}