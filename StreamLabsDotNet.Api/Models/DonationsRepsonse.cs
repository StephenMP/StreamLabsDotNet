using Newtonsoft.Json;

namespace StreamLabsDotNet.Api.Models
{
    public partial class DonationsResponse
    {
        [JsonProperty("data")]
        public DonationResponse[] Data { get; set; }
    }

   
}
