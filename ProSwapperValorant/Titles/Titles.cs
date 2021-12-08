using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSwapperValorant.Titles
{
    public partial class Titles : UserControl
    {
        public Titles()
        {
            InitializeComponent();

            var loadout = Main.riotClient.GetPlayerLoadout();
            
            foreach (var title in Main.Titles.data.OrderBy(x => x.displayName))
            {
                if (title.displayName == " ")
                    continue;

                comboBox1.Items.Add(title.displayName);
            }

            foreach (var item in Main.Titles.data)
            {
                if (item.uuid == loadout.Identity.PlayerTitleID)
                    comboBox1.Text = item.displayName;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Main.Titles.data)
            {
                if (comboBox1.Text == item.displayName)
                {
                    var loadout = Main.riotClient.GetPlayerLoadout();
                    loadout.Identity.PlayerTitleID = item.uuid;
                    if (Loadout.SetLoadout(loadout))
                        MessageBox.Show($"Set Title to {item.titleText}", "Pro Swapper Valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
        }
    }
}
