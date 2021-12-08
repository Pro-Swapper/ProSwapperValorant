using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSwapperValorant.Cards
{
    public partial class CardIcon : UserControl
    {
        ValorantAPI.UValAPI.Playercards.Datum thisCard;
        public CardIcon(ValorantAPI.UValAPI.Playercards.Datum card)
        {
            InitializeComponent();
            thisCard = card;
            label1.Text = card.displayName;
            label1.AutoSize = true;
            Image pictureBoxImage = Task.Run(() => ImageHandler.ItemIcon(card.smallArt)).Result;
            pictureBox1.Image = pictureBoxImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var loadout = Main.riotClient.GetPlayerLoadout();
            loadout.Identity.PlayerCardID = thisCard.uuid;
            if (Loadout.SetLoadout(loadout))
                MessageBox.Show($"Set Player Card to {thisCard.displayName}", "Pro Swapper Valorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
