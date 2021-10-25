using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Lesson3CS1
{
    public partial class Lesson3CS1 : Form
    {

        int firstValue = 0;
        int secondValue = 1;

        public Lesson3CS1()
        {
            InitializeComponent();
        }

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

        // LOAD CSV PATH
        private void button1_Click(object sender, EventArgs e)
        {
            values = new Dictionary<string, int>();
            bivalues = new Dictionary<(string, string), int>();
            richTextBox2.Text = "";
            firstValue = 0;
            textBox2.Text = "0";
            secondValue = 1;
            textBox3.Text = "1";
            loadObjects();
        }

        // CONFIRM FIRST VARIABLE
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            values = new Dictionary<string, int>();
            bivalues = new Dictionary<(string, string), int>();
            if (!(textBox2.Text == "" || textBox2.Text == null))
            {
                int possibleValue1 = int.Parse(textBox2.Text);
                if (datap.Count >= possibleValue1 && possibleValue1 >= 0)
                {
                    firstValue = possibleValue1;
                }
            }
            loadObjects();
            List<String> column = extractColumn(datap, firstValue);
            List<String> column2 = extractColumn(datap, secondValue);
            ArrayList arrayList = new ArrayList(column);
            if (guessType(arrayList) == "Double")
            {
                List<double> newList = new List<double>();
                for (int i = 0; i < arrayList.Count; i++)
                {
                    double result = Double.Parse(column[i]);
                    newList.Add(result);
                }
                double mean = computeMean(newList);
                richTextBox2.Text += "Mean: " + mean.ToString() + "\n";
                univariateDistribution(column);
                double sd = getStandardDeviation(newList);
                richTextBox2.Text += "Standard Deviation: " + sd.ToString() + "\n";
            }
            else
            {
                richTextBox2.Text += "Cannot compute the mean for first variable.\n";
                univariateDistribution(column);
                richTextBox2.Text += "Cannot compute the standard deviation for first variable.\n";
            }
            bivariateDistribution(column, column2);
        }

        // CONFIRM SECOND VARIABLE
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            values = new Dictionary<string, int>();
            bivalues = new Dictionary<(string, string), int>();
            if (!(textBox3.Text == "" || textBox3.Text == null))
            {
                int possibleValue2 = int.Parse(textBox3.Text);
                if (datap.Count >= possibleValue2)
                {
                    secondValue = possibleValue2;
                }
            }
            loadObjects();
            List<String> column = extractColumn(datap, firstValue);
            List<String> column2 = extractColumn(datap, secondValue);
            ArrayList arrayList = new ArrayList(column);
            if (guessType(arrayList) == "Double")
            {
                List<double> newList = new List<double>();
                for (int i = 0; i < arrayList.Count; i++)
                {
                    double result = Double.Parse(column[i]);
                    newList.Add(result);
                }
                double mean = computeMean(newList);
                richTextBox2.Text += "Mean: " + mean.ToString() + "\n";
                univariateDistribution(column);
                double sd = getStandardDeviation(newList);
                richTextBox2.Text += "Standard Deviation: " + sd.ToString() + "\n";
            }
            else
            {
                richTextBox2.Text += "Cannot compute the mean for first variable.\n";
                univariateDistribution(column);
                richTextBox2.Text += "Cannot compute the standard deviation for first variable.\n";
            }
            bivariateDistribution(column, column2);
        }

        // READ FILE DATA
        private void loadObjects()
        {
            /* CHECK HEADER
             * CREATE DATAPOINTS
             * GUESS TYPES
             * CONVERT
             * SHOW TREEVIEW
             */
            List<DataPoint> datapoints = extractDataPoints();
            this.rows = datapoints.Count;
            this.datap = datapoints;
            List<Variable> variables = createVariables(datapoints);
            this.columns = variables.Count;
            this.vars = variables;
            updateTreeview(datapoints, variables);
        }

        // UPDATE THE TREEVIEW
        public void updateTreeview(List<DataPoint> datapoints, List<Variable> variables)
        {
            treeView2.Nodes.Clear();
            treeView2.BeginUpdate();
            for (int i = 0; i < variables.Count; i++)
            {
                string typeColumn;
                typeColumn = variables[i].getInferredDataType();
                treeView2.Nodes.Add("Column " + i + ", name: " + variables[i].getName() + ", type: " + typeColumn);
                for (int j = 0; j < datapoints.Count; j++)
                {
                    treeView2.Nodes[i].Nodes.Add((string)datapoints[j].getValues()[i]);
                }
            }
            treeView2.EndUpdate();
        }

        // CREATE THE PREDICTION OF THE VARIABLES AND RETURNS THE LIST OF VARIABLES
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

        // READ CSV FILE AND CREATE DATAPOINTS
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

        // GUESS THE TYPE OF A VARIABLE
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

        // extract a column from datatpoints 
        public List<String> extractColumn(List<DataPoint> dp, int n)
        {
            List<String> result = new List<String>();
            for (int i = 0; i < dp.Count; i++)
            {
                result.Add((string)dp[i].getValues()[n]);
            }
            return result;
        }

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

        // CALCULATE THE MEAN
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

        //CALCULATE THE UNIVARIATE DISTRIBUTION
        public void univariateDistribution(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (values.ContainsKey(input[i]))
                {
                    values[input[i]] += 1;
                }
                else
                {
                    values[input[i]] = 1;
                }
            }
            richTextBox2.Text += "Univariate Distribution:\n";
            foreach (var item in values)
                richTextBox2.Text += string.Format("{0}: {1}/{2}\n", item.Key, item.Value, input.Count);
        }

        // CALCULATE THE STANDARD DEVIATION
        private double getStandardDeviation(List<double> doubleList)
        {
            double average = computeMean(doubleList);
            double sumOfDerivation = 0;
            foreach (double value in doubleList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / (doubleList.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }

        //CALCULATE THE BIVARIATE DISTRIBUTION
        public void bivariateDistribution(List<string> input1, List<string> input2)
        {
            for (int i = 0; i < input1.Count; i++)
            {
                (string, string) tuple = (input1[i], input2[i]);
                if (bivalues.ContainsKey(tuple))
                {
                    bivalues[tuple] += 1;
                }
                else
                {
                    bivalues[tuple] = 1;
                }
            }
            richTextBox2.Text += "Bivariate Distribution:\n";
            foreach (var item in bivalues)
                richTextBox2.Text += string.Format("{0}: {1}/{2}\n", item.Key, item.Value, input1.Count);
        }
    }
}
