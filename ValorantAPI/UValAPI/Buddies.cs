using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.UValAPI
{
    public class Buddies
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Level
        {
            public string uuid { get; set; }
            public int charmLevel { get; set; }
            public string displayName { get; set; }
            public string displayIcon { get; set; }
            public string assetPath { get; set; }
        }

        public class Datum
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public bool isHiddenIfNotOwned { get; set; }
            public string themeUuid { get; set; }
            public string displayIcon { get; set; }
            public string assetPath { get; set; }
            public List<Level> levels { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public List<Datum> data { get; set; }
        }




    }
}
