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
    public partial class GunChangeBuddy : UserControl
    {
        public static ValorantAPI.UValAPI.Weapons.Datum currentWeapon;
        public GunChangeBuddy(ValorantAPI.UValAPI.Weapons.Datum Weapon, Image gunImage)
        {
            InitializeComponent();
            label1.Text = $"Change {Weapon.displayName}'s Gun Buddy";
            GunPictureBox.Image = gunImage;
            currentWeapon = Weapon;
            flowLayoutPanel1.Controls.AddRange(Main.GunBuddies.data.OrderBy(x => x.displayName).Select(x => new BuddyIcon(x)).ToArray());
        }
    }
}
