using autoszerviz.Fiók;
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
    public partial class Form1 : Form
    {
        fiókMűveletek műveletek;
        public static string név;
        public Form1()
        {
            InitializeComponent();
            műveletek = new fiókMűveletek();
        }

        private void regisztrálB_Click(object sender, EventArgs e)
        {
            műveletek.regisztrál(névText.Text, jelszóText.Text);
        }

        private void belépB_Click(object sender, EventArgs e)
        {
            if(műveletek.létezőFiók(névText.Text, jelszóText.Text,false))
            {
                név = névText.Text;
                var belepett = new BelepettForm();
                Visible = false;
                belepett.ShowDialog();
                Visible = true;
            }
            else
            {
                MessageBox.Show("Hibás adat megadás");
            }
        }
    }
}
