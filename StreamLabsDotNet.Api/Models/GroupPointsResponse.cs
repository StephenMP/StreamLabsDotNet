using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class GroupPointsResponse
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("time_watched")]
        public long TimeWatched { get; set; }
    }
}
