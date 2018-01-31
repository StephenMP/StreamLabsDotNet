using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class YouTubeSubscriptionMessage : BaseMessage
    {

        [JsonProperty("publishedAt")]
        public System.DateTime PublishedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
