using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSwapperValorant.Buddies
{
    public partial class GunSelect : UserControl
    {
        public GunSelect()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            gunlistPanel.Controls.Clear();
            var loadout = Main.riotClient.GetPlayerLoadout();
            foreach (var weapon in Main.Weapons.data)
            {
                if (weapon.displayName == "Melee")
                    continue;

                string GunSkinID = loadout.Guns.First(x => x.ID.Equals(weapon.uuid)).SkinID;
                string GunSkinChroma = loadout.Guns.First(x => x.ID.Equals(weapon.uuid)).ChromaID;
                string GunBuddyID = loadout.Guns.First(x => x.ID.Equals(weapon.uuid)).CharmID;

                gunlistPanel.Controls.Add(new GunIcon(weapon, GunSkinID, GunBuddyID, GunSkinChroma));
            }
        }
    }
}
