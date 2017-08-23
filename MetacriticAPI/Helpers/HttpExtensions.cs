using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace MetacriticAPI.Helpers
{
    public static class HttpExtensions
    {
        private const string HttpContext = "MS_HttpContext";

        public static string GetClientIP(HttpRequestMessage request)
        {
            string ip = string.Empty;
            if (request.Properties.ContainsKey(HttpContext))
            {
                var ctx = request.Properties[HttpContext] as HttpContextWrapper;
                if (ctx != null)
                {
                    ip = ctx.Request.UserHostAddress;
                }
            }

            return ip;
        }
    }
}