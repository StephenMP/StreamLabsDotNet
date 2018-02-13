using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API
{
    public class Alerts : ApiBase
    {
        public async Task<AlertResponse> CreateAlertAsync(string accessToken, string type, string imageHref = null, string soundHref = null, string message = null, int? durationMilliseconds = null, string specialTextColour = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Type is not valid. It is not allowed to be null, empty or filled with whitespaces.");

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
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/skip";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> MuteVolumeAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/mute_volume";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> UnmuteVolumeAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/unmute_volume";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> PauseQueueAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/pause_queue";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> UnpauseQueueAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/unpause_queue";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> SendTestAlertAsync(string accessToken, string type)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(type)) throw new BadParameterException("Type is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/send_test_alert";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "type",type}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> ShowVideoAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/show_video";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<AlertResponse> HideVideoAlertAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alerts/hide_video";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

    }
}
