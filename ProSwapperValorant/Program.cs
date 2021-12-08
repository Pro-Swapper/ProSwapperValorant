using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSwapperValorant
{
    internal static class Program
    {
        // Pro Swapper global api
        public class Status
        {
            public bool IsUp { get; set; }
            public string DownMsg { get; set; }
        }

        public class Root
        {
            public List<Status> status { get; set; }
            public string version { get; set; }
            public string discordurl { get; set; }
        }

        public static string ProSwapperFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Pro_Swapper\Valorant\";
        public static Logger logger { get; private set; }

        public static string DiscordLink = "";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.CreateDirectory(ProSwapperFolder);
            Directory.CreateDirectory(ProSwapperFolder + "\\Images");
            logger = new Logger(ProSwapperFolder + "Log.log");
            try
            {
                Config.InitConfig();
                using (WebClient wc = new WebClient())
                {
                    DiscordLink = JsonConvert.DeserializeObject<Root>(wc.DownloadString("https://raw.githubusercontent.com/Pro-Swapper/api/main/global.json")).discordurl;
                }
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            
        }
    }
}
