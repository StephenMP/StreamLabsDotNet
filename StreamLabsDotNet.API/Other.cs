using Newtonsoft.Json;
using StreamLabsDotNet.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StreamLabsDotNet.Api
{
    public class Other : StreamLabsApiBase
    {
        public Other(ILogger<Other> logger) : base(logger)
        {

        }
        public async Task<LegacyTokenResponse> GetLegacyTokenAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "legacy/token";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };
            return JsonConvert.DeserializeObject<LegacyTokenResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
    }
}
