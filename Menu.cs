using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadGame(object sender, EventArgs e)
        {
            Game windowGaame = new Game();
            windowGaame.Show();
            Hide();
        }

        private void LoadHelp(object sender, EventArgs e)
        {
            Helper helper = new Helper();
            helper.Show();
           
        }
    }
}
