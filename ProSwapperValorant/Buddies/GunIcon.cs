using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValorantAPI.UValAPI;
namespace ProSwapperValorant.Buddies
{
    public partial class GunIcon : UserControl
    {
        public GunChangeBuddy changeBuddy;
        private string GunBuddyID = null;
        private Weapons.Datum weapon;
        public GunIcon(Weapons.Datum Weapon, string SkinID, string BuddyID, string ChromaID, bool UseBuddy = true)
        {
            InitializeComponent();
            label1.Text = Weapon.displayName;
            weapon = Weapon;
            //gun image with selected variant
            string GunImage = Weapon.skins.First(x => x.uuid.Equals(SkinID)).chromas.First(x => x.uuid.Equals(ChromaID)).fullRender;
            GunPictureBox.Image = Task.Run(() => ImageHandler.ItemIcon(GunImage)).Result;

            if (UseBuddy == false)
            {
                BuddyPictureBox.Visible = false;
            }
            else if (BuddyID != null)
            {
                GunBuddyID = BuddyID;
                string GunBuddyIcon = Main.GunBuddies.data.First(x => x.uuid.Equals(BuddyID)).displayIcon;
                BuddyPictureBox.Image = Task.Run(() => ImageHandler.ItemIcon(GunBuddyIcon)).Result;
            }
            changeBuddy = new GunChangeBuddy(Weapon, GunPictureBox.Image);
        }

        private void GunPictureBox_Click(object sender, EventArgs e)
        {
            if (BuddyPictureBox.Visible == true)
            {
                if (GunBuddyID != null)
                {
                    Main.flowLayoutPanel.Controls.Clear();
                    Main.flowLayoutPanel.Controls.Add(changeBuddy);
                }
                else
                {
                    MessageBox.Show($"Please equip a buddy on your {weapon.displayName}");
                }
            }
            
        }
    }
}
