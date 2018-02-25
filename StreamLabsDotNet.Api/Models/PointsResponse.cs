using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class PointsResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("exp")]
        public long Exp { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("ta_id")]
        public object TaId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time_watched")]
        public long TimeWatched { get; set; }

        [JsonProperty("created_at")]
        public object CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
