using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsCSharp.API.Models
{
    public partial class CreateDonationResponse
    {
        [JsonProperty("donation_id")]
        public long DonationId { get; set; }
    }
}
