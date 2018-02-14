using Newtonsoft.Json;
using StreamLabsDotNet.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StreamLabsDotNet.API
{
    public class Users : StreamlabsApiBase
    {
        public async Task<UserResponse> GetUserAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "user";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };
            return JsonConvert.DeserializeObject<UserResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
    }
}
