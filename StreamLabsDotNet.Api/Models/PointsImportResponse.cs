using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class PointsImportResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("users")]
        public long Users { get; set; }
    }
}
