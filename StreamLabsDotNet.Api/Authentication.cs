using Newtonsoft.Json;
using StreamLabsDotNet.Api.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StreamLabsDotNet.Api
{
    public class Authentication : StreamLabsApiBase
    {
        public Authentication(ILogger<StreamLabsApiBase> logger) : base(logger)
        {

        }
        public async Task<string> AuthorizeAsync(string responseType, string clientId, string redirectUri, string scope, string state)
        {
            if (string.IsNullOrWhiteSpace(responseType)) throw new BadParameterException("Response Type is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(clientId)) throw new BadParameterException("Client Id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(redirectUri)) throw new BadParameterException("Redirect Uri is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrEmpty(scope)) throw new BadParameterException("Scope is not valid. It is not allowed to be null or empty.");

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
            if (string.IsNullOrWhiteSpace(grantType)) throw new BadParameterException("Grant Type is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(clientId)) throw new BadParameterException("Client Id is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new BadParameterException("Client Secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(redirectUri)) throw new BadParameterException("Redirect Uri is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            if (grantType == "authorization_code" && string.IsNullOrWhiteSpace(code)) throw new Exception("If Grant Type is authorization_code you need to supply code");
            if (grantType == "refresh_token" && string.IsNullOrWhiteSpace(refreshToken)) throw new Exception("If Grant Type is refresh_token you need to supply refreshToken");

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
