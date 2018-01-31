using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class TwitchCheerMessage : BaseMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("emotes")]
        public object Emotes { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
