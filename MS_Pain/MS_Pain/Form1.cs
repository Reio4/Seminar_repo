using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_Pain
{
    public partial class Form1 : Form
    {
        int toolIndex;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

        }

        public Form1()
        {
            InitializeComponent();
            List<Button> toolButtons = new List<Button>();
            

        }

        private void buttonPen_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
        }

        private void buttonArrow_Click(object sender, EventArgs e)
        {
        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
        }

        private void buttonScrap_Click(object sender, EventArgs e)
        {
            //erase
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
