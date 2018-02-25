using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class UserPointsResponse
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("last_page")]
        public long LastPage { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }
    public partial class Datum
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("time_watched")]
        public long TimeWatched { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }
    }
}
