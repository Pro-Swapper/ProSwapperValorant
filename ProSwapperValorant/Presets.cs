using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSwapperValorant
{
    public partial class Presets : UserControl
    {
        public Presets()
        {
            InitializeComponent();
            foreach (var preset in Config.CurrentConfig.Presets)
                comboBox1.Items.Add(preset.Name);

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var CurrentPreset = Config.CurrentConfig.Presets[comboBox1.SelectedIndex];
            foreach (var guns in CurrentPreset.Loadout.Guns)
            {
                if (guns.ID == "2f59173c-4bed-b6c3-2191-dea9b58be9c7")//Skip melee buddy
                    flowLayoutPanel1.Controls.Add(new Buddies.GunIcon(WeaponIDToObj(guns.ID), guns.SkinID, guns.CharmID, guns.ChromaID, false));
                else
                    flowLayoutPanel1.Controls.Add(new Buddies.GunIcon(WeaponIDToObj(guns.ID), guns.SkinID, guns.CharmID, guns.ChromaID));
            }

            //Add user's player card
            string CurrentCardURL = Main.Cards.data.First(x => x.uuid.Equals(CurrentPreset.Loadout.Identity.PlayerCardID)).smallArt;
            Image pictureBoxImage = Task.Run(() => ImageHandler.ItemIcon(CurrentCardURL)).Result;
            pictureBox1.Image = pictureBoxImage;

        }


        private static ValorantAPI.UValAPI.Weapons.Datum WeaponIDToObj(string UUID) => Main.Weapons.data.First(x => x.uuid.Equals(UUID));

        private void button1_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.Presets[comboBox1.SelectedIndex].Loadout = Main.riotClient.GetPlayerLoadout();
            comboBox1_SelectedValueChanged(sender, e);
        }
    }
}
