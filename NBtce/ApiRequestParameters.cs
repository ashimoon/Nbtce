using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NBtce.Attributes;
using NBtce.Mappers;

namespace NBtce
{
    public class ApiRequestParameters : List<KeyValuePair<string,string>>
    {
        public string this[string key]
        {
            get { return this.Single(x => x.Key == key).Value; }
            set { Add(key, value); }
        }

        public ApiRequestParameters(object request, INonceProvider nonceProvider)
        {
            var requestAttribute = request.GetType().GetCustomAttribute<ApiRequestAttribute>();
            if (requestAttribute == null)
            {
                throw new MissingRequestParameterException("method");
            }

            Add("method", requestAttribute.MethodName);
            Add("nonce", nonceProvider.GetNext().ToString(CultureInfo.InvariantCulture));

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

        private void Add(string key, string value)
        {
            if (this.Any(x => x.Key == key))
            {
                throw new DuplicateNameException("There is already a parameter with the name " + key);
            }
            Add(new KeyValuePair<string, string>(key, value));
        }

        public string BuildPostContent()
        {
            return Count == 0 ? null : string.Join("&", this.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
        }
    }
}