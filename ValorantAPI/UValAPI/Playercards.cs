using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.UValAPI
{
    public class Playercards
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Datum
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public bool isHiddenIfNotOwned { get; set; }
            public object themeUuid { get; set; }
            public string displayIcon { get; set; }
            public string smallArt { get; set; }
            public string wideArt { get; set; }
            public string largeArt { get; set; }
            public string assetPath { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public List<Datum> data { get; set; }
        }


    }
}
