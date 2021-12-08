using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class ExternalSessions
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class LaunchConfiguration
        {
            public List<string> arguments { get; set; }
            public string executable { get; set; }
            public string locale { get; set; }
            public object voiceLocale { get; set; }
            public string workingDirectory { get; set; }
        }

        public class Root
        {
            public int exitCode { get; set; }
            public object exitReason { get; set; }
            public bool isInternal { get; set; }
            public LaunchConfiguration launchConfiguration { get; set; }
            public string patchlineFullName { get; set; }
            public string patchlineId { get; set; }
            public string phase { get; set; }
            public string productId { get; set; }
            public string version { get; set; }
        }




    }
}
