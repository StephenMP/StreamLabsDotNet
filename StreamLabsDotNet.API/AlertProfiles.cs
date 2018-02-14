using Newtonsoft.Json;
using StreamLabsDotNet.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StreamLabsDotNet.API
{
    public class AlertProfiles : StreamlabsApiBase
    {
        public async Task<AlertProfileResponse> GetAlertProfilesAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alert_profiles/get";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<AlertProfileResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<SuccessResponse> ActivateAlertProfileAsync(string accessToken, string id)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(id)) throw new BadParameterException("Id is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "alert_profiles/activate";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "id",id}
            };

            return JsonConvert.DeserializeObject<SuccessResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

    }
}
