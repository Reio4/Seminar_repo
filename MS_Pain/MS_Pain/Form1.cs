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
        bool isActive = false;
        bool isFilled = false;
        static float size = 3;  //počáteční velikost
        float textSize = 0;

        int toolIndex;  //od 1 do 6

        List<Tuple<int, int>> order = new List<Tuple<int, int>>();  // bude se hodit

        List<Shape> lines = new List<Shape>();      //1,6
        List<Tuple<Shape, bool>> rectangles = new List<Tuple<Shape, bool>>(); //2
        List<Tuple<Shape, bool>> ellipses = new List<Tuple<Shape, bool>>();   //3
        List <Tuple<Shape, string>> texts = new List<Tuple<Shape, string>>();   //4
        List <Tuple<Shape, Image>> images = new List<Tuple<Shape, Image>>();   //5

        List<Point> tempLine;   //1,6       nedokončená linka
        Point tempGeometry; //2,3,4,5       počáteční bod nedokončeného tvaru
        
        Color tempColor; //ukládá barvu během mazání gumou

        Form popupSize = new Popup(size);   //menu pro výběr velikosti
        Form popupText = new Popup();       //menu pro zadávání textu pro nástroj text
       
        public Form1()
        {
            InitializeComponent();
        }

        private void panelPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Shape item in lines)   //1, 6
                g.DrawLines(new Pen(item.color, item.size), item.line.ToArray());

            foreach (Tuple<Shape, bool> rectangle in rectangles)    //2
            {
                Point pt1 = rectangle.Item1.line[0];
                Point pt2 = rectangle.Item1.line[1];
                g.DrawRectangle(new Pen(rectangle.Item1.color, rectangle.Item1.size), Rectangler(pt1, pt2)); 
                if (rectangle.Item2)    //není v if/else, protože to takhle vypadá lépe
                    g.FillRectangle(new SolidBrush(rectangle.Item1.color), Rectangler(pt1, pt2));
            }
            foreach (Tuple<Shape, bool> ellipse in ellipses)    //3
            {
                Point pt1 = ellipse.Item1.line[0];
                Point pt2 = ellipse.Item1.line[1];
                g.DrawEllipse(new Pen(ellipse.Item1.color, ellipse.Item1.size), Rectangler(pt1, pt2));
                if (ellipse.Item2)  //není v if/else, protože to takhle vypadá lépe
                    g.FillEllipse(new SolidBrush(ellipse.Item1.color), Rectangler(pt1, pt2));
            }
            foreach (Tuple<Shape, string> text in texts)    //4
            {
                Point pt1 = text.Item1.line[0];
                Point pt2 = text.Item1.line[1];
                textSize = (float)(0.65 * Math.Abs(pt1.Y - pt2.Y));   // velikost textu odvozená od velikosti hranice
                g.DrawString(text.Item2, new Font("arial", textSize), new SolidBrush(text.Item1.color), (RectangleF)Rectangler(pt1, pt2));
            }
            foreach (Tuple<Shape, Image> image in images)    //4
            {
                Point pt1 = image.Item1.line[0];
                Point pt2 = image.Item1.line[1];
                g.DrawImage(image.Item2, Rectangler(pt1, pt2));
            }

            //zobrazí náhled objektu během kreslení
            if (isActive && (toolIndex == 1 || toolIndex == 6)) 
                g.DrawLines(new Pen(colorDialog1.Color, size), tempLine.ToArray());
            if (isActive && (toolIndex == 2 || toolIndex == 4 || toolIndex == 5)) 
                g.DrawRectangle(new Pen(colorDialog1.Color, size), Rectangler(tempLine[0], tempGeometry));
            if (isActive && toolIndex == 3)
                g.DrawEllipse(new Pen(colorDialog1.Color, size), Rectangler(tempLine[0], tempGeometry));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            isActive = true;
            switch(toolIndex)
            {
                case 1: //tužka

                case 2: //obdélník

                case 3: //elipsa
                    
                case 4: //text

                case 5: //obrázek
                    tempLine = new List<Point> { e.Location };
                    break;
                case 6: //guma
                    tempColor = colorDialog1.Color;
                    colorDialog1.Color = Color.White;

                    tempLine = new List<Point> { e.Location };
                    toolStripStatusLabel1.Text = "zapsání prvního bodu";
                    break;
            }
        }

        private void Radio_Switch(object sender, EventArgs e)
        {
            toolIndex = ((RadioButton)sender).TabIndex;
        }

        private void panelPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isActive && (toolIndex == 1 || toolIndex == 6)) 
            {
                tempLine.Add(e.Location);
                panelPaint.Refresh();
            }
            if(isActive && (toolIndex == 2 || toolIndex == 3 || toolIndex == 4 || toolIndex == 5))
            {
                tempGeometry = e.Location;
                panelPaint.Refresh();
            }
        }

        private void panelPaint_MouseUp(object sender, MouseEventArgs e)    //vytvoří se objekt, nástroj se deaktivuje
        {
            if (isActive && (toolIndex == 1 || toolIndex == 6))
            {
                lines.Add(new Shape(tempLine, size, colorDialog1.Color));


                panelPaint.Refresh();
                if (toolIndex == 6) 
                    colorDialog1.Color = tempColor;
                isActive = false;
            }
            
            if(isActive && toolIndex == 2)
            {
                tempLine.Add(e.Location);
                rectangles.Add(new Tuple<Shape, bool>(new Shape(tempLine, size, colorDialog1.Color), isFilled));
                panelPaint.Refresh();
                isActive = false;
            }
            
            if (isActive && toolIndex == 3)
            {
                tempLine.Add(e.Location);
                ellipses.Add(new Tuple<Shape, bool>(new Shape(tempLine, size, colorDialog1.Color), isFilled));
                isActive = false;
                panelPaint.Refresh();
            }

            if (isActive && toolIndex == 4)
            {
                tempLine.Add(e.Location);
                string text_ = "";
                using (Popup popup = new Popup())
                {
                    if (popup.ShowDialog() == DialogResult.OK)
                        text_ = popup.returnText;
                }
                texts.Add(new Tuple<Shape, string>(new Shape(tempLine, size, colorDialog1.Color), text_));
                isActive = false;
                panelPaint.Refresh();
            }

            if(isActive && toolIndex == 5)
            {
                tempLine.Add(e.Location);
                openFileDialog1.ShowDialog();
                images.Add(new Tuple<Shape, Image>(new Shape(tempLine, size, colorDialog1.Color), Image.FromFile(openFileDialog1.FileName))); //todo fix
                isActive = false;
                panelPaint.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            isActive = false;
            lines.Clear();
            tempLine.Clear();
            rectangles.Clear();
            ellipses.Clear();
            texts.Clear();
            images.Clear();
            tempGeometry = Point.Empty;
            panelPaint.Refresh();
        }

        private void buttonSize_Click(object sender, EventArgs e) // se zpracováním zadaných dat poradil https://stackoverflow.com/questions/5233502/how-to-return-a-value-from-a-form-in-c
        {
            using (Popup popup = new Popup(size))   
            {
                if (popup.ShowDialog() == DialogResult.OK)
                    size = (float)popup.returnSize;
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            if (isFilled)
            {
                isFilled = false;
                buttonFill.Text = "⬜";
            }
            else
            {
                isFilled = true;
                buttonFill.Text = "⬛";
            }
        }

        private Rectangle Rectangler(Point pt1, Point pt2)  //protože c# evidentně neumí udělat tohle automaticky
        {
            return new Rectangle(Math.Min(pt1.X, pt2.X), 
                                 Math.Min(pt1.Y, pt2.Y),
                                 Math.Abs(pt1.X - pt2.X), 
                                 Math.Abs(pt1.Y - pt2.Y));
        }
    }
}
