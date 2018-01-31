using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.Client.Models
{
    public class DonationMessage : BaseMessage
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        private string Name { get; set; }
        
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("formatted_amount")]
        public string Formatted_Amount { get; set; }

        [JsonProperty("formattedAmount")]
        public string FormattedAmount { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("emotes")]
        public object Emotes { get; set; }

        [JsonProperty("isTest")]
        public bool IsTest { get; set; }

        [JsonProperty("iconClassName")]
        public string IconClassName { get; set; }

        [JsonProperty("to")]
        public To To { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("from_user_id")]
        public object FromUserId { get; set; }

        [JsonProperty("_id")]
        public string _Id { get; set; }
    }

    public class To
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
