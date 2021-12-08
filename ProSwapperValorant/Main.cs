using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValorantAPI;
using ValorantAPI.RiotClientAPI;
using Newtonsoft.Json;
using ValorantAPI.RiotClientAPI.RiotJsonStructs;
namespace ProSwapperValorant
{
    //Color pallet: https://material.io/resources/color/#!/?view.left=0&view.right=0&primary.color=424242
    public partial class Main : Form
    {
        //Store global vars here
        public static ValorantAPI.UValAPI.ValVersion.Root? ValVersion { get; private set; }
        public static ValorantAPI.UValAPI.Weapons.Root? Weapons { get; private set; }
        public static ValorantAPI.UValAPI.Buddies.Root? GunBuddies { get; private set; }
        public static ValorantAPI.UValAPI.Playercards.Root? Cards { get; private set; }
        public static ValorantAPI.UValAPI.Playertitles.Root? Titles { get; private set; }
        public static Entitlements.Root? Entitlements { get; private set; }
        public static RiotClient riotClient = null;

        public static Panel flowLayoutPanel = null;

        public Main()
        {
            try
            {

                string currentRegion = GetRegion();
                Program.logger.Log("Found region: " + currentRegion.ToString());
                if (currentRegion != null)
                {
                    InitializeComponent();
                    label3.Text = Program.DiscordLink;
                    riotClient = new RiotClient(currentRegion);

                    //Getting version
                    ValVersion = ValorantAPI.UValAPI.Methods.Get<ValorantAPI.UValAPI.ValVersion.Root>("/version");

                    //Getting weapons
                    Weapons = ValorantAPI.UValAPI.Methods.Get<ValorantAPI.UValAPI.Weapons.Root>("/weapons");

                    GunBuddies = ValorantAPI.UValAPI.Methods.Get<ValorantAPI.UValAPI.Buddies.Root>("/buddies");

                    Cards = ValorantAPI.UValAPI.Methods.Get<ValorantAPI.UValAPI.Playercards.Root>("/playercards");

                    Titles = ValorantAPI.UValAPI.Methods.Get<ValorantAPI.UValAPI.Playertitles.Root>("/playertitles");

                    label1.Text = $"Logged in as: {riotClient.CurrentUser.game_name}#{riotClient.CurrentUser.game_tag}";

                    //Currency
                    Currency valCurrency = riotClient.GetUserCurrency();
                    VPlabel.Text = valCurrency.ValorantPoints.ToString();
                    RadianiteLabel.Text = valCurrency.Radianite.ToString();

                    Entitlements = riotClient.Get_Entitlements();

                    
                    flowLayoutPanel = TabPanel;

                    if (Config.CurrentConfig.Presets == null)
                    {
                        var CurrentLoadout = riotClient.GetPlayerLoadout();
                        Config.CurrentConfig.Presets = new Config.Preset[10];
                        for (int i = 0; i < Config.CurrentConfig.Presets.Length; i++)
                        {
                            Config.CurrentConfig.Presets[i] = new Config.Preset() { Name = $"Preset {i}", Loadout = CurrentLoadout };
                        }
                    }

                    
                }
                else
                {
                    MessageBox.Show("Valorant is required to be opened to continue.", "Pro Swapper Valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Program.logger.LogError(ex.Message);
                MessageBox.Show("Valorant is required to be opened to continue.", "Pro Swapper Valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            
        }


        public static string GetRegion()
        {
            const string search = "[GET https://shared.";
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\VALORANT\\Saved\\Logs\\ShooterGame.log";
            string Region;
            using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                while (true)
                {
                    string currentLine = sr.ReadLine();
                    if (currentLine.Contains(search))
                    {
                        string tmp = currentLine.Substring(currentLine.IndexOf(search));
                        string tmp2 = tmp.Remove(0, search.Length);

                        return Region = tmp2.Substring(0, tmp2.IndexOf('.'));
                    }
                }
            }
            return null;
        }

        //Store tabs here
        private static Profile? profile = null;
        private static Presets? presets = null;
        
        private static Cards.Card_Select? Card_Select = null;
        private static Titles.Titles? Title = null;

        private static Buddies.GunSelect? GunSelect = null;
        private void button1_Click(object sender, EventArgs e)
        {
            TabPanel.Controls.Clear();
            if (GunSelect == null)
                GunSelect = new Buddies.GunSelect();

            GunSelect.Refresh();
            TabPanel.Controls.Add(GunSelect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPanel.Controls.Clear();

            if (Title == null)
                Title = new Titles.Titles();
            TabPanel.Controls.Add(Title);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            TabPanel.Controls.Clear();

            if (Card_Select == null)
                Card_Select = new Cards.Card_Select();
            TabPanel.Controls.Add(Card_Select);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TabPanel.Controls.Clear();

            if (profile == null)
                profile = new Profile();
            TabPanel.Controls.Add(profile);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TabPanel.Controls.Clear();

            if (presets == null)
                presets = new Presets();
            TabPanel.Controls.Add(presets);
        }
    }



}
