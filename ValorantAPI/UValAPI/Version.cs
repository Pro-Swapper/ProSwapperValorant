using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.UValAPI
{
    public class ValVersion
    {
        public class Data
        {
            public string manifestId { get; set; }
            public string branch { get; set; }
            public string version { get; set; }
            public string buildVersion { get; set; }
            public string riotClientVersion { get; set; }
            public DateTime buildDate { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public Data data { get; set; }
        }
    }
}
