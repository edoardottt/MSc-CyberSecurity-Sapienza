using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson6
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
        double p = 0; //probability of success (0 - 1)
        double epsilon = 0; //epsilon
        Point point; // mouse location handler
        double minX_Window = 0;
        double maxX_Window = 0;
        double minY_Window = 0;
        double maxY_Window = 0;
        double rangeX = 0;
        double rangeY = 0;
        Dictionary<int, List<double>> points; // All the random generated points
        Bitmap b;
        Graphics g;
        Font smallFont = new Font("Calibri", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        Rectangle viewport;

        // == INITIALIZE THE GRAPHICS OBJECT ==
        private void initGraphics()
        {
            viewport = new Rectangle(10, 10, Convert.ToInt32(pictureBox1.Width / 2) - 50, pictureBox1.Height - 100);
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
            p = 0;
            if (!Double.TryParse(textBox3.Text, out p))
            {
                richTextBox1.Text = "P must be a valid double!";
                return false;
            }
            if (p < 0 || p > 1)
            {
                richTextBox1.Text = "P must be a valid double between 0 and 1!";
                return false;
            }
            epsilon = 0;
            if (!Double.TryParse(textBox4.Text, out epsilon))
            {
                richTextBox1.Text = "epsilon must be a valid double!";
                return false;
            }
            if (epsilon < 0 || epsilon > 1)
            {
                richTextBox1.Text = "Epsilon must be a valid double between 0 and 1!";
                return false;
            }
            return true;
        }

        // == PLOT EVERYTHING ==
        private void button1_Click(object sender, EventArgs e)
        {
            bool inputOk = checkInput();
            if (inputOk)
            {
                richTextBox1.Text = "> " + m + " " + n + " " + p + " " + epsilon + "\n";
            }
        }
    }
}
