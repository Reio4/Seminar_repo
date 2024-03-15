using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_Pain
{
    public partial class Popup : Form
    {
        public decimal returnSize;
        public string returnText;
        public Popup(float size)  // okno pro výběr velikosti
        {
            InitializeComponent();
            textBox1.Hide();    // zobrazí se pouze číselník
            numericUpDown1.Value = (decimal)size;
        }
        public Popup()  // okno pro zadání textu
        {
            InitializeComponent();
            numericUpDown1.Hide();  //zobrazí se poze textové pole
        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnSize = numericUpDown1.Value;
            returnText = textBox1.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Popup_Load(object sender, EventArgs e) //QOL
        {
            if (textBox1.Visible)
                textBox1.Select();
            else
                numericUpDown1.Select();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  //QOL
        {
            if (e.KeyChar == (char)13)
            {
                button1.PerformClick();
            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)    //QOL
        {
            if (e.KeyChar == (char)13)
            {
                button1.PerformClick();
            }
        }
    }
}
