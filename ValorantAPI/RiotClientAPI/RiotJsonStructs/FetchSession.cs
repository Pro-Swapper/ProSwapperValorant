using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class FetchSession
    {
        public bool federated { get; set; }
        public string game_name { get; set; }
        public string game_tag { get; set; }
        public bool loaded { get; set; }
        public string name { get; set; }
        public string pid { get; set; }
        public string puuid { get; set; }
        public string region { get; set; }
        public string resource { get; set; }
        public string state { get; set; }
    }
}
