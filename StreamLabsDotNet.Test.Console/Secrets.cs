using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Test.Console
{
    public static class Secrets
    {
        private const string _secret = "{{SECRET_GOES_HERE}}";
        public static string Secret()
        {
            return _secret;
        }
        private const string _clientId = "{{CLIENT_ID_GOES_HERE}}";
        public static string ClientId()
        {
            return _clientId;
        }
    }
}
