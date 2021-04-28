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
    public partial class RendeloForm : Form
    {
        public string Tipus 
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = comboBox1.Items[comboBox1.FindStringExact(value)]; }
        }
        public string Megjegyzes
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public RendeloForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
