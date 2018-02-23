using Newtonsoft.Json;

namespace StreamLabsDotNet.Api.Models
{
    public partial class DonationResponse
    {
        [JsonProperty("donation_id")]
        public string DonationId { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
