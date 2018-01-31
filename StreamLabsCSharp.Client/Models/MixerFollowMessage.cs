using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class MixerFollowMessage : BaseMessage
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public System.DateTime CreatedAt { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
