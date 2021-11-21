using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // == USER INPUT == 
        int m;
        int n;

        // == GLOBAL VARIABLES ==
        Bitmap b;
        Graphics g;
        Rectangle viewport;
        double minX_Window = 0;
        double maxX_Window = 0;
        double minY_Window = 0;
        double maxY_Window = 0;
        double rangeX = 0;
        double rangeY = 0;
        Point point; // mouse location handler
        bool moveMouseOk = false;
        Random rand;
        List<Tuple<double, double>> minAndMaxPairList;
        List<double> minHistograms;
        List<double> maxHistograms;
        List<Interval> minIntervals;
        List<Interval> maxIntervals;

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

        // == CHECK IF USER INPUT IS VALID ==
        private bool checkInput()
        {
            m = 0;
            if (!Int32.TryParse(textBox1.Text, out m))
            {
                richTextBox1.Text = "M must be a valid integer!";
                return false;
            }
            n = 0;
            if (!Int32.TryParse(textBox2.Text, out n))
            {
                richTextBox1.Text = "N must be a valid integer!";
                return false;
            }
            return true;
        }

        // == PLOT EVERYTHING == 
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                richTextBox1.Text = "M: " + m + " / " + "N: " + n;
                rand = new Random();
                minAndMaxPairList = new List<Tuple<double, double>>();
                minHistograms = new List<double>();
                maxHistograms = new List<double>();
                minIntervals = new List<Interval>();
                maxIntervals = new List<Interval>();
                minAndMaxPairList.Clear();
                initGraphics();
                // generate m samples with n observations
                for (int i = 0; i < m; i++)
                {
                    createRandomObservations();
                }
                foreach (Tuple<double, double> item in minAndMaxPairList)
                {
                    minHistograms.Add(item.Item1);
                    maxHistograms.Add(item.Item2);
                }
                minHistograms.Sort();
                System.Diagnostics.Debug.WriteLine(minHistograms.Count);
                maxHistograms.Sort();
                System.Diagnostics.Debug.WriteLine(maxHistograms.Count);

                plotHistograms(minHistograms, maxHistograms);

                pictureBox1.Image = b; // update
            }
        }

        // == INTERVAL CLASS ==
        public class Interval : IComparable<Interval>
        {
            public double upperEnd;
            public double lowerEnd;
            public int count;
            public List<double> values;

            public bool containsValue(double v)
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
        private List<Interval> continuousDistribution(List<double> input)
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
            int numberIntervals;
            if (m > 200)
            {
                numberIntervals = 200; 
            }
            else
            {
                numberIntervals = m;
            }
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
                                interval.values = new List<double>();
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

        // == CALCULATE WHICH INTERVAL X BELONGS TO ==
        private Interval xBelongsTo(double x, List<Interval> intervals)
        {
            for (int i = 0; i < intervals.Count; i++)
            {
                if (x >= intervals[i].lowerEnd && x < intervals[i].upperEnd)
                {
                    return intervals[i];
                }
            }
            return null;
        }

        // == PLOT HISTOGRAMS ==
        private void plotHistograms(List<double> min, List<double> max)
        {
            List<Interval> minIntervals = continuousDistribution(min);
            List<Interval> maxIntervals = continuousDistribution(max);
            maxX_Window = -10000;
            maxY_Window = -10000;
            minX_Window = 100000;
            minY_Window = 100000;
            foreach (double value in min)
            {
                if (value < minX_Window) minX_Window = value;
                if (value > maxX_Window) maxX_Window = value;
            }
            foreach (Interval item in minIntervals)
            {
                int value = item.count;
                if (value < minY_Window) minY_Window = value;
                if (value > maxY_Window) maxY_Window = value;
            }
            rangeX = maxX_Window - minX_Window;
            rangeY = maxY_Window - minY_Window;
            plotChart(minIntervals, true);
            maxX_Window = -10000;
            maxY_Window = -10000;
            minX_Window = 100000;
            minY_Window = 100000;
            foreach (double value in max)
            {
                if (value < minX_Window) minX_Window = value;
                if (value > maxX_Window) maxX_Window = value;
            }
            foreach (Interval item in maxIntervals)
            {
                int value = item.count;
                if (value < minY_Window) minY_Window = value;
                if (value > maxY_Window) maxY_Window = value;
            }
            rangeX = maxX_Window - minX_Window;
            rangeY = maxY_Window - minY_Window;
            plotChart(maxIntervals, false);
        }

        // == PLOT ONE HISTOGRAM CHART == 
        private void plotChart(List<Interval> intervals, bool min)
        {
            foreach (Interval inte in intervals)
            {
                int x = calculateXViewport(inte.lowerEnd, viewport, minX_Window, rangeX);
                int width = calculateXViewport(inte.upperEnd, viewport, minX_Window, rangeX) - calculateXViewport(inte.lowerEnd, viewport, minX_Window, rangeX);
                int y = calculateYViewport(inte.count, viewport, minY_Window, rangeY);
                if (min)
                {
                    g.FillRectangle(Brushes.Blue, x, y, width, viewport.Height + viewport.Y - y);
                    g.DrawRectangle(Pens.Red, x, y, width, viewport.Height + viewport.Y - y);
                }
                else
                {
                    g.FillRectangle(Brushes.Green, x, y, width, viewport.Height + viewport.Y - y);
                    g.DrawRectangle(Pens.Red, x, y, width, viewport.Height + viewport.Y - y);
                }
            }
        }

        // == GENERATE BERNOULLI OBSERVATIONS (using m and n) == 
        private void createRandomObservations()
        {
            double min = 0;
            double max = 0;

            for (int i = 0; i < n; i++)
            {
                double value = rand.NextDouble() * 100 - 50;
                
                if (value > max)
                {
                    max = value;
                }

                if (value < min)
                {
                    min = value;
                }
            }

            Tuple<double, double> newMinAndMax = new Tuple<double, double>(min, max);
            minAndMaxPairList.Add(newMinAndMax);
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
