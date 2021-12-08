using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwapperValorant
{
    public class Config
    {
        private static string ConfigPath = Program.ProSwapperFolder + "config.json";

        public static ConfigObj CurrentConfig;
        public static void InitConfig()
        {
            if (!File.Exists(ConfigPath))
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(new ConfigObj()));

            CurrentConfig = JsonConvert.DeserializeObject<ConfigObj>(File.ReadAllText(ConfigPath));
        }
        public static void SaveConfig()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(CurrentConfig));
        }

        public class Preset
        {
            public string Name { get; set; }
            public ValorantAPI.RiotClientAPI.RiotJsonStructs.Loadout.Root Loadout { get; set; } = null;
        }

        public class ConfigObj
        {
            public Preset[] Presets { get; set; } = null;
        }
    }
}
