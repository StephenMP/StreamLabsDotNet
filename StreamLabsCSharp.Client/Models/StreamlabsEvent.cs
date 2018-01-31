using Newtonsoft.Json;

namespace StreamLabsCSharp.Client.Models
{
    public class StreamlabsEvent
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }

        [JsonProperty(PropertyName = "for")]
        public string For { get; protected set; }

        [JsonProperty(PropertyName = "event_id")]
        public string EventId { get; protected set; }

        //[JsonProperty(PropertyName = "message", ItemConverterType =typeof(MessageConverter))]
        //public BaseMessage[] Message { get; protected set; }
    }
    public class StreamlabsEvent<T>
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }

        [JsonProperty(PropertyName = "for")]
        public string For { get; protected set; }

        [JsonProperty(PropertyName = "event_id")]
        public string EventId { get; protected set; }

        [JsonProperty(PropertyName = "message")]
        public T[] Message { get; protected set; }
    }
}
