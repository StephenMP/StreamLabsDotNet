using Newtonsoft.Json;
using StreamLabsDotNet.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StreamLabsDotNet.API
{
    public class Sockets : StreamlabsApiBase
    {
        public async Task<SocketResponse> GetSocketTokenAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "socket/token";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };
            return JsonConvert.DeserializeObject<SocketResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
    }
}
