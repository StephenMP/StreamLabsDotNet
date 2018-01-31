using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class StreamlabelsEvent
    {
       
            [JsonProperty(PropertyName = "type")]
            public string Type { get; protected set; }

            [JsonProperty(PropertyName = "for")]
            public string For { get; protected set; }

            [JsonProperty(PropertyName = "event_id")]
            public string EventId { get; protected set; }

            [JsonProperty(PropertyName = "message")]
            public StreamlabelsMessage Message { get; protected set; }
        
    }
}
