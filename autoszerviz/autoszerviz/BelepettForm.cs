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

        public string időpontSegéd(string kliens, Button gomb)
        {
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
            foreach (var it in időpontLista)
            {
                it.BackColor = Color.Green;
                it.Text = "Szabad";
            }

            List<Időpont> időpontok = new List<Időpont>();
            using (StreamReader r = new StreamReader("../../../időpontok.json"))
            {
                string json = r.ReadToEnd();
                időpontok = JsonConvert.DeserializeObject<List<Időpont>>(json);
            }
            if (időpontok != null)
            {
                foreach (Időpont f in időpontok)
                {
                    if (f.szerelőnév == szerelő.név && f.idő.Date == nap.Date)
                    {
                        időpontListázás(f.ügyfél, f.idő.Hour.ToString());
                    }
                    else
                    {
                        időpontok.Remove(f);
                    }
                }
            }
        }
    }
}
