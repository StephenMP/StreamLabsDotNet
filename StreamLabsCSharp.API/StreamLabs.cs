using Newtonsoft.Json;
using StreamLabsCSharp.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace StreamLabsCSharp.API
{
    public class StreamLabs
    {
        private const string _apiUrl = "https://streamlabs.com/api/v1.0/{0}";

        private enum RequestType
        {
            Query,
            Body
        }

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
        public async Task<UserResponse> GetUserAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "user";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };
            return JsonConvert.DeserializeObject<UserResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<DonationsResponse> GetDonationsAsync(string accessToken, int? limit = null, int? after = null, int? before = null, string currency = null, bool? verified = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "donations";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            if(limit.HasValue) payload.Add("limit", limit.Value);
            if (after.HasValue) payload.Add("after", after.Value);
            if (before.HasValue) payload.Add("before", before.Value);
            if (!string.IsNullOrEmpty(currency)) payload.Add("currency", currency);
            if (verified.HasValue) payload.Add("verified", verified.Value ? "1" : "0");

            return JsonConvert.DeserializeObject<DonationsResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<CreateDonationResponse> CreateDonationAsync(string accessToken, string name, string identifier, double amount, string currency, string message = null, DateTime? createdAt = null  )
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(name)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(identifier)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(currency)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (amount <= 0) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "donations";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "name",name},
                { "identifier",identifier},
                { "amount",amount},
                { "currency",currency}
            };
            
            if (!string.IsNullOrEmpty(message)) payload.Add("message", message);
            if (createdAt.HasValue) payload.Add("created_at", GetEpoch());

            return JsonConvert.DeserializeObject<CreateDonationResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> CreateAlertAsync(string accessToken, string type, string imageHref=null, string soundHref = null, string message = null, int? durationMilliseconds = null, string specialTextColour=null)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(type)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            
            var url = "alerts";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "type",type}
            };

            if (!string.IsNullOrEmpty(imageHref)) payload.Add("image_href", message);
            if (!string.IsNullOrEmpty(soundHref)) payload.Add("sound_href", message);
            if (!string.IsNullOrEmpty(message)) payload.Add("message", message);
            if (!string.IsNullOrEmpty(specialTextColour)) payload.Add("special_text_color", specialTextColour);
            if (durationMilliseconds.HasValue) payload.Add("duration", durationMilliseconds.Value);

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Body).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> SkipAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
           
            var url = "alerts/skip";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> MuteVolumeAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/mute_volume";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> UnmuteVolumeAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/unmute_volume";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> PauseQueueAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/pause_queue";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> UnpauseQueueAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/unpause_queue";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> SendTestAlertAsync(string accessToken, string type)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(type)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/send_test_alert";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "type",type}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> ShowVideoAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/show_video";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> HideVideoAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/hide_video";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

        private async Task<KeyValuePair<int, string>> GeneralRequestAsync(string url, string method, Dictionary<string,object> requestParameters, RequestType requesttype )
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

            }

            return new KeyValuePair<int, string>(0, null);
        }
        private int GetEpoch()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch;
        }
    }
}
