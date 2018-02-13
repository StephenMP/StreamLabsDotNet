using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Client.Models
{
    public class StreamlabelsMessage : BaseMessage
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }
    }
    

}
