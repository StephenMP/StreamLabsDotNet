using Newtonsoft.Json;

namespace StreamLabsCSharp.API.Models
{
    public partial class DonationsResponse
    {
        [JsonProperty("data")]
        public DonationResponse[] Data { get; set; }
    }

   
}
