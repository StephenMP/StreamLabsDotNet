using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Client.Models
{
    public class MixerSubscriptionMessage : BaseMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("months")]
        public long Months { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("emotes")]
        public object Emotes { get; set; }

        [JsonProperty("since")]
        public DateTime Since { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
