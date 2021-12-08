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
    public partial class BuddyIcon : UserControl
    {
        ValorantAPI.UValAPI.Buddies.Datum thisBuddy;
        public BuddyIcon(ValorantAPI.UValAPI.Buddies.Datum Buddy)
        {
            InitializeComponent();
            thisBuddy = Buddy;
            label1.Text = Buddy.displayName;
            label1.AutoSize = true;
            Image pictureBoxImage = Task.Run(() => ImageHandler.ItemIcon(Buddy.displayIcon)).Result;
            pictureBox1.Image = pictureBoxImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var loadout = Main.riotClient.GetPlayerLoadout();
            if (GunChangeBuddy.currentWeapon.displayName != "All")
            {
                //Gets our selected weapon
                //ValorantAPI.UValAPI.Weapons.Datum SelectedWeapon = Main.Weapons.data.First(x => x.displayName.Equals(Buddy_SelectGun.SelectedGun));
                ValorantAPI.UValAPI.Weapons.Datum SelectedWeapon = GunChangeBuddy.currentWeapon;

                //Gets the index of our weapon in the list.
                int Index = loadout.Guns.IndexOf(loadout.Guns.First(x => x.ID.Equals(SelectedWeapon.uuid)));
                if (loadout.Guns[Index].CharmInstanceID == null)
                {
                    MessageBox.Show($"Please set a gun buddy on your {SelectedWeapon.displayName} (It can be a random one)", "Pro Swapper Valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                loadout.Guns[Index].CharmID = thisBuddy.uuid;//Actually set gun buddy in api

                //e57419f3-4d86-77d7-0e28-14838940dd4e

                
                //loadout.Sprays.First(x => x.EquipSlotID.Equals("04af080a-4071-487b-61c0-5b9c0cfaac74")).SprayID = "bc8917ee-4e11-0286-ff49-77b1e5b12fcb";
                //loadout.Sprays.First(x => x.EquipSlotID.Equals("04af080a-4071-487b-61c0-5b9c0cfaac74")).SprayID = "4c893010-4967-131a-a9a5-789483dbd7a0";

                if (Loadout.SetLoadout(loadout))
                    MessageBox.Show($"Set {SelectedWeapon.displayName}'s Buddy to {thisBuddy.displayName}", "Pro Swapper valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<GunBuddy> OwnedGunBuddies = new List<GunBuddy>();
                foreach (var item in Main.Entitlements.EntitlementsByTypes.First(x => x.ItemTypeID.Equals("dd3bf334-87f3-40bd-b043-682a57a8dc3a")).Entitlements)
                {
                    OwnedGunBuddies.Add(new GunBuddy(item.ItemID, item.InstanceID));
                }

                if (OwnedGunBuddies.Count <= Main.Weapons.data.Count - 1)//remove one because knives dont have buddies
                {
                    MessageBox.Show("You do not have enough gun buddies to set your all your guns to the same buddy, try setting individual guns instead :)", "Pro Swapper Valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                for (int index = 0; index < Main.Weapons.data.Count; index++)
                {
                    if (loadout.Guns[index].ID == "2f59173c-4bed-b6c3-2191-dea9b58be9c7")//skip melee
                        continue;

                    loadout.Guns[index].CharmID = thisBuddy.uuid;
                    loadout.Guns[index].CharmLevelID = OwnedGunBuddies[index].CharmLevelID;
                    loadout.Guns[index].CharmInstanceID = OwnedGunBuddies[index].CharmInstanceID;
                }

                if (Loadout.SetLoadout(loadout))
                    MessageBox.Show($"Set All your gun buddies to {thisBuddy.displayName}", "Pro Swapper valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }


        public class GunBuddy
        {
            public GunBuddy(string charmLevelID, string charmInstanceID)
            {
                CharmLevelID = charmLevelID;
                CharmInstanceID = charmInstanceID;
            }
            public string CharmLevelID;
            public string CharmInstanceID;
        }
    }
}
