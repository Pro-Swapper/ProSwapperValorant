using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValorantAPI.RiotClientAPI.RiotJsonStructs;
namespace ProSwapperValorant
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            label1.Text = $"Valorant Version: {Main.ValVersion.data.version}\nLast Update: {Main.ValVersion.data.buildDate}\nRegion: {Main.riotClient.region}";
        }
    }
}
