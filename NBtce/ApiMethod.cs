﻿using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace NBtce
{
    public abstract class ApiMethod<TResponse>
    {
        private const string ApiRequestUri = "https://btc-e.com/tapi";
       
        public ApiResponse<TResponse> Submit(string apiKey, string secret)
        {
            var parameters = new ApiMethodParameters(this);
            var encoding = new ASCIIEncoding();
            var content = encoding.GetBytes(parameters.BuildPostContent());

            var post = WebRequest.CreateHttp(ApiRequestUri);
            post.Method = "POST";
            post.Headers["Key"] = apiKey;
            using (var hmac = new HMACSHA512(encoding.GetBytes(secret)))
            {
                post.Headers["Sign"] = encoding.GetString(hmac.ComputeHash(content));
            }
            post.ContentType = "application/x-www-form-urlencoded";
            post.ContentLength = content.Length;

            using (var stream = post.GetRequestStream())
            {
                stream.Write(content, 0, content.Length);
            }

            var responseStream = post.GetResponse().GetResponseStream();
            if (responseStream == null) return null;
            string returnEntity = new StreamReader(responseStream).ReadToEnd();
            return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(returnEntity);
        }
       

    }
}