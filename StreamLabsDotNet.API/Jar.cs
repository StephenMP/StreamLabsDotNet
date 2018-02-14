using Newtonsoft.Json;
using StreamLabsDotNet.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StreamLabsDotNet.API
{
    public class Jar : StreamlabsApiBase
    {
        public async Task<SuccessResponse> EmptyJarAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "jar/empty";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<SuccessResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

    }
}
