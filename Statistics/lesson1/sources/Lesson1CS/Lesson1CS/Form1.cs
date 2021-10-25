using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson1CS
{
    public partial class Lesson1 : Form
    {
        public Lesson1()
        {
            InitializeComponent();
        }

        private bool running = false;
        private bool populated = false;
        private Timer timer = new Timer();
        List<Ball> balls = new List<Ball>();
        Ball ball1 = new Ball(20, 20, 0, 0, 24, 24);
        Ball ball2 = new Ball(30, 30, 10, 10, 20, 20);
        Ball ball3 = new Ball(40, 40, 20, 20, 16, 16);
        Ball ball4 = new Ball(50, 50, 30, 30, 12, 12);
        Ball ball5 = new Ball(60, 60, 40, 40, 8, 8);

        private void populateBalls()
        {
            pictureBox1.BackColor = Color.White;
            balls.Add(ball1);
            balls.Add(ball2);
            balls.Add(ball3);
            balls.Add(ball4);
            balls.Add(ball5);
        }

        // This function handles the add text functionality
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Hello World! Click the button below to animate the balls, click again to stop them.";
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionFont = new Font("Maiandra GD", 13);
        }

        // This function handles the balls movement functionality
        private void button2_Click(object sender, EventArgs e)
        {
            if (!populated)
            {
                populateBalls();
                populated = true;
            }
            if (!running)
            {
                running = true;
                timer.Tick += new EventHandler(timer_Tick);
                // Sets the timer interval to 10 milliseconds.
                timer.Interval = 10;
                timer.Start();
            }
            else
            {
                timer.Stop();
                running = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                updateBall(sender, e, balls[i]);
            }
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new PaintEventHandler(DrawCircles);
        }

        // this function updates the position of the balls.
        private void updateBall(object sender, EventArgs e, Ball b)
        {
            int width = b.GetWidth();
            int height = b.GetHeight();
            int x = b.GetX();
            int y = b.GetY();
            int stepx = b.GetStepX();
            int stepy = b.GetStepY();

            x += stepx;

            if (x + width > pictureBox1.Width || x < 0)
            {
                stepx = -stepx;
            }

            y += stepy;

            if (y + height > pictureBox1.Height || y < 0)
            {
                stepy = -stepy;
            }

            b.SetWidth(width);
            b.SetHeight(height);
            b.SetX(x);
            b.SetY(y);
            b.SetStepX(stepx);
            b.SetStepY(stepy);

            pictureBox1.Refresh();
        }

        private void DrawCircles(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < balls.Count; i++)
            {
                int width = balls[i].GetWidth();
                int height = balls[i].GetHeight();
                int x = balls[i].GetX();
                int y = balls[i].GetY();
                e.Graphics.FillEllipse(Brushes.Yellow,
                x, y,
                width, height);
                e.Graphics.DrawEllipse(Pens.Black,
                    x, y,
                    width, height);
            }
        }
    }
}