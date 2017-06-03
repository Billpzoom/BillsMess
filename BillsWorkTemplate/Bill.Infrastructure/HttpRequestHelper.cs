using System;
using System.Net;

namespace Bill.Infrastructure
{
    public class HttpRequestHelper
    {
        public static HttpWebResponse GetHttpWebResponse(string href, string method, byte[] data)
        {
            try
            {
                var aHttpWebRequest = (HttpWebRequest) WebRequest.Create(href);
                aHttpWebRequest.Timeout = 30000;
                aHttpWebRequest.Headers.Set("Pragma", "no-cache");

                if (null != data)
                {
                    aHttpWebRequest.ContentLength = data.Length;
                    using (var newStream = aHttpWebRequest.GetRequestStream())
                    {
                        newStream.Write(data, 0, data.Length);
                    }
                }
                var response = aHttpWebRequest.GetResponse() as HttpWebResponse;
                return response;
            }
            catch (WebException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}