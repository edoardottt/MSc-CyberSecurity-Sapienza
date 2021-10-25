using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;


namespace Lesson2CS2
{
    public class CustomPictureBox : PictureBox 
    {
        public CustomPictureBox(IContainer container)
        {
            container.Add(this);
        }

        Point point;
        Rectangle viewport;
        Bitmap canvas;
        Graphics graphicsCanvas;
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            point = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
            if (e.Button == MouseButtons.Right)
            {
                point = e.Location;
                this.Size = new Size(point.X, point.Y);
            }
            base.OnMouseMove(e);
            PaintCanvas();
        }

        public void PaintCanvas()
        {
            viewport = new Rectangle(0, 0, this.Width, this.Height);
            canvas = new Bitmap(this.Width, this.Height);
            graphicsCanvas = Graphics.FromImage(canvas);
            graphicsCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsCanvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphicsCanvas.FillRectangle(Brushes.Red, viewport);
            this.Image = canvas;
        }
    }
}
