using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class Wallet
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Balances
        {
            [JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
            public int _85ad13f73d1b51289eb27cd8ee0b5741 { get; set; }

            [JsonProperty("e59aa87c-4cbf-517a-5983-6e81511be9b7")]
            public int E59aa87c4cbf517a59836e81511be9b7 { get; set; }

            [JsonProperty("f08d4ae3-939c-4576-ab26-09ce1f23bb37")]
            public int F08d4ae3939c4576Ab2609ce1f23bb37 { get; set; }
        }

        public class Root
        {
            public Balances Balances { get; set; }
        }
    }


    public class Currency
    {
        //User defined so ez to understand

        public int ValorantPoints;
        public int Radianite;
    }
}
