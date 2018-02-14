using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace StreamLabsDotNet.API
{
    public abstract class StreamlabsApiBase
    {
        private const string _apiUrl = "https://streamlabs.com/api/v1.0/{0}";

        protected enum RequestType
        {
            Query,
            Body
        }

        protected async Task<KeyValuePair<int, string>> GeneralRequestAsync(string url, string method, Dictionary<string,object> requestParameters, RequestType requesttype )
        {
            //Work out payload first 
            var payload = string.Empty;
            var firstItem = true;
            foreach (var item in requestParameters)
            {
                var separator = firstItem ? "" : "&";
                payload += $"{separator}{item.Key}={item.Value}";
                firstItem = false;
            }

            if (requesttype == RequestType.Query)
            {
                url = $"{url}?{payload}";
            }

            var request = WebRequest.CreateHttp(string.Format(_apiUrl, url));
            request.Method = method;
            request.ContentType = "application/json";
            
            if (requesttype == RequestType.Body)
            {
                using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
                    writer.Write(payload);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string data = reader.ReadToEnd();
                    return new KeyValuePair<int, string>((int)response.StatusCode, data);
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }

            return new KeyValuePair<int, string>(0, null);
        }

        protected int GetEpoch()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch;
        }
        
        private static void HandleWebException(WebException e)
        {
            HttpWebResponse errorResp = e.Response as HttpWebResponse;
            if (errorResp == null)
                throw e;
            switch (errorResp.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException("Your request failed because either: \n 1. Your ClientID was invalid/not set.\n 2. You requested a username when the server was expecting a user ID.");
                case HttpStatusCode.Unauthorized:
                    throw new BadScopeException("Your request was blocked due to bad credentials (do you have the right scope for your access token?).");
                case HttpStatusCode.NotFound:
                    throw new BadResourceException("The resource you tried to access was not valid.");
                default:
                    throw e;
            }
        }
    }
}
