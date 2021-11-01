using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point point; // mouse location handler
        int firstValue = 0; // first column index
        int secondValue = 1; // second column index
        double minX_Window = 0;
        double maxX_Window = 0;
        double minY_Window = 0;
        double maxY_Window = 0;
        double rangeX = 0;
        double rangeY = 0;
        Dictionary<Tuple<Interval, Interval>, int> bivariateDict; // Bivariate distribution dictionary
        List<double> columnD1; // list of double values (first column)
        List<double> columnD2; // list of double values (second column)
        List<Interval> xIntervals;
        List<Interval> yIntervals;

        /*
         * ===================================================
         * ====================== CSV TAB ====================
         * ===================================================
         */

        // DRAG AND DROP CSV FILENAME 
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            textBox1.Clear();
            for (i = 0; i < s.Length; i++)
                textBox1.Text += s[i];
        }

        // == VARIABLE CLASS ==
        public class Variable
        {
            String name;
            String inferredDataType;

            public Variable(String name, String inferredDataType)
            {
                this.name = name;
                this.inferredDataType = inferredDataType;
            }

            public String getInferredDataType()
            {
                return inferredDataType;
            }

            public String getName()
            {
                return name;
            }
        }

        // == DATAPOINT CLASS ==
        public class DataPoint
        {
            ArrayList values;
            int row;

            public DataPoint(ArrayList values, int row)
            {
                this.values = values;
                this.row = row;
            }

            public ArrayList getValues()
            {
                return values;
            }

            public int getRow()
            {
                return row;
            }
        }

        // == READ CSV DATA ==
        private void loadObjects()
        {
            List<DataPoint> datapoints = extractDataPoints();
            this.rows = datapoints.Count;
            this.datap = datapoints;
            List<Variable> variables = createVariables(datapoints);
            this.columns = variables.Count;
            this.vars = variables;
            updateTreeview(datapoints, variables);
        }

        // == UPDATE THE TREEVIEW ==
        public void updateTreeview(List<DataPoint> datapoints, List<Variable> variables)
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            for (int i = 0; i < variables.Count; i++)
            {
                string typeColumn;
                typeColumn = variables[i].getInferredDataType();
                treeView1.Nodes.Add("Column " + i + ", name: " + variables[i].getName() + ", type: " + typeColumn);
                for (int j = 0; j < datapoints.Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add((string)datapoints[j].getValues()[i]);
                }
            }
            treeView1.EndUpdate();
        }

        // == GUESS THE VARIABLES TYPE AND RETURNS THE LIST OF VARIABLES
        public List<Variable> createVariables(List<DataPoint> datapoints)
        {
            List<Variable> variables = new List<Variable>();

            if (datapoints.Count > 0)
            {
                for (int i = 0; i < datapoints[0].getValues().Count; i++)
                {
                    ArrayList inputs = new ArrayList();
                    for (int j = 0; j < this.rows; j++)
                    {
                        inputs.Add(datapoints[j].getValues()[i]);
                    }
                    String guessedType = guessType(inputs);
                    Variable var;
                    if (headers.Count != 0)
                    {
                        var = new Variable((string)headers[i], guessedType);
                    }
                    else
                    {
                        var = new Variable("Column" + i, guessedType);
                    }
                    variables.Add(var);
                }
            }
            return variables;
        }

        // == READ CSV FILE AND CREATE DATAPOINTS ==
        public List<DataPoint> extractDataPoints()
        {
            // check if the textbox input is empty
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("ERROR", "Empty input. Enter a valid filename", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            List<DataPoint> dataPoints = new List<DataPoint>();

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(textBox1.Text))
                {
                    this.rows = 0;
                    this.headers = new ArrayList();
                    string line;

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        ArrayList row = new ArrayList();
                        // headers
                        if (this.rows == 0 && checkBox1.Checked)
                        {
                            var heads = line.Split(',');

                            for (int i = 0; i < heads.Length; i++)
                            {
                                this.headers.Add(heads[i]);
                            }
                        }
                        else
                        {   // values
                            string[] separators = { "," };
                            var values = line.Split(separators, StringSplitOptions.None);
                            for (int i = 0; i < values.Length; i++)
                            {
                                row.Add(values[i]);
                            }
                            DataPoint dp = new DataPoint(row, rows);
                            dataPoints.Add(dp);
                        }
                        this.rows += 1;
                    }
                }
            }
            catch (Exception exception)
            {
                // Let the user know what went wrong.
                MessageBox.Show(exception.Message, "Unable To Read CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataPoints;
        }

        // == GUESS THE TYPE OF A VARIABLE ==
        public String guessType(ArrayList inputs)
        {
            String result = "String";
            String firstValue = (string)inputs[0];

            // check Double type
            double doubleValue;
            if (double.TryParse(firstValue, out doubleValue))
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if ((string)inputs[i] != "" && !double.TryParse((string)inputs[i], out doubleValue))
                    {
                        break;
                    }
                }
                result = "Double";
            }
            return result;
        }

        // == EXTRACT A COLUMN FROM DATAPOINTS ==
        public List<string> extractColumn(List<DataPoint> dp, int n)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < dp.Count; i++)
            {
                result.Add((string)dp[i].getValues()[n]);
            }
            return result;
        }

        // == LOAD CSV AND DATA WHEN BUTTON IS PRESSED ==
        private void button1_Click(object sender, EventArgs e)
        {
            loadObjects();
        }

        /*
         * ===================================================
         * ==================== CHARTS TAB ===================
         * ===================================================
         */

        // == INITIALIZE THE GLOBAL VARIABLES ==
        Bitmap b;
        Graphics g;
        Font smallFont = new Font("Calibri", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        Rectangle viewport;
        Rectangle viewport2;

        // == INITIALIZE THE GRAPHICS OBJECT ==
        private void initGraphics()
        {
            viewport = new Rectangle(Convert.ToInt32(pictureBox1.Width / 2) + 20, 10, Convert.ToInt32(pictureBox1.Width / 2) - 20, pictureBox1.Height - 200);
            viewport2 = new Rectangle(10, 10, Convert.ToInt32(pictureBox1.Width / 2) - 50, pictureBox1.Height - 100);
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
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
        private List<Interval> continuousDistribution(List<double> input)
        {
            bool valueAssigned = false;
            double endingPoint;
            double startingPoint;
            List<Interval> continuousValues = new List<Interval>();
            double min = 1000000;
            double max = 0;
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
            startingPoint = min;
            endingPoint = startingPoint + ((max - min) / 10);
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

        // == CALCULATE BIVARIATE CONTINUOUS DISTRIBUTION ==
        private Dictionary<Tuple<Interval, Interval>, int> bivariateContinuousDistribution(List<double> input1, List<Interval> distribution1, List<double> input2, List<Interval> distribution2)
        {
            Dictionary<Tuple<Interval, Interval>, int> result = new Dictionary<Tuple<Interval, Interval>, int>();

            for (int i = 0; i < input1.Count; i++)
            {
                double x = input1[i];
                double y = input2[i];
                Interval Intervalx = xBelongsTo(x, distribution1);
                Interval Intervaly = xBelongsTo(y, distribution2);
                var tuple = Tuple.Create(Intervalx, Intervaly);
                if (result.ContainsKey(tuple))
                {
                    result[tuple] += 1;
                }
                else
                {
                    result[tuple] = 1;
                }
            }
            return result;
        }

        // == DRAW THE CONTINGENCY TABLE ==
        private void drawContingencyTable(Dictionary<Tuple<Interval, Interval>, int> distribution, List<Interval> xIntervals, List<Interval> yIntervals)
        {
            string contingencyTable = "";
            SortedSet<Interval> s1 = new SortedSet<Interval>();
            SortedSet<Interval> s2 = new SortedSet<Interval>();
            foreach (Interval t in xIntervals)
            {
                if (!s1.Contains(t)) s1.Add(t);
            }
            foreach (Interval t in yIntervals)
            {
                if (!s2.Contains(t)) s2.Add(t);
            }

            //Table
            contingencyTable += "X/Y".ToString().PadRight(7);
            foreach (Interval i_Y in s2)
            {
                contingencyTable += i_Y.ToString().PadRight(13);

            }
            contingencyTable += "\n-----------------------------------------------------------------------------------------------------------------\n";
            foreach (Interval i_X in s1)
            {
                if (i_X != null)
                {
                    contingencyTable += i_X.ToString().PadRight(15);
                    foreach (Interval i_Y in s2)
                    {
                        Tuple<Interval, Interval> t = new Tuple<Interval, Interval>(i_X, i_Y);
                        double c = 0;
                        if (distribution.ContainsKey(t))
                            c = distribution[t];
                        else
                            c = 0;
                        contingencyTable += c.ToString().PadRight(13);
                    }
                    contingencyTable += "\n";
                }
            }

            g.DrawRectangle(Pens.Transparent, viewport2);
            g.DrawString(contingencyTable, smallFont, Brushes.Black, viewport2);
        }

        // == CREATE SCATTERPLOT ==
        private void createScatterPlot(List<double> input1, List<double> input2, List<Interval> xIntervals, List<Interval> yIntervals)
        {
            for (int i = 0; i < input1.Count; i++)
            {
                int x = Convert.ToInt32(input1[i]);
                if (x < minX_Window) minX_Window = x;
                if (x > maxX_Window) maxX_Window = x;

                int y = Convert.ToInt32(input2[i]);
                if (y < minY_Window) minY_Window = y;
                if (y > maxY_Window) maxY_Window = y;
            }
            //window
            rangeX = maxX_Window - minX_Window;
            rangeY = maxY_Window - minY_Window;

            g.DrawRectangle(Pens.Green, viewport);

            //Draw scatterplot
            for (int i = 0; i < input1.Count; i++)
            {
                double x = input1[i];
                double y = input2[i];
                int x_view = calculateXViewport(x, viewport, minX_Window, rangeX);
                int y_view = calculateYViewport(y, viewport, minY_Window, rangeY);

                g.FillEllipse(Brushes.Red, new Rectangle(new Point(x_view, y_view), new Size(4, 4)));

                // RUGPLOT
                g.FillEllipse(Brushes.Black, new Rectangle(new Point(viewport.Left, y_view), new Size(3, 3)));
                g.FillEllipse(Brushes.Black, new Rectangle(new Point(x_view, viewport.Bottom), new Size(3, 3)));
            }

            createHistogram(xIntervals, yIntervals);
        }

        // == FIND MAX VALUE IN INTERVALS ==
        private (int, int) maxIntervalCount(List<Interval> intervals)
        {
            int min = 100000000;
            int max = 0;
            foreach (Interval inte in intervals)
            {
                if (inte.count > max)
                {
                    max = inte.count;
                }
                if (inte.count < max)
                {
                    min = inte.count;
                }
            }
            return (min, max);
        }

        // == CALCULATE THE MEAN ==
        public double computeMean(List<double> input)
        {
            double currentMean = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (currentMean != 0)
                {
                    currentMean = (currentMean * i + input[i]) / (i + 1);
                }
                else
                {
                    currentMean = input[0];
                }
            }
            return currentMean;
        }

        // == CREATE HISTOGRAM ==
        private void createHistogram(List<Interval> xIntervals, List<Interval> yIntervals)
        {
            int maxX;
            int minX;
            (minX, maxX) = maxIntervalCount(xIntervals);
            foreach (Interval inte in xIntervals)
            {
                if (inte != null)
                {
                    int MaximumSize = 100;
                    int y = viewport.Bottom + 10;
                    int x = calculateXViewport(inte.lowerEnd, viewport, minX_Window, rangeX);
                    int width = calculateXViewport(inte.upperEnd, viewport, minX_Window, rangeX) - calculateXViewport(inte.lowerEnd, viewport, minX_Window, rangeX);
                    // x : MaximumSize = count : (maxX - minX)
                    int height = Convert.ToInt32((MaximumSize * inte.count) / (maxX - minX));
                    Rectangle rect = new Rectangle(x, y, width, height);
                    g.DrawRectangle(Pens.AliceBlue, rect);
                    g.FillRectangle(Brushes.Blue, rect);
                    // DRAW MEAN LINE
                    double mean = computeMean(inte.values);
                    int meanViewPort = calculateXViewport(mean, viewport, minX_Window, rangeX);
                    Point p1 = new Point(meanViewPort, y);
                    Point p2 = new Point(meanViewPort, y + height);
                    g.DrawLine(Pens.GreenYellow, p1, p2);
                }
            }
            int minY;
            int maxY;
            (minY, maxY) = maxIntervalCount(yIntervals);
            foreach (Interval inte in yIntervals)
            {
                if (inte != null)
                {
                    int MaximumSize = 100;
                    int x = (viewport.Left - 10) - Convert.ToInt32((MaximumSize * inte.count) / (maxY - minY));
                    int y = calculateYViewport(inte.upperEnd, viewport, minY_Window, rangeY);
                    int height = calculateYViewport(inte.lowerEnd, viewport, minY_Window, rangeY) - calculateYViewport(inte.upperEnd, viewport, minY_Window, rangeY);
                    // y : MaximumSize = count : (maxY - minY)
                    int width = Convert.ToInt32((MaximumSize * inte.count) / (maxY - minY));
                    Rectangle rect = new Rectangle(x, y, width, height);
                    g.DrawRectangle(Pens.AliceBlue, rect);
                    g.FillRectangle(Brushes.Blue, rect);
                    // DRAW MEAN LINE
                    double mean = computeMean(inte.values);
                    int meanViewPort = calculateYViewport(mean, viewport, minY_Window, rangeY);
                    Point p1 = new Point(x, meanViewPort);
                    Point p2 = new Point(x + width, meanViewPort);
                    g.DrawLine(Pens.GreenYellow, p1, p2);
                }
            }
        }

        // == CLEAN DATAPOINTS ==
        private (List<double>, List<double>) cleanDatapoints(List<string> input1, List<string> input2)
        {
            List<double> result1 = new List<double>();
            List<double> result2 = new List<double>();

            for (int i = 0; i < input1.Count; i++)
            {
                if (input1[i] != null && input1[i] != "" && input2[i] != null && input2[i] != "")
                {
                    double value1;
                    if (double.TryParse(input1[i], out value1))
                    {
                        double value2;
                        if (double.TryParse(input2[i], out value2))
                        {
                            result1.Add(value1);
                            result2.Add(value2);
                        }
                    }
                }
            }
            return (result1, result2);
        }

        // == CALCULATE THE STANDARD DEVIATION ==
        private double getStandardDeviation(List<double> doubleList, double average)
        {
            double sum = 0;
            foreach (double value in doubleList)
            {
                int intValue = Convert.ToInt32(value);
                sum += Math.Pow(intValue - average, 2);
            }
            return Math.Sqrt(sum/doubleList.Count);
        }

        // == CALCULATE THE COVARIANCE ==
        private double getCovariance(double meanX, double meanY, List<double> inputX, List<double> inputY)
        {
            double covariance = 0;
            for (int i = 0; i < inputX.Count(); i++)
            {
                covariance += (inputX[i] - meanX) * (inputY[i] - meanY);
            }
            return covariance / inputX.Count();
        }

        // == DRAW REGRESSION LINES ==
        private void drawRegressionLines(List<double> inputX, List<double> inputY)
        {
            double meanX = computeMean(inputX);
            double meanY = computeMean(inputY);
            double standardDeviationX = getStandardDeviation(inputX, meanX);
            double standardDeviationY = getStandardDeviation(inputY, meanY);
            double covXY = getCovariance(meanX, meanY, inputX, inputY);

            double m1 = covXY / Math.Pow(standardDeviationX, 2);

            // calculate y/x
            List<Point> punti1 = new List<Point>();
            for (int i = 0; i < inputX.Count(); i++)
            {
                double x1 = inputX[i];
                double y1 = m1 * (x1 - meanX) + meanY;
                int x_deviceX = calculateXViewport(x1, viewport, minX_Window, rangeX);
                int y_deviceX = calculateYViewport(y1, viewport, minY_Window, rangeY);

                punti1.Add(new Point(x_deviceX, y_deviceX));
            }

            //print y/x
            for (int i = 0; i < punti1.Count() - 1; i++)
            {
                g.DrawLine(Pens.Red, punti1[i], punti1[i+1]);
            }

            double m2 = covXY / Math.Pow(standardDeviationY, 2);

            // calculate x/y
            List<Point> punti2 = new List<Point>();
            for (int i = 0; i < inputY.Count(); i++)
            {
                double y2 = inputY[i];
                double x2 = m2 * (y2 - meanY) + meanX;
                int x_deviceY = calculateXViewport(x2, viewport, minX_Window, rangeX);
                int y_deviceY = calculateYViewport(y2, viewport, minY_Window, rangeY);

                punti2.Add(new Point(x_deviceY, y_deviceY));
            }

            //print x/y
            for (int i = 0; i < punti2.Count() - 1; i++)
            {
                g.DrawLine(Pens.Green, punti2[i], punti2[i+1]);
            }
        }

        // == PLOT EVERYTHING ==
        private void button2_Click(object sender, EventArgs e)
        {
            initGraphics();
            int maybeFirstValue;
            if (int.TryParse(textBox2.Text, out maybeFirstValue))
            {
                firstValue = maybeFirstValue;
            }
            else
            {
                firstValue = 0;
            }
            int maybeSecondValue;
            if (int.TryParse(textBox3.Text, out maybeSecondValue))
            {
                secondValue = maybeSecondValue;
            }
            else
            {
                secondValue = 1;
            }

            // reset viewport values
            minX_Window = 0;
            maxX_Window = 0;
            minY_Window = 0;
            maxY_Window = 0;
            rangeX = 0;
            rangeY = 0;
            columnD1 = new List<double>();
            columnD2 = new List<double>();
            xIntervals = new List<Interval>();
            yIntervals = new List<Interval>();
            bivariateDict = new Dictionary<Tuple<Interval, Interval>, int>();

            if (firstValue >= 0 && firstValue <= columns && secondValue >= 0 && secondValue <= columns)
            {
                List<string> column1 = extractColumn(datap, firstValue);
                List<string> column2 = extractColumn(datap, secondValue);
                (columnD1, columnD2) = cleanDatapoints(column1, column2);
                if (columnD1.Count != 0 && columnD2.Count != 0)
                {
                    xIntervals = continuousDistribution(columnD1);
                    yIntervals = continuousDistribution(columnD2);
                    bivariateDict = bivariateContinuousDistribution(columnD1, xIntervals, columnD2, yIntervals);
                    drawContingencyTable(bivariateDict, xIntervals, yIntervals);
                    createScatterPlot(columnD1, columnD2, xIntervals, yIntervals);
                    drawRegressionLines(columnD1, columnD2);
                    pictureBox1.Image = b;
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
            }
            if (e.Button == MouseButtons.Right)
            {
                point = e.Location;
                pictureBox1.Size = new Size(point.X, point.Y);
            }
            base.OnMouseMove(e);
            paintCanvas(bivariateDict, columnD1, columnD2, xIntervals, yIntervals);
        }

        // == UPDATE THE PICTUREBOX ==
        private void paintCanvas(Dictionary<Tuple<Interval, Interval>, int> bivariateDict, List<double> columnD1, List<double> columnD2, List<Interval> xIntervals, List<Interval> yIntervals)
        {
            if (bivariateDict != null)
            {
                initGraphics();
                drawContingencyTable(bivariateDict, xIntervals, yIntervals);
                createScatterPlot(columnD1, columnD2, xIntervals, yIntervals);
                drawRegressionLines(columnD1, columnD2);
                pictureBox1.Image = b;
            }
        }
    }
}

