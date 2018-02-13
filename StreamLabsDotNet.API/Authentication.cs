using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API
{
    public class Authentication : ApiBase
    {
        public async Task<string> AuthorizeAsync(string responseType, string clientId, string redirectUri, string scope, string state)
        {
            if (string.IsNullOrWhiteSpace(responseType)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(clientId)) throw new BadParameterException("The extension id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(redirectUri)) throw new BadParameterException("The extension version is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(scope)) throw new BadParameterException("The extension owner id is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "authorize";
            var payload = new Dictionary<string, object> {
                { "response_type",responseType},
                { "client_id",clientId},
                { "redirect_uri",redirectUri},
                { "scope",scope},
                { "state",state}
            };
            return JsonConvert.DeserializeObject<string>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<TokenResponse> GetTokenAsync(string grantType, string clientId, string clientSecret, string redirectUri, string code, string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(grantType)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(clientId)) throw new BadParameterException("The extension id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new BadParameterException("The extension version is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(redirectUri)) throw new BadParameterException("The extension owner id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (grantType == "authorization_code" && string.IsNullOrWhiteSpace(code)) throw new Exception("broke");
            if (grantType == "refresh_token" && string.IsNullOrWhiteSpace(refreshToken)) throw new Exception("broke");

            var url = "token";
            var payload = new Dictionary<string, object> {
                { "response_type",grantType},
                { "client_id",clientId},
                { "client_secret",clientSecret},
                { "redirect_uri",redirectUri}
            };
            if (grantType == "authorization_code")
            {
                payload.Add("code", code);
            }
            if (grantType == "refresh_token")
            {
                payload.Add("refresh_token", refreshToken);

            }
            return JsonConvert.DeserializeObject<TokenResponse>((await GeneralRequestAsync(url, "Post", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
    }
}
