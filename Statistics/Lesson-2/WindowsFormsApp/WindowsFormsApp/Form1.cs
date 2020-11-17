using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var item in inputs)
                list.Add(item);
            list.Add(textBox1.Text);
            inputs = list.ToArray();

            bool isFloat = float.TryParse(textBox1.Text, out _);
            if (!isFloat)
            {
                distribution = true;
            }

            // DISTRIBUTION
            if (distribution)
            {
                IDictionary<string, int> values = new Dictionary<string, int>();

                for (int i=0; i<inputs.Length; i++)
                {
                    if (values.ContainsKey(inputs[i]))
                    {
                        values[inputs[i]] += 1;
                    }
                    else
                    {
                        values[inputs[i]] = 1;
                    }
                }
                richTextBox1.Text = "Distribution:\n";
                foreach (var item in values)
                    richTextBox1.Text += string.Format("{0}: {1}/{2}\n", item.Key, item.Value,inputs.Length);
            }
            else
            // ARITMETHIC MEAN
            {
                float sum = 0;
                float val;
                for (int i=0;i<inputs.Length; i++)
                {
                    float.TryParse(inputs[i], out val);
                    sum += val;
                }
                float result = sum / inputs.Length;
                richTextBox1.Text = "Arithmetic Mean: " + result;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            distribution = false;
            inputs = new string[]{ };
            richTextBox1.Text = "";
            textBox1.Text = "";
        }
    }
}
