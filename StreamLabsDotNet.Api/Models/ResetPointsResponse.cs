using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class ResetPointsResponse
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
