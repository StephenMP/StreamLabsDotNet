using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Client.Models
{
    public class YouTubeSuperchatMessage : BaseMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("channelUrl")]
        public string ChannelUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("displayString")]
        public string DisplayString { get; set; }

        [JsonProperty("messageType")]
        public long MessageType { get; set; }

        [JsonProperty("createdAt")]
        public System.DateTime CreatedAt { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
