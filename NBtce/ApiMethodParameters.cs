using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NBtce.Attributes;
using NBtce.Mappers;

namespace NBtce
{
    public class ApiMethodParameters : Dictionary<string,string>
    {
        public ApiMethodParameters(object request)
        {
            var requestAttribute = request.GetType().GetCustomAttribute<ApiRequestAttribute>();
            if (requestAttribute == null)
            {
                throw new MissingRequestParameterException("method");
            }

            Add("method", requestAttribute.MethodName);

            foreach (var property in request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
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

        public string BuildPostContent()
        {
            return Count == 0 ? null : string.Join("&", this.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
        }
    }
}