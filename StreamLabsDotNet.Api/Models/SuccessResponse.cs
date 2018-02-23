using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class SuccessResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
