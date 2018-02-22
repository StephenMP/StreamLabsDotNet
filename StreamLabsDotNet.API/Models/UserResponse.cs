using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class UserResponse
    {
        [JsonProperty("streamlabs")]
        public StreamlabsUser Streamlabs { get; set; }

        [JsonProperty("twitch")]
        public Twitch Twitch { get; set; }

        [JsonProperty("youtube")]
        public Youtube Youtube { get; set; }

        [JsonProperty("mixer")]
        public Mixer Mixer { get; set; }

        [JsonProperty("facebook")]
        public Facebook Facebook { get; set; }
    }

    public partial class Facebook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Mixer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class StreamlabsUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }

    public partial class Twitch
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Youtube
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }


}
