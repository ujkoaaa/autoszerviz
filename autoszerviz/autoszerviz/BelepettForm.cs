using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoszerviz
{
    public partial class BelepettForm : Form
    {
        public BelepettForm()
        {
            InitializeComponent();
            label1.Text = "Üdv "+Form1.név;
        }

        private void kilépB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
