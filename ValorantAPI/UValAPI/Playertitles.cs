using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.UValAPI
{
    public class Playertitles
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Datum
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string titleText { get; set; }
            public bool isHiddenIfNotOwned { get; set; }
            public string assetPath { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public List<Datum> data { get; set; }
        }


    }
}
