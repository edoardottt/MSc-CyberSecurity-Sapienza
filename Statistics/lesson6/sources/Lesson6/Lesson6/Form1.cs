﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // == GLOBAL VARIABLES ==
        int m = 0; //number of paths
        int n = 0; //number of points per path
        double p = 0; //probability of success (0 - 1)
        double epsilon = 0; //epsilon
        Point point; // mouse location handler
        double minX_Window = 0;
        double maxX_Window = 0;
        double minY_Window = 0;
        double maxY_Window = 0;
        double rangeX = 0;
        double rangeY = 0;
        Dictionary<int, ArrayList> points; // All the random generated points
        Bitmap b;
        Graphics g;
        Rectangle viewport;
        bool moveMouseOk = false;
        List<Interval> middleIntervals;
        List<Interval> finalIntervals;
        bool relative;

        // == INITIALIZE THE GRAPHICS OBJECT ==
        private void initGraphics()
        {
            viewport = new Rectangle(10, 10, Convert.ToInt32(pictureBox1.Width) - 150, pictureBox1.Height - 20);
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

        // == CHECK IF USER INPUT IS VALID ==
        private bool checkInput()
        {
            m = 0;
            if (!Int32.TryParse(textBox1.Text, out m))
            {
                richTextBox1.Text = "M must be a valid integer!";
                return false;
            }
            if (m < 20)
            {
                richTextBox1.Text = "M must be at least 20!";
                return false;
            }
            n = 0;
            if (!Int32.TryParse(textBox2.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            if (n < 20)
            {
                richTextBox1.Text = "N must be at least 20!";
                return false;
            }
            p = 0;
            if (!Double.TryParse(textBox3.Text, out p))
            {
                richTextBox1.Text = "P must be a valid double!";
                return false;
            }
            if (p < 0 || p > 1)
            {
                richTextBox1.Text = "P must be a valid double between 0 and 1!";
                return false;
            }
            epsilon = 0;
            if (!Double.TryParse(textBox4.Text, out epsilon))
            {
                richTextBox1.Text = "epsilon must be a valid double!";
                return false;
            }
            if (epsilon < 0 || epsilon > 1)
            {
                richTextBox1.Text = "Epsilon must be a valid double between 0 and 1!";
                return false;
            }
            relative = radioButton1.Checked;
            return true;
        }

        // == GENERATE A RANDOM VALUE ==
        private double randomValue(Random autoRand)
        {
            return autoRand.NextDouble();
        }
        
        // == GET A RANDOM COLOR ==
        private Pen randomColor()
        {
            Random rand = new Random();
            List<Pen> colors = new List<Pen> {Pens.Black,Pens.Red, Pens.Green, 
                Pens.DarkGreen, Pens.DarkBlue, Pens.Azure, Pens.Yellow, Pens.YellowGreen, Pens.Coral,
                Pens.DeepPink, Pens.Purple, Pens.DarkRed, Pens.Magenta, Pens.Orange};
            int value = rand.Next(colors.Count);
            return colors[value];
        }

        // == DRAW PATHS IN VIEWPORT ==
        private void drawPaths()
        {
            g.DrawRectangle(Pens.Black, viewport);
            g.FillRectangle(Brushes.LightGray, viewport);
            maxX_Window = n;
            minX_Window = 0;
            maxY_Window = 1000;
            minY_Window = 0;
            rangeX = maxX_Window - minX_Window;
            rangeY = maxY_Window - minY_Window;
            Random autoRand = new Random();
            for (int i = 0; i < m; i++)
            {
                points[i] = new ArrayList();
                int success = 0;
                Pen color = randomColor();
                for (int j = 0; j < n; j++)
                {
                    double value = randomValue(autoRand);
                    //success
                    if (p != 0 && value <= p)
                    {
                        success+=1;
                    }
                    double successNow;
                    if (!relative)
                    {
                        // STANDARD RELATIVE (?)
                        //double relative = ((double)success / (double)(j + 1));
                        // f(t) = relative
                        // p = probability of success
                        // t = trials (j + 1)
                        //  standard relative frequency: (f(t)-p) / sqrt(p(1-p)/t) (??????)

                        // ABSOLUTE
                        successNow = (double)success * maxY_Window / (double)(n);
                    }
                    else
                    {
                        //RELATIVE
                        // f(t) = #success / #trials 
                        successNow = ((double)success / (double)(j + 1)) * maxY_Window;
                    }
                    int XviewPort = calculateXViewport(j, viewport, minX_Window, rangeX);
                    int Yviewport = calculateYViewport(successNow, viewport, minY_Window, rangeY);
                    points[i].Add(new Point(XviewPort, Yviewport));
                    if (j > 0)
                    {
                        g.DrawLine(color, (Point)points[i][j - 1], (Point)points[i][j]);
                    }
                }
            }
            int yLow = calculateYViewport(((p - epsilon) * maxY_Window), viewport, minY_Window, rangeY);
            g.DrawLine(Pens.Black, new Point(viewport.Left, yLow), 
                new Point(viewport.Right, yLow)
            );
            int yHigh = calculateYViewport(((p + epsilon) * maxY_Window), viewport, minY_Window, rangeY);
            g.DrawLine(Pens.Black, new Point(viewport.Left, yHigh),
                new Point(viewport.Right, yHigh)
            );
        }

        // == INTERVAL CLASS ==
        public class Interval : IComparable<Interval>
        {
            public int upperEnd;
            public int lowerEnd;
            public int count;
            public List<int> values;

            public Boolean containsValue(double v)
            {
                return v >= lowerEnd && v < upperEnd;
            }

            public override string ToString()
            {
                return "[" + string.Format("{0:F1}", lowerEnd) + ", " + string.Format("{0:F1}", upperEnd) + ")";
            }

            public int CompareTo(Interval interval2)
            {
                return Comparer<double>.Default.Compare(lowerEnd, interval2.lowerEnd);
            }
        }

        // == CALCULATE THE CONTINUOUS DISTRIBUTION ==
        private List<Interval> continuousDistribution(List<int> input)
        {
            bool valueAssigned;
            int endingPoint = 500;
            int startingPoint = 480;
            List<Interval> continuousValues = new List<Interval>();
            //double min = 0;
            //double max = 1000;
            // first interval
            Interval interval0 = new Interval();
            interval0.lowerEnd = startingPoint;
            interval0.upperEnd = endingPoint;
            interval0.count = 0;
            interval0.values = new List<int>();
            continuousValues.Add(interval0);

            foreach (int value in input)
            {
                valueAssigned = false;
                for (int i = 0; i < continuousValues.Count; i++)
                {
                    if (valueAssigned)
                    {
                        break;
                    }

                    if (value >= continuousValues[i].lowerEnd && value < continuousValues[i].upperEnd)
                    {
                        continuousValues[i].count += 1;
                        continuousValues[i].values.Add(value);
                        valueAssigned = true;
                        break;
                    }
                    // LEFT
                    if (value < continuousValues[i].lowerEnd)
                    {
                        if (valueAssigned)
                        {
                            break;
                        }
                        Interval item = continuousValues[i];
                        int j = i;
                        while (value < item.lowerEnd)
                        {
                            if (j == 0)
                            {
                                // generate a new interval on the left
                                Interval interval = new Interval();
                                interval.lowerEnd = item.lowerEnd - (endingPoint - startingPoint);
                                interval.upperEnd = item.lowerEnd;
                                interval.count = 0;
                                interval.values = new List<int>();
                                continuousValues.Insert(0, interval);
                            }
                            else
                            {
                                j--;
                            }
                            item = continuousValues[j];
                        }
                        if (value >= continuousValues[j].lowerEnd && value < continuousValues[j].upperEnd)
                        {
                            continuousValues[j].count += 1;
                            continuousValues[j].values.Add(value);
                            valueAssigned = true;
                            break;
                        }
                    }
                    // RIGHT
                    if (value >= continuousValues[i].upperEnd)
                    {
                        Interval item = continuousValues[i];
                        int j = i;
                        while (value >= item.upperEnd)
                        {
                            if (j == continuousValues.Count - 1)
                            {
                                // generate a new interval on the right
                                Interval interval = new Interval();
                                interval.lowerEnd = item.upperEnd;
                                interval.upperEnd = item.upperEnd + (endingPoint - startingPoint);
                                interval.count = 0;
                                interval.values = new List<int>();
                                continuousValues.Add(interval);
                            }
                            j++;
                            item = continuousValues[j];
                        }
                        if (value >= continuousValues[j].lowerEnd && value < continuousValues[j].upperEnd)
                        {
                            continuousValues[j].count += 1;
                            continuousValues[j].values.Add(value);
                            valueAssigned = true;
                            break;
                        }
                    }
                }
            }
            return continuousValues;
        }

        // == POINTS SCREENSHOT AFTER N TRIES == 
        private List<int> screenShotPoints(int tries)
        {
            List<int> result = new List<int>();
            for (int i=0;i<m;i++)
            {
                result.Add(((Point)points[i][tries]).Y);
            }
            return result;
        }

        // == DRAW HISTOGRAMS ==
        private void drawHistograms()
        {
            int middlex = calculateXViewport(Convert.ToInt32(n/2), viewport, minX_Window, rangeX);
            int finalx = calculateXViewport(n, viewport, minX_Window, rangeX);
            int maximumSize = 300;
            List<int> inputMiddle = screenShotPoints(Convert.ToInt32(n / 2));
            List<int> inputFinal = screenShotPoints(n - 1);
            middleIntervals = continuousDistribution(inputMiddle);
            foreach (Interval inte in middleIntervals)
            {
                if (inte != null)
                {
                    int y = inte.lowerEnd;
                    int x = middlex;
                    int width = Convert.ToInt32((maximumSize * inte.count) / n);
                    int height = inte.upperEnd - inte.lowerEnd;
                    Rectangle rect = new Rectangle(x, y, width, height);
                    g.DrawRectangle(Pens.AliceBlue, rect);
                    g.FillRectangle(Brushes.Blue, rect);
                }
            }

            finalIntervals = continuousDistribution(inputFinal);
            foreach (Interval inte in finalIntervals)
            {
                if (inte != null)
                {
                    int y = inte.lowerEnd;
                    int x = finalx;
                    int width = Convert.ToInt32((maximumSize * inte.count) / n);
                    int height = inte.upperEnd - inte.lowerEnd;
                    Rectangle rect = new Rectangle(x, y, width, height);
                    g.DrawRectangle(Pens.AliceBlue, rect);
                    g.FillRectangle(Brushes.Blue, rect);
                }
            }
        }

        // == PLOT EVERYTHING ==
        private void button1_Click(object sender, EventArgs e)
        {
            points = new Dictionary<int, ArrayList>();
            middleIntervals = new List<Interval>();
            finalIntervals = new List<Interval>();
            bool inputOk = checkInput();
            if (inputOk)
            {
                initGraphics();
                richTextBox1.Text = "> M: " + m + "\n";
                richTextBox1.Text += "> N: " + n + "\n";
                richTextBox1.Text += "> P: " + p + "\n";
                richTextBox1.Text += "> E: " + epsilon + "\n";
                drawPaths();
                drawHistograms();
                pictureBox1.Image = b;
            }
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
                if (moveMouseOk)
                {
                    g.DrawRectangle(Pens.Black, viewport);
                    g.FillRectangle(Brushes.LightGray, viewport);
                }
            }
            base.OnMouseMove(e);
        }
    }
}
