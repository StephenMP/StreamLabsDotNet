using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API.Models
{
    public partial class LegacyTokenResponse
    {
        [JsonProperty("token")]
        public bool Token { get; set; }
    }
}
