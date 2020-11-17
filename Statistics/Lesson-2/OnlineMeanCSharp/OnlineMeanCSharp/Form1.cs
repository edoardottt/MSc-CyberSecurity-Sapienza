using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineMeanCSharp
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
            
            int grade = rnd.Next(18, 31);
            count = count + 1;
            string exam = "Exam" + count.ToString() + " ";
            mean = mean + (grade - mean) / count;
            richTextBox1.AppendText(exam + grade + " ===> Current Mean:" + mean + "\n");

        }
    }
}
