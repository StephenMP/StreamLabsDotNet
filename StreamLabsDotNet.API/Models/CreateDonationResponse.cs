using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API.Models
{
    public partial class CreateDonationResponse
    {
        [JsonProperty("donation_id")]
        public long DonationId { get; set; }
    }
}
