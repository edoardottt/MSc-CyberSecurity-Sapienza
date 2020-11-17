using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributionCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string grade = rnd.Next(18, 31).ToString();
            count +=1;
            if (values.ContainsKey(grade))
            {
                values[grade] += 1;
            }
            else
            {
                values[grade] = 1;
            }
            richTextBox1.Text = "Distribution:" + Environment.NewLine;
            foreach (var item in values) {
                richTextBox1.Text += string.Format("Grade {0}: {1} / {2}" + Environment.NewLine, item.Key, item.Value, count);
            }
        }
    }
}