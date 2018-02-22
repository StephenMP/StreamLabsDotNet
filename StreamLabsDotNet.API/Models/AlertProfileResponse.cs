using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class AlertProfileResponse
    {
        [JsonProperty("profiles")]
        public AlertProfile[] Profiles { get; set; }

        [JsonProperty("active_profile")]
        public long ActiveProfile { get; set; }
    }
    public partial class AlertProfile
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("active")]
        public long? Active { get; set; }
    }

}
