using Newtonsoft.Json;

namespace StreamLabsDotNet.API.Models
{
    public partial class DonationsResponse
    {
        [JsonProperty("data")]
        public DonationResponse[] Data { get; set; }
    }

   
}
