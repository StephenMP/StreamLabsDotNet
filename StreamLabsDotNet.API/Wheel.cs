﻿using Newtonsoft.Json;
using StreamLabsDotNet.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StreamLabsDotNet.Api
{
    public class Wheel : StreamLabsApiBase
    {
        public Wheel(ILogger<Wheel> logger) : base(logger)
        {

        }
        public async Task<SuccessResponse> SpinWheelAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "wheel/spin";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<SuccessResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

    }
}
