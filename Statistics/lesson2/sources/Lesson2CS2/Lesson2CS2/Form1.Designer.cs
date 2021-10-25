
namespace Lesson2CS2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.customPictureBox1 = new Lesson2CS2.CustomPictureBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // customPictureBox1
            // 
            this.customPictureBox1.Location = new System.Drawing.Point(348, 119);
            this.customPictureBox1.Name = "customPictureBox1";
            this.customPictureBox1.Size = new System.Drawing.Size(303, 189);
            this.customPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.customPictureBox1.TabIndex = 0;
            this.customPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 527);
            this.Controls.Add(this.customPictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox customPictureBox1;
    }
}

