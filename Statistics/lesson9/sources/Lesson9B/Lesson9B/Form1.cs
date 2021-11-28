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

namespace Lesson9B
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
        Point point; // mouse location handler
        double minX_Window = 0;
        double maxX_Window = 0;
        double minY_Window = 0;
        double maxY_Window = 0;
        double rangeX = 0;
        double rangeY = 0;
        Bitmap b;
        Graphics g; 
        Rectangle viewport;
        bool moveMouseOk = false;
        List<Interval> intervals;
        Random rand = new Random();
        List<double> observations;
        SortedList<int, List<double>> multipleObservations;

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

        // == PLOT NORMAL DISTRIBUTION ==
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInput1()) {
                initGraphics();
                g.DrawRectangle(Pens.Black, viewport);
                g.FillRectangle(Brushes.LightGray, viewport);
                observations = new List<double>();
                richTextBox1.Text = "";
                richTextBox1.Text += "N: " + n + "\n";
                for (int i = 0; i < n; i++)
                {
                    double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                    double u2 = 1.0 - rand.NextDouble();
                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                    double trial = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
                    observations.Add(trial);
                    richTextBox1.Text += trial + "\n";
                }
                intervals = continuousDistribution(observations, observations.Count);
                preparePrint(intervals);
                drawHistograms(intervals);
                pictureBox1.Image = b;
            }
        }

        // == PLOT MEAN ==
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkInput2())
            {
                initGraphics();
                g.DrawRectangle(Pens.Black, viewport);
                g.FillRectangle(Brushes.LightGray, viewport);
                observations = new List<double>();
                richTextBox1.Text = "";
                richTextBox1.Text += "N: " + n + "\n";
                richTextBox1.Text += "M: " + m + "\n";
                for (int i = 0; i < m; i++)
                {
                    List<double> trials = new List<double>();
                    for (int j = 0; j < n; j++)
                    {
                        double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                        double u2 = 1.0 - rand.NextDouble();
                        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                        double trial = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
                        trials.Add(trial);
                    }
                    double value = knuthMean(trials);
                    observations.Add(value);
                    richTextBox1.Text += value + "\n";
                }
                intervals = continuousDistribution(observations, observations.Count);
                preparePrint(intervals);
                drawHistograms(intervals);
                pictureBox1.Image = b;
            }
        }

        private double knuthMean(List<double> input)
        {
            double currentMean = 0;
            foreach (double s in input) currentMean = currentMean + ((s - currentMean) / (input.IndexOf(s) + 1));
            return currentMean;
        }

        // == PLOT VARIANCE ==
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkInput3())
            {
                initGraphics();
                g.DrawRectangle(Pens.Black, viewport);
                g.FillRectangle(Brushes.LightGray, viewport);
                observations = new List<double>();
                richTextBox1.Text = "";
                richTextBox1.Text += "N: " + n + "\n";
                richTextBox1.Text += "M: " + m + "\n";
                for (int i = 0; i < m; i++)
                {
                    List<double> trials = new List<double>();
                    for (int j = 0; j < n; j++)
                    {
                        double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                        double u2 = 1.0 - rand.NextDouble();
                        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                        double trial = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
                        trials.Add(trial);
                    }
                    double value = Math.Pow(getStandardDeviation(trials),2);
                    observations.Add(value);
                    richTextBox1.Text += value + "\n";
                }
                intervals = continuousDistribution(observations, observations.Count);
                preparePrint(intervals);
                drawHistograms(intervals);
                pictureBox1.Image = b;
            }
        }

        private double getStandardDeviation(List<double> input)
        {
            double average = knuthMean(input);
            double sumOfDerivation = 0;
            foreach (double value in input) sumOfDerivation += value * value;
            double sumOfDerivationAverage = sumOfDerivation / (input.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }

        // == PLOT EXP. NORMAL DISTRIBUTION ==
        private void button4_Click(object sender, EventArgs e)
        {
            if (checkInput4())
            {
                initGraphics();
                g.DrawRectangle(Pens.Black, viewport);
                g.FillRectangle(Brushes.LightGray, viewport);
                observations = new List<double>();
                richTextBox1.Text = "";
                richTextBox1.Text += "N: " + n + "\n";
                for (int i = 0; i < n; i++)
                {
                    double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                    double u2 = 1.0 - rand.NextDouble();
                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                    double trial = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
                    trial = Math.Exp(trial);
                    observations.Add(trial);
                    richTextBox1.Text += trial + "\n";
                }
                intervals = continuousDistribution(observations, observations.Count);
                preparePrint(intervals);
                drawHistograms(intervals);
                pictureBox1.Image = b;
            }
        }

        // == PLOT NORMAL DISTRIBUTION SQUARED ==
        private void button5_Click(object sender, EventArgs e)
        {
            if (checkInput5())
            {
                initGraphics();
                g.DrawRectangle(Pens.Black, viewport);
                g.FillRectangle(Brushes.LightGray, viewport);
                observations = new List<double>();
                richTextBox1.Text = "";
                richTextBox1.Text += "N: " + n + "\n";
                for (int i = 0; i < n; i++)
                {
                    double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                    double u2 = 1.0 - rand.NextDouble();
                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                    double trial = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
                    trial = Math.Pow(trial,2);
                    observations.Add(trial);
                    richTextBox1.Text += trial + "\n";
                }
                intervals = continuousDistribution(observations, observations.Count);
                preparePrint(intervals);
                drawHistograms(intervals);
                pictureBox1.Image = b;
            }
        }

        // == PLOT NORMAL DISTRIBUTION SQUARED DIVIDED BY SQUARED ==
        private void button6_Click(object sender, EventArgs e)
        {
            if (checkInput6())
            {
                initGraphics();
                g.DrawRectangle(Pens.Black, viewport);
                g.FillRectangle(Brushes.LightGray, viewport);
                observations = new List<double>();
                richTextBox1.Text = "";
                richTextBox1.Text += "N: " + n + "\n";
                for (int i = 0; i < n; i++)
                {
                    double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                    double u2 = 1.0 - rand.NextDouble();
                    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                    double trial1 = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)

                    u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                    u2 = 1.0 - rand.NextDouble();
                    randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                    double trial2 = 0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
                    double trial = (double)trial1 / (double)trial2;
                    observations.Add(trial);
                    richTextBox1.Text += trial + "\n";
                }
                intervals = continuousDistribution(observations, observations.Count);
                preparePrint(intervals);
                drawHistograms(intervals);
                pictureBox1.Image = b;
            }
        }

        // == INTERVAL CLASS ==
        public class Interval : IComparable<Interval>
        {
            public double upperEnd;
            public double lowerEnd;
            public int count;
            public List<double> values;

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
        private List<Interval> continuousDistribution(List<double> input, int numberIntervals)
        {
            bool valueAssigned = false;
            double endingPoint;
            double startingPoint;
            List<Interval> continuousValues = new List<Interval>();
            double min = 1000000;
            double max = -100000;
            foreach (double value in input)
            {
                if (value < min)
                {
                    min = value;
                }
                if (value > max)
                {
                    max = value;
                }
            }
            startingPoint = 0;
            if (numberIntervals > 300) numberIntervals = 300; 
            endingPoint = startingPoint + ((max - min) / numberIntervals);
            // first interval
            Interval interval0 = new Interval();
            interval0.lowerEnd = startingPoint;
            interval0.upperEnd = endingPoint;
            interval0.count = 0;
            interval0.values = new List<double>();
            continuousValues.Add(interval0);

            foreach (double value in input)
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
                                interval.values = new List<double>();
                                continuousValues.Insert(0, interval);
                            }
                            else
                            {
                                j-=1;
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
                                interval.values = new List<double>();
                                continuousValues.Add(interval);
                            }
                            j+=1;
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

        public void preparePrint(List<Interval> input)
        {
            minY_Window = 0;
            minX_Window = 1000000;
            maxY_Window = -1000000;
            maxX_Window = -1000000;
            foreach (Interval item in input)
            {
                if (item.lowerEnd < minX_Window) minX_Window = item.lowerEnd;
                if (item.upperEnd > maxX_Window) maxX_Window = item.upperEnd;
                if (item.count > maxY_Window) maxY_Window = item.count;
            }
             
            //window
            rangeX = maxX_Window - minX_Window;
            rangeY = maxY_Window - minY_Window;
        }

        // == DRAW HISTOGRAMS ==
        private void drawHistograms(List<Interval> intervals)
        {
            int MaximumSize = viewport.Bottom - viewport.Top;
            foreach (Interval inte in intervals)
            {
                if (inte != null)
                {
                    int y = viewport.Bottom - Convert.ToInt32((double)(MaximumSize * inte.count) / (double)(rangeY));
                    int x = calculateXViewport(inte.lowerEnd, viewport, minX_Window, rangeX);
                    int width = calculateXViewport(inte.upperEnd, viewport, minX_Window, rangeX) - calculateXViewport(inte.lowerEnd, viewport, minX_Window, rangeX);
                    // x : MaximumSize = count : (maxX - minX)
                    int height = viewport.Bottom - y;
                    Rectangle rect = new Rectangle(x, y, width, height);
                    g.DrawRectangle(Pens.Blue, rect);
                    g.FillRectangle(Brushes.Blue, rect);
                }
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

        // == CHECK USER INPUT FIRST ==
        private bool checkInput1()
        {
            n = 0;
            if (!Int32.TryParse(textBox1.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            return true;
        }

        // == CHECK USER INPUT SECOND ==
        private bool checkInput2()
        {
            n = 0;
            if (!Int32.TryParse(textBox2.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            m = 0;
            if (!Int32.TryParse(textBox3.Text, out m))
            {
                richTextBox1.Text = "M must be a valid integer!";
                return false;
            }
            return true;
        }

        // == CHECK USER INPUT THIRD ==
        private bool checkInput3()
        {
            n = 0;
            if (!Int32.TryParse(textBox5.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            m = 0;
            if (!Int32.TryParse(textBox4.Text, out m))
            {
                richTextBox1.Text = "M must be a valid integer!";
                return false;
            }
            return true;
        }

        // == CHECK USER INPUT FOURTH ==
        private bool checkInput4()
        {
            n = 0;
            if (!Int32.TryParse(textBox6.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            return true;
        }

        // == CHECK USER INPUT FIFTH ==
        private bool checkInput5()
        {
            n = 0;
            if (!Int32.TryParse(textBox7.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            return true;
        }

        // == CHECK USER INPUT SIXTH ==
        private bool checkInput6()
        {
            n = 0;
            if (!Int32.TryParse(textBox8.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            return true;
        }
    }
}
