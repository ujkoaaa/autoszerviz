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
    public partial class BelepettForm : Form
    {
        public BelepettForm()
        {
            InitializeComponent();
            label1.Text = "Üdv "+Form1.név;

            foreach (var szerelő in new fiókMűveletek().összesSzerelő())
            {
                szerelőVálasztó.Items.Add(szerelő);
            }
            if (szerelőVálasztó.Items.Count > 0)
            {
                napFrissítés(DateTime.Now, szerelőVálasztó.Items[0] as Felhasználó);
            }
        }

        private void kilépB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void napVálasztó_DateChanged(object sender, DateRangeEventArgs e)
        {
            napFrissítés(napVálasztó.SelectionStart, szerelőVálasztó.SelectedItem as Felhasználó);
        }

        private void szerelőVálasztó_SelectedIndexChanged(object sender, EventArgs e)
        {
            napFrissítés(napVálasztó.SelectionStart, szerelőVálasztó.SelectedItem as Felhasználó);
        }

        private void napFrissítés(DateTime nap, Felhasználó szerelő)
        {
            var időpontLista = new List<Button>();
            időpontLista.Add(button1);
            időpontLista.Add(button2);
            időpontLista.Add(button3);
            időpontLista.Add(button4);
            időpontLista.Add(button5);
            időpontLista.Add(button6);
            időpontLista.Add(button7);
            időpontLista.Add(button8);

            var random = new Random();
            foreach (var item in időpontLista)
            {
                if (random.Next(2) == 1) // igazi feltétel: A szerelő naptárában szabad az időpont
                {
                    item.BackColor = Color.Green;
                    item.Text = "Szabad";
                }
                else
                {
                    if (random.Next(2) == 1) // igazi feltétel: A szerelő naptárában a bejelentkezett felhasználóé az időpont
                    {
                        item.BackColor = Color.Orange;
                        item.Text = "Enyém";
                    }
                    else
                    {
                        item.BackColor = Color.Red;
                        item.Text = "Foglalt";
                    }
                }
            }
        }
    }
}
