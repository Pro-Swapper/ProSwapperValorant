using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class Entitlements
    {
        public class Entitlement
        {
            public string TypeID { get; set; }
            public string ItemID { get; set; }
            public string InstanceID { get; set; }
        }

        public class EntitlementsByType
        {
            public string ItemTypeID { get; set; }
            public List<Entitlement> Entitlements { get; set; }
        }

        public class Root
        {
            public List<EntitlementsByType> EntitlementsByTypes { get; set; }
        }
    }
}
