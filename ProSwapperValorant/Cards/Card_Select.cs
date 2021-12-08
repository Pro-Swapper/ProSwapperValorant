using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace ProSwapperValorant.Cards
{
    public partial class Card_Select : UserControl
    {
        private CardIcon[] CardsList = null;
        public Card_Select()
        {
            InitializeComponent();
            label1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CardsList = Main.Cards.data.OrderBy(x => x.displayName).Select(x => new CardIcon(x)).ToArray();
            //flowLayoutPanel1.Controls.AddRange(CardsList);

            flowLayoutPanel1.Invoke(new Action(() => { flowLayoutPanel1.Controls.AddRange(CardsList); }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Visible = false;
        }
    }
}
