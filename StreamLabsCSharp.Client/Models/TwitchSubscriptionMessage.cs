using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class TwitchSubscriptionMessage : BaseMessage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("months")]
        public long Months { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("emotes")]
        public object Emotes { get; set; }

        [JsonProperty("sub_plan")]
        public long SubPlan { get; set; }

        [JsonProperty("sub_plan_name")]
        public string SubPlanName { get; set; }

        [JsonProperty("sub_type")]
        public string SubType { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }

}
