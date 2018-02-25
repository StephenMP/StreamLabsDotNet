using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api.Models
{
    public partial class BadRequestResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
