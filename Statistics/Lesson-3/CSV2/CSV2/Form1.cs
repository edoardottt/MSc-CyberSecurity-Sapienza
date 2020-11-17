using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CSV2
{
    public partial class Form1 : Form
    {
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
                        MessageBox.Show("ERROR", "Enter a valid column number. [0 -" + this.columns.ToString() + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // CALCULATE MEAN AND DISTRIBUTION
        private void button3_Click(object sender, EventArgs e)
        {
            string column = this.textBox3.Text;
            this.richTextBox1.Clear();
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
                        MessageBox.Show("ERROR", "Enter a valid column number. [0 -" + this.columns.ToString() + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bool MeanBool = false;
                        if (this.vars[columnInt].getUserSelectedDataType() != null)
                        {
                            if (this.vars[columnInt].getUserSelectedDataType() == "Int" || this.vars[columnInt].getUserSelectedDataType() == "Double")
                            {
                                MeanBool = true;
                            }
                        }
                        else if (this.vars[columnInt].getInferredDataType() == "Int" || this.vars[columnInt].getInferredDataType() == "Double")
                        {
                            MeanBool = true;
                        }

                        if (this.datap != null && this.vars != null)
                        {
                            List<string> columnList = extractColumn((List<DataPoint>)this.datap, columnInt);
                            richTextBox1.Clear();
                            values.Clear();
                            int count = 0;
                            for (int i = 0; i < columnList.Count; i++)
                            {
                                count += 1;
                                if (values.ContainsKey(columnList[i]))
                                {
                                    values[columnList[i]] += 1;
                                }
                                else
                                {
                                    values[columnList[i]] = 1;
                                }
                            }
                            richTextBox1.Text += "Distribution:" + Environment.NewLine;
                            foreach (var item in values)
                            {
                                richTextBox1.Text += string.Format("Unit {0}: {1} / {2}" + Environment.NewLine, item.Key, item.Value, count);
                            }
                            if (MeanBool)
                            {
                                count = 0;
                                double mean = 0.0;
                                double doubleValue;
                                    
                                for (int i = 0; i < columnList.Count; i++)
                                {
                                    count = count + 1;
                                    double.TryParse(columnList[i], out doubleValue);
                                    mean = mean + (doubleValue - mean) / count;
                                }
                                richTextBox1.AppendText( Environment.NewLine + "Arithmetic Mean: " + mean + Environment.NewLine);
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
    }
}
