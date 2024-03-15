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
        static float size = 3;  // počáteční velikost
        float textSize = 0;

        int toolIndex;  // od 1 do 6

        List<Tuple<int, int>> order = new List<Tuple<int, int>>();  // 1. index listu (1-5), 2. pořadí v daném listu

        List<Shape> lines = new List<Shape>();      //1 (6)
        List<Tuple<Shape, bool>> rectangles = new List<Tuple<Shape, bool>>(); //2
        List<Tuple<Shape, bool>> ellipses = new List<Tuple<Shape, bool>>();   //3
        List <Tuple<Shape, string>> texts = new List<Tuple<Shape, string>>();   //4
        List <Tuple<Shape, Image>> images = new List<Tuple<Shape, Image>>();   //5

        List<Point> tempLine;   //1,6       nedokončená linka
        Point tempGeometry; //2,3,4,5       počáteční bod nedokončeného tvaru
        
        Color tempColor; // ukládá barvu během mazání gumou

        Form popupSize = new Popup(size);   // menu pro výběr velikosti
        Form popupText = new Popup();       // menu pro zadávání textu pro nástroj text
       
        public Form1()
        {
            InitializeComponent();
        }

        private void panelPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Tuple<int, int> shape in order)    // vykresluje objekty podle pořadí ve kterém byly přidány
            {
                int i = shape.Item2;    // pro zjednodušení
                switch (shape.Item1)
                {
                    case 1: // tužka a guma
                        g.DrawLines(new Pen(lines[i].color, lines[i].size), lines[i].line.ToArray());
                        break;

                    case 2: // obdélník
                        Point pt1 = rectangles[i].Item1.line[0];
                        Point pt2 = rectangles[i].Item1.line[1];
                        g.DrawRectangle(new Pen(rectangles[i].Item1.color, rectangles[i].Item1.size), Rectangler(pt1, pt2));
                        if (rectangles[i].Item2)  
                            g.FillRectangle(new SolidBrush(rectangles[i].Item1.color), Rectangler(pt1, pt2));
                        break;

                    case 3: // elipsa
                        Point pt1_ = ellipses[i].Item1.line[0];
                        Point pt2_ = ellipses[i].Item1.line[1];
                        g.DrawEllipse(new Pen(ellipses[i].Item1.color, ellipses[i].Item1.size), Rectangler(pt1_, pt2_));
                        if (ellipses[i].Item2) 
                            g.FillEllipse(new SolidBrush(ellipses[i].Item1.color), Rectangler(pt1_, pt2_));
                        break;

                    case 4: // text
                        Point pt1__ = texts[i].Item1.line[0];
                        Point pt2__ = texts[i].Item1.line[1];
                        textSize = (float)(0.65 * Math.Abs(pt1__.Y - pt2__.Y));   // velikost textu je odvozená od velikosti obdélníku
                        g.DrawString(texts[i].Item2, new Font("arial", textSize), new SolidBrush(texts[i].Item1.color), (RectangleF)Rectangler(pt1__, pt2__));
                        break;

                    case 5: // obrázek
                        Point pt1___ = images[i].Item1.line[0];
                        Point pt2___ = images[i].Item1.line[1];
                        g.DrawImage(images[i].Item2, Rectangler(pt1___, pt2___));
                        break;
                }
            }

            //  zobrazí náhled objektu během kreslení
            if (isActive)
            {
                if (toolIndex == 1 || toolIndex == 6) 
                    g.DrawLines(new Pen(colorDialog1.Color, size), tempLine.ToArray());
                if (toolIndex == 2 || toolIndex == 4 || toolIndex == 5) 
                    g.DrawRectangle(new Pen(colorDialog1.Color, size), Rectangler(tempLine[0], tempGeometry));
                if (toolIndex == 3)
                    g.DrawEllipse(new Pen(colorDialog1.Color, size), Rectangler(tempLine[0], tempGeometry));
            }

            //  zamkne/odemkne mazací tlačítka
            if (!order.Any())
            {
                buttonBack.Enabled = false;
                buttonClear.Enabled = false;
            }
            else
            {
                buttonClear.Enabled = true;
                buttonBack.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButtonEraser.PerformClick();
            radioButtonPen.PerformClick();  // jinak nefunguje tužka při prvním načtení, nenašel jsem důvod
        }

        private void panelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            isActive = true;
            if(toolIndex >= 1 || toolIndex <= 5)
            {
                tempLine = new List<Point> { e.Location };
            }
            if(toolIndex == 6)
            {
                tempColor = colorDialog1.Color;
                colorDialog1.Color = Color.White;
                tempLine = new List<Point> { e.Location };
            }
        }

        private void Radio_Switch(object sender, EventArgs e)   // všechna tlačítka pro nástroje vedou sem
        {
            toolIndex = ((RadioButton)sender).TabIndex;
        }

        private void panelPaint_MouseMove(object sender, MouseEventArgs e)  // ukládá dosavadní čáru anebo poslední bod pro vykreslení
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
            if (isActive)
            {
                if (toolIndex == 1 || toolIndex == 6)
                {
                    order.Add(new Tuple<int, int>(1, lines.Count));
                    lines.Add(new Shape(tempLine, size, colorDialog1.Color));

                    panelPaint.Refresh();
                    if (toolIndex == 6)
                        colorDialog1.Color = tempColor;
                    isActive = false;
                }

                if (toolIndex == 2)
                {
                    tempLine.Add(e.Location);
                    order.Add(new Tuple<int, int>(2, rectangles.Count));
                    rectangles.Add(new Tuple<Shape, bool>(new Shape(tempLine, size, colorDialog1.Color), isFilled));
                    isActive = false;
                    panelPaint.Refresh();
                }

                if (toolIndex == 3)
                {
                    tempLine.Add(e.Location);
                    order.Add(new Tuple<int, int>(3, ellipses.Count));
                    ellipses.Add(new Tuple<Shape, bool>(new Shape(tempLine, size, colorDialog1.Color), isFilled));
                    isActive = false;
                    panelPaint.Refresh();
                }

                if (toolIndex == 4)
                {
                    tempLine.Add(e.Location);
                    string text_ = "";
                    using (Popup popup = new Popup())
                    {
                        if (popup.ShowDialog() == DialogResult.OK)
                            text_ = popup.returnText;
                    }
                    order.Add(new Tuple<int, int>(4, texts.Count));
                    texts.Add(new Tuple<Shape, string>(new Shape(tempLine, size, colorDialog1.Color), text_));
                    isActive = false;
                    panelPaint.Refresh();
                }

                if (toolIndex == 5)
                {
                    tempLine.Add(e.Location);
                    openFileDialog1.ShowDialog();
                    order.Add(new Tuple<int, int>(5, images.Count));
                    images.Add(new Tuple<Shape, Image>(new Shape(tempLine, size, colorDialog1.Color), Image.FromFile(openFileDialog1.FileName))); //todo fix
                    isActive = false;
                    panelPaint.Refresh();
                }
            }
        }

        private void buttonPalette_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            isActive = false;
            order.Clear();

            tempLine.Clear();
            tempGeometry = Point.Empty;

            lines.Clear();
            rectangles.Clear();
            ellipses.Clear();
            texts.Clear();
            images.Clear();

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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Tuple<int, int> back = order.LastOrDefault();
            switch (back.Item1)
            {
                case 1:
                    lines.RemoveAt(back.Item2);
                    break;
                case 2:
                    rectangles.RemoveAt(back.Item2);
                    break;
                case 3:
                    ellipses.RemoveAt(back.Item2);
                    break;
                case 4:
                    texts.RemoveAt(back.Item2);
                    break;
                case 5:
                    images.RemoveAt(back.Item2);
                    break;
            }
            order.RemoveAt(order.Count - 1);
            panelPaint.Refresh();
        }
    }
}
