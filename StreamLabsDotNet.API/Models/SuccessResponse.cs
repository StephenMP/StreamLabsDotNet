using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API.Models
{
    public partial class SuccessResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
