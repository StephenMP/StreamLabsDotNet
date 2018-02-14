using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API.Models
{
    public partial class SocketResponse
    {
        [JsonProperty("socket_token")]
        public string SocketToken { get; set; }
    }
}
