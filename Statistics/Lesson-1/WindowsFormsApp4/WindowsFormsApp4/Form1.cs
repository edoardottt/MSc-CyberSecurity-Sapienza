using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Hello, World!";
        }

        private void richTextBox1_MouseHover(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Red;
        }

        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for(i = 0; i < s.Length; i++)
                richTextBox1.Text += s[i];
        }
    }
}
