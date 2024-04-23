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
    public partial class Mirror : Form
    {
        public Mirror()
        {
            InitializeComponent();
        }

        private void Mirror_Load(object sender, EventArgs e)
        {

        }

        private void Mirror_MouseClick(object sender, MouseEventArgs e)
        {
            Hide();
        }

    }
}
