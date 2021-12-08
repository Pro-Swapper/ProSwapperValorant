using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class Loadout
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Gun
        {
            public string ID { get; set; }
            public string SkinID { get; set; }
            public string SkinLevelID { get; set; }
            public string ChromaID { get; set; }
            public string CharmInstanceID { get; set; }
            public string CharmID { get; set; }
            public string CharmLevelID { get; set; }
            public List<object> Attachments { get; set; }
        }

        public class Spray
        {
            public string EquipSlotID { get; set; }
            public string SprayID { get; set; }
            public object SprayLevelID { get; set; }
        }

        public class Identity
        {
            public string PlayerCardID { get; set; }
            public string PlayerTitleID { get; set; }
            public int AccountLevel { get; set; }
            public string PreferredLevelBorderID { get; set; }
            public bool HideAccountLevel { get; set; }
        }

        public class Root
        {
            public string Subject { get; set; }
            public int Version { get; set; }
            public List<Gun> Guns { get; set; }
            public List<Spray> Sprays { get; set; }
            public Identity Identity { get; set; }
            public bool Incognito { get; set; }
        }


    }
}
