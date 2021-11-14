using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // == GLOBAL VARIABLES ==
        Point point; // mouse location handler
        double minX_Window = 0;
        double maxX_Window = 100;
        double minY_Window = 0;
        double maxY_Window = 100;
        double rangeX = 100;
        double rangeY = 100;
        List<Point> points; // All the random generated points
        Bitmap b;
        Graphics g;
        Rectangle viewport;
        bool moveMouseOk = false;
        SortedDictionary<int, int> values;
        Timer timer;
        bool running;
        bool started = false;
        int n;
        Random rand;

        // == INITIALIZE THE GRAPHICS OBJECT ==
        private void initGraphics()
        {
            viewport = new Rectangle(10, 10, Convert.ToInt32(pictureBox1.Width) - 50, pictureBox1.Height - 50);
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            moveMouseOk = true;
        }

        // == CALCULATE THE X VALUE IN THE VIEWPORT ==
        private int calculateXViewport(double x_world, Rectangle viewport, double minX, double rangeX)
        {
            // X = L + ((x - minX)/Rx)W
            return Convert.ToInt32(viewport.Left + ((x_world - minX) / rangeX) * viewport.Width);
        }

        // == CALCULATE THE Y VALUE IN THE VIEWPORT ==
        private int calculateYViewport(double y_world, Rectangle viewport, double minY, double rangeY)
        {
            // Y = T + H - (((y - minY)/Ry)H)
            return Convert.ToInt32(viewport.Top + viewport.Height - ((((y_world - minY) / rangeY)) * viewport.Height));
        }

        // == GENERATE A RANDOM VALUE ==
        private int randomValue(Random autoRand)
        {
            return autoRand.Next((int)maxX_Window);
        }

        // == START NEW HANDLER == 
        private void button1_Click(object sender, EventArgs e)
        {
            if (running)
            {
                timer.Stop();
                running = false;
            }
            started = true;
            initGraphics();
            rand = new Random();
            values = new SortedDictionary<int, int>();
            points = new List<Point>();
            timer = new Timer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = 1000;
            running = true;
            timer.Start();
            n = 0;
            g.DrawRectangle(Pens.Black, viewport);
            g.FillRectangle(Brushes.LightGray, viewport);
        }

        // == PAUSE / PLAY HANDLER ==
        private void button2_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (running)
                {
                    running = false;
                    timer.Stop();
                }
                else
                {
                    running = true;
                    timer.Start();
                }
            }

        }

        // == FUNC CALLED AT EVERY TIMER TICK ==
        private void TimerTick(Object myObject, EventArgs e)
        {
            points = new List<Point>();
            int value = randomValue(rand);
            if (values.ContainsKey(value))
            {
                values[value] += 1;
            }
            else
            {
                values[value] = 1;
            }
            n = n + 1;
            richTextBox1.Text = "> new random value = " + value.ToString() + "\n";
            richTextBox1.Text += "> n = " + n.ToString() +  "\n";
            drawChart();
        }

        // == DRAW THE CHART WITH THE UPDATED LIST OF VALUES ==
        private void drawChart()
        {
            g.DrawRectangle(Pens.Black, viewport);
            g.FillRectangle(Brushes.LightGray, viewport);
            int count = 0;
            foreach (int key in values.Keys) {
                double x = key;
                count += values[key] / count;
                double y = maxY_Window * count / n;
                int xViewport = calculateXViewport(x, viewport, minX_Window, rangeX);
                int yViewport = calculateYViewport(y, viewport, minY_Window, rangeY);
                Point newPoint = new Point(xViewport, yViewport);
                if (points.Count != 0)
                {
                    Point precedentPoint;
                    if (points.Count == 1)
                    {
                        int x0 = calculateXViewport(0, viewport, minX_Window, rangeX);
                        int y0 = calculateYViewport(0, viewport, minY_Window, rangeY);
                        precedentPoint = new Point(x0, y0);
                    }
                    else
                    {
                        precedentPoint = points[points.Count - 1];
                    }
                    Point middlePoint = new Point(newPoint.X, precedentPoint.Y);
                    g.DrawLine(Pens.Blue, precedentPoint, middlePoint);
                    g.DrawLine(Pens.Blue, middlePoint, newPoint);
                }
                points.Add(newPoint);
            }
            pictureBox1.Image = b;
        }

        // == MOUSE HANDLER TO RESIZE AND MOVE THE PICTUREBOX ==
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            base.OnMouseDown(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox1.Left += e.X - point.X;
                pictureBox1.Top += e.Y - point.Y;
                if (moveMouseOk)
                {
                    g.DrawRectangle(Pens.Black, viewport);
                    g.FillRectangle(Brushes.LightGray, viewport);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                point = e.Location;
                pictureBox1.Size = new Size(point.X, point.Y);
                if (moveMouseOk && !running)
                {
                    g.DrawRectangle(Pens.Black, viewport);
                    g.FillRectangle(Brushes.LightGray, viewport);
                }
            }
            base.OnMouseMove(e);
        }
    }
}
