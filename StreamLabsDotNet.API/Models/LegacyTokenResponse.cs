using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class LegacyTokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
