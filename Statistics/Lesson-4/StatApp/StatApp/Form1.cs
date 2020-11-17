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
using Microsoft.VisualBasic.FileIO;

namespace StatApp
{
    public partial class Form1 : Form
    {
        public List<double> items = new List<double>();
        public Random R = new Random();
        public int values;
        public double Mean;
        public int Index;

        public Form1()
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

        // READ FILE DATA
        private void button1_Click(object sender, EventArgs e)
        {
            /* CHECK HEADER
             * CREATE DATAPOINTS
             * GUESS TYPES
             * CONVERT
             * SHOW TREEVIEW
             */
            // check if the textbox input is empty
            if (textBox1.Text != "")
            {
                List<DataPoint> datapoints = extractDataPoints();
                this.rows = datapoints.Count;
                this.datap = datapoints;
                if (rows != 0)
                {
                    List<Variable> variables = createVariables(datapoints);
                    this.columns = variables.Count;
                    this.vars = variables;
                    updateTreeview(datapoints, variables);
                }
            }
        }

        // UPDATE THE TREEVIEW
        public void updateTreeview(List<DataPoint> datapoints, List<Variable> variables)
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            for (int i = 0; i < variables.Count; i++)
            {
                string typeColumn;
                // check if is present user defined type
                if (variables[i].getUserSelectedDataType() != null)
                {
                    typeColumn = variables[i].getUserSelectedDataType();
                }
                else
                {
                    typeColumn = variables[i].getInferredDataType();
                }
                treeView1.Nodes.Add("Column " + i + ", name: " + variables[i].getName() + ", type: " + typeColumn);
                for (int j = 0; j < datapoints.Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add((string)datapoints[j].getValues()[i]);
                }
            }
            treeView1.EndUpdate();
        }

