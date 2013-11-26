using System;
using System.Collections.Generic;
using System.Reflection;
using NBtce.Attributes;
using NBtce.Mappers;

namespace NBtce
{
    public class ApiRequest<TRequest> : Dictionary<string,string>
    {
        public ApiRequest(TRequest request)
        {
            foreach (var property in typeof (TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attribute = property.GetCustomAttribute<ApiParameterAttribute>();
                if (attribute == null) continue;
                
                var parameterValue = property.GetValue(request);
                if (parameterValue == null) continue;
                
                if (attribute.ParameterMapper != null)
                {
                    var mapper = (IApiParameterMapper) Activator.CreateInstance(attribute.ParameterMapper);
                    Add(attribute.Name, mapper.MapToString(parameterValue));
                }
                else
                {
                    Add(attribute.Name, parameterValue.ToString());
                }
            }
        }
    }
}