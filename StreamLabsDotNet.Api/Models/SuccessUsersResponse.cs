using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class SuccessUsersResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("Users")]
        public string users { get; set; }
    }
}
