using autoszerviz.Fiók;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoszerviz
{
    public partial class BelepettForm : Form
    {
        private IdopontMuveletek idopontMuveletek;

        public BelepettForm()
        {
            InitializeComponent();

            idopontMuveletek = new IdopontMuveletek();
            label1.Text = "Üdv "+Form1.név;

            foreach (var szerelő in new fiókMűveletek().összesSzerelő())
            {
                szerelőVálasztó.Items.Add(szerelő);
            }
            if (szerelőVálasztó.Items.Count > 0)
            {
                szerelőVálasztó.SetSelected(0, true);
                napFrissítés();
            }
        }

        private void kilépB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void napVálasztó_DateChanged(object sender, DateRangeEventArgs e)
        {
            napFrissítés();
        }

        private void szerelőVálasztó_SelectedIndexChanged(object sender, EventArgs e)
        {
            napFrissítés();
        }

        public string időpontSegéd(string kliens, Button gomb)
        {
            gomb.Enabled = false;
            if (kliens == Form1.név)
            {
                gomb.BackColor = Color.Orange;
                return "Enyém";
            }
            gomb.BackColor = Color.Red;
            return "Foglalt";
        }
        public void időpontListázás(string kliens, string óra)
        {
            if(óra=="9")
            {
                button1.Text = időpontSegéd(kliens, button1);
            }
            else if(óra=="10")
            {
                button2.Text = időpontSegéd(kliens, button2);
            }
            else if (óra == "11")
            {
                button3.Text = időpontSegéd(kliens, button3);
            }
            else if (óra == "12")
            {
                button4.Text = időpontSegéd(kliens, button4);
            }
            else if (óra == "13")
            {
                button5.Text = időpontSegéd(kliens, button5);
            }
            else if (óra == "14")
            {
                button6.Text = időpontSegéd(kliens, button6);
            }
            else if (óra == "15")
            {
                button7.Text = időpontSegéd(kliens, button7);
            }
            else if (óra == "16")
            {
                button8.Text = időpontSegéd(kliens, button8);
            }
        }
        private void napFrissítés()
        {
            var nap = napVálasztó.SelectionStart;
            var szerelő = szerelőVálasztó.SelectedItem as Felhasználó;

            var idopontLista = new List<Button>();
            idopontLista.Add(button1);
            idopontLista.Add(button2);
            idopontLista.Add(button3);
            idopontLista.Add(button4);
            idopontLista.Add(button5);
            idopontLista.Add(button6);
            idopontLista.Add(button7);
            idopontLista.Add(button8);
            foreach (var it in idopontLista)
            {
                if (nap.Date < DateTime.Now.Date || (nap.Date == DateTime.Now.Date && idopontLista.IndexOf(it) + 8 < DateTime.Now.Hour))
                {
                    it.BackColor = Color.Gray;
                    it.Text = "Elmúlt";
                    it.Enabled = false;
                }
                else
                {
                    it.BackColor = Color.Green;
                    it.Text = "Szabad";
                    it.Enabled = true;
                }
            }

            foreach (Időpont f in idopontMuveletek.GetSzerelo(szerelő.név))
            {
                if (f.idő.Date == nap.Date)
                {
                    időpontListázás(f.ügyfél, f.idő.Hour.ToString());
                }
            }
        }

        private void timebutton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var rendeles = new RendeloForm();
                var result = rendeles.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var (muvelet, megjegyzes) = ((string, string))rendeles.Tag;
                    var szerelo = szerelőVálasztó.SelectedItem as Felhasználó;
                    var kliens = Form1.név;
                    var idopont = napVálasztó.SelectionStart.AddHours(int.Parse((string)button.Tag));
                    var foglalas = new Időpont
                    {
                        szerelőnév = szerelo.név,
                        ügyfél = kliens,
                        idő = idopont,
                        muvelet = muvelet,
                        megjegyzes = megjegyzes
                    };
                    idopontMuveletek.AddIdopont(foglalas);

                    idopontMuveletek.Mentes();
                }
                napFrissítés();
            }
        }
    }
}