        // CREATE THE PREDICTION OF THE VARIABLES AND RETURNS THE LIST OF VARIABLES
        public List<Variable> createVariables(List<DataPoint> datapoints)
        {
            List<Variable> variables = new List<Variable>();

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
                    var = new Variable((string)headers[i], guessedType, null);
                }
                else
                {
                    var = new Variable("Column" + i, guessedType, null);
                }
                variables.Add(var);
            }
            return variables;
        }

        // READ CSV FILE AND CREATE DATAPOINTS
        public List<DataPoint> extractDataPoints()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(textBox1.Text))
                {
                    this.rows = 0;
                    this.headers = new ArrayList();
                    parser.Delimiters = new string[] { "," };
                    while (true)
                    {
                        string[] parts = parser.ReadFields();
                        if (parts == null)
                        {
                            break;
                        }
                        //Console.WriteLine("{0} field(s)", parts.Length);
                        // headers
                        if (this.rows == 0 && checkBox1.Checked)
                        {

                            for (int i = 0; i < parts.Length; i++)
                            {
                                this.headers.Add(parts[i]);
                            }
                        }
                        else
                        {   // values
                            ArrayList row = new ArrayList();
                            for (int i = 0; i < parts.Length; i++)
                            {
                                row.Add(parts[i]);
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

            // check Date type
            DateTime dateValue;
            if (DateTime.TryParse(firstValue, out dateValue))
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if ((string)inputs[i] != "" && !DateTime.TryParse((string)inputs[i], out dateValue))
                    {
                        break;
                    }

                }
                result = "Date";
            }

            // check Int type
            int intValue;
            if (int.TryParse(firstValue, out intValue))
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if ((string)inputs[i] != "" && !int.TryParse((string)inputs[i], out intValue))
                    {
                        break;
                    }

                }
                result = "Int";
            }

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

            // check Bool type
            bool boolValue;
            if (bool.TryParse(firstValue, out boolValue))
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if ((string)inputs[i] != "" && !bool.TryParse((string)inputs[i], out boolValue))
                    {
                        break;
                    }

                }
                result = "Bool";
            }
            return result;
        }

        // CHECK IF THE TYPE CONVERSION CAN BE DONE
        public bool checkColumn(List<String> input, String userType)
        {
            if (userType == "Int")
            {
                int intValue = 0;
                for (int i = 0; i < input.Count(); i++)
                {
                    Console.WriteLine(intValue + " " + input[i] + " " + input[i].Length.ToString());
                    if (input[i].Trim() != "" && input[i] != null && !int.TryParse(input[i], out intValue))
                    {
                        return false;
                    }
                }
            }
            if (userType == "Double")
            {
                double doubleValue;
                for (int i = 0; i < input.Count(); i++)
                {
                    if (input[i].Trim() != "" && input[i] != null && !double.TryParse(input[i], out doubleValue))
                    {
                        return false;
                    }
                }
            }
            else if (userType == "Bool")
            {
                bool boolValue;
                for (int i = 0; i < input.Count(); i++)
                {
                    if (input[i].Trim() != "" && input[i] != null && !bool.TryParse((string)input[i], out boolValue))
                    {
                        return false;
                    }
                }
            }
            else if (userType == "Date")
            {
                DateTime dateValue;
                for (int i = 0; i < input.Count(); i++)
                {
                    if (input[i].Trim() != "" && input[i] != null && !DateTime.TryParse((string)input[i], out dateValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public class Variable
        {
            string name;
            string inferredDataType;
            string userSelectedDataType;

            public Variable(string name, string inferredDataType, string userSelectedDataType)
            {
                this.name = name;
                this.inferredDataType = inferredDataType;
                this.userSelectedDataType = userSelectedDataType;
            }
            public string getUserSelectedDataType()
            {
                return userSelectedDataType;
            }

            public void setUserSelectedDataType(String u)
            {
                this.userSelectedDataType = u;
            }

            public string getInferredDataType()
            {
                return inferredDataType;
            }

            public string getName()
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

        // extract a column from datatpoints 
        public List<String> extractColumn(List<DataPoint> dp, int n)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < dp.Count; i++)
            {
                result.Add((string)dp[i].getValues()[n]);
            }
            return result;
        }

        // ON USER EDIT
        private void button2_Click(object sender, EventArgs e)
        {
            String column = this.textBox2.Text;
            // conversion from column string to column int
            try
            {
                int columnInt;
                if (!int.TryParse(column, out columnInt))
                {
                    MessageBox.Show("ERROR", "Enter a valid number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (columnInt < 0 || columnInt > this.columns)
                    {
                        MessageBox.Show("ERROR", "Enter a valid column number. [0 -" + (this.columns - 1).ToString() + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // read userInput and try conversion
                        string userType = "";
                        if (radioButton1.Checked)
                        {
                            userType = "Int";
                        }
                        else if (radioButton2.Checked)
                        {
                            userType = "String";
                        }
                        else if (radioButton3.Checked)
                        {
                            userType = "Bool";
                        }
                        else if (radioButton4.Checked)
                        {
                            userType = "Date";

                        }
                        else if (radioButton5.Checked)
                        {
                            userType = "Double";
                        }
                        if (this.datap != null && this.vars != null)
                        {
                            List<string> columnList = extractColumn((List<DataPoint>)this.datap, columnInt);
                            bool ColumnOk = checkColumn(columnList, userType);
                            if (ColumnOk)
                            {
                                this.vars[columnInt].setUserSelectedDataType(userType);
                                updateTreeview(this.datap, this.vars);
                            }
                            else
                            {
                                MessageBox.Show("ERROR", "Bad Conversion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR", "Read first a CSV file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR", exception.Message + ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PLOT
        private void button3_Click(object sender, EventArgs e)
        {
            bool isOK = false;
            int col1 = 0;
            int col2 = 0;
            (isOK, col1, col2) = columnsPlot();
            if (isOK)
            {

            }
        }


        // READ COLUMNS FOR PLOT
        private (bool,int,int) columnsPlot()
        {
            int col1 = -1;
            int col2 = -1;
            if (!int.TryParse(textBox3.Text, out col1))
            {
                MessageBox.Show("ERROR", "Column number must be a valid number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0,0);
            }
            else if (col1 < 0 || col1 > this.columns - 1)
            {
                MessageBox.Show("ERROR", "Column number must be a valid number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0, 0);
            }
            if (!int.TryParse(textBox4.Text, out col2))
            {
                MessageBox.Show("ERROR", "Column number must be a valid number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0, 0);
            }
            else if (col2 < 0 || col2 > this.columns - 1)
            {
                MessageBox.Show("ERROR", "Column number must be a valid number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0, 0);
            }
            if (col1 != -1 && col2 != -2)
            {
                return (true,col1,col2);
            }
            return (false, 0, 0);
        } 

        private List<Interval> Distribution()
        {
            var ListOfIntervals = new List<Interval>();
            double IntervalSize = 10d;
            double StartingEndPoint = 0d;
            var Intervallo = new Interval();
            Intervallo.LowerEnd = StartingEndPoint;
            Intervallo.UpperEnd = Intervallo.LowerEnd + IntervalSize;
            ListOfIntervals.Add(Intervallo);
            foreach (double item in items)
            {
                bool ExamAllocated = false;
                foreach (var interval in ListOfIntervals)
                {
                    if (item > interval.LowerEnd && item <= interval.UpperEnd)
                    {
                        interval.Count += 1;
                        ExamAllocated = true;
                        break;
                    }
                }

                if (ExamAllocated)
                    continue;
                if (item <= ListOfIntervals[0].LowerEnd)
                {
                    do
                    {
                        var NewLeftInterval = new Interval();
                        NewLeftInterval.UpperEnd = ListOfIntervals[0].LowerEnd;
                        NewLeftInterval.LowerEnd = NewLeftInterval.UpperEnd - IntervalSize;
                        ListOfIntervals.Insert(0, NewLeftInterval);
                        if (item > NewLeftInterval.LowerEnd && item <= NewLeftInterval.UpperEnd)
                        {
                            NewLeftInterval.Count += 1;
                            break;
                        }
                    }
                    while (true);
                }
                else if (item > ListOfIntervals[ListOfIntervals.Count - 1].UpperEnd)
                {
                    do
                    {
                        var NewRightInterval = new Interval();
                        NewRightInterval.LowerEnd = ListOfIntervals[ListOfIntervals.Count - 1].UpperEnd;
                        NewRightInterval.UpperEnd = NewRightInterval.LowerEnd + IntervalSize;
                        ListOfIntervals.Add(NewRightInterval);
                        if (item > NewRightInterval.LowerEnd && item <= NewRightInterval.UpperEnd)
                        {
                            NewRightInterval.Count += 1;
                            break;
                        }
                    }
                    while (true);
                }
                else
                {
                    throw new Exception("[===== ERROR =====]");
                }
            }
            return ListOfIntervals;
        }

        public partial class Interval
        {
            public double LowerEnd;
            public double UpperEnd;
            public int Count;
            public double RelativeFrequency;
            public double Percentage;
        }
    }
}
