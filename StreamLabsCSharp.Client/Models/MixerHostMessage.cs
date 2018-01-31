using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class MixerHostMessage : BaseMessage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("viewers")]
        public string Viewers { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
