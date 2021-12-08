using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class Token
    {
        //accessToken is used as the token and token is used as the entitlement.
        public string accessToken { get; set; }
        public List<object> entitlements { get; set; }
        public string issuer { get; set; }
        public string subject { get; set; }
        public string token { get; set; }
    }
}
