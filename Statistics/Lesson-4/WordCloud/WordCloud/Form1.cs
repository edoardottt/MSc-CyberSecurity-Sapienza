using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WordCloud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String url = this.textBox1.Text.Trim();
            try
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                this.webBrowser1.Url = new Uri(url);
            }
            catch (Exception)
            {
                MessageBox.Show("[ERROR]", " Enter a valid URL.", MessageBoxButtons.OK);
            }

        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            textBox2.Clear();
            for (i = 0; i < s.Length; i++)
                textBox2.Text += s[i];
        }

        private ArrayList cleanWords(ArrayList input)
        {
            string line;
            ArrayList stopWords = new ArrayList();
            ArrayList filtered = new ArrayList();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(this.textBox2.Text);
            while ((line = file.ReadLine()) != null)
            {
                stopWords.Add(line);
            }
            file.Close();
            for (int i = 0; i < input.Count; i++)
            {
                bool toAdd = true;
                string word = (string)input[i];
                for (int j = 0; j < stopWords.Count; j++)
                {
                    if (word == (string)stopWords[j])
                    {
                        toAdd = false;
                        break;
                    }
                }
                if (toAdd)
                {
                    filtered.Add(word);
                }
            }
            return filtered;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Document.ExecCommand("SelectAll", false, null);
            this.webBrowser1.Document.ExecCommand("Copy", false, null);
            this.webBrowser1.Document.ExecCommand("UnSelect", false, Type.Missing);
            this.content = Clipboard.GetText();
            string[] ls = this.content.Split(' ');
            ArrayList input = new ArrayList();
            for (int i = 0; i < ls.Length; i++)
            {
                string possibleString = (string)ls[i].Trim(new char[] { ',', '.', '-', '_', '!', '?', ':', ';', '#', '@' });
                if (possibleString != "")
                {
                    input.Add(possibleString);
                }
            }
            // clean the list from the stopwords
            input = cleanWords(input);
            // compute the distribution
            Dictionary<string, int> d = distribution(input);
            // sort the dictionary and pick only the top #n items 
            Dictionary<string, int> result = sortDict(d, 50);
            // plot the wordcloud
            Random r = new Random();
            InitializeGraphics();
            Rectangle viewPort = new Rectangle(0, 0,pictureBox1.Width,pictureBox1.Height);
            ArrayList rectangles = new ArrayList();
            this.g.DrawRectangle(Pens.White, viewPort);
            foreach (string key in result.Keys)
            {
                int value = result[key];
                Rectangle tryRect = new Rectangle();
                Font f = new Font("arial", value * 3);
                Size s = Size.Truncate(g.MeasureString(key, f));
                int tries = 0;
                bool Found = false;
                while (!Found && tries < 1000)
                {
                    tries++;
                    int x = r.Next(viewPort.Left, viewPort.Right + 1);
                    int y = r.Next(viewPort.Top, viewPort.Bottom + 1);
                    tryRect = new Rectangle(new Point(x, y), s);
                    if (spotIsAlreadyOccupied(viewPort, tryRect, rectangles)) continue;
                    else { Found = true; }
                }
                this.g.DrawString(key, f, new SolidBrush(giveRandomColor()), new Point(tryRect.X, tryRect.Y));
                rectangles.Add(tryRect);
            }
            this.pictureBox1.Image = b;
        }

        public void InitializeGraphics()
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            
        }

        private bool spotIsAlreadyOccupied(Rectangle viewport, Rectangle tryRect, ArrayList rectangles)
        {
            if (viewport.Contains(tryRect))
            {
                if (rectangles.Count == 0) return false;
                if (viewport.IntersectsWith(tryRect)) return true;
                foreach (Rectangle spot in rectangles)
                {
                    if (spot.IntersectsWith(tryRect)) return true;
                    if (spot.Contains(tryRect)) return true;
                    if (tryRect.Contains(spot)) return true;
                }
                return false;
            }
            else {
                return true;
            }
        }

        public Color giveRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private Dictionary<string,int> distribution(ArrayList input)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < input.Count; i++)
            {   
                string elem = (string)input[i];
                if (result.ContainsKey(elem))
                {
                    result[elem]++;
                }
                else
                {
                    result[elem] = 1;
                }
            }
            return result;
        }

        private Dictionary<string, int> sortDict(Dictionary<string, int> d, int length)
        {
            var sortedDict = from entry in d orderby entry.Value descending select entry;
            Dictionary<string, int> result =  sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
            if (result.Keys.Count > length)
            {
                Dictionary<string, int> temp = new Dictionary<string, int>();
                int count = 0;
                foreach (string k in result.Keys)
                {
                    count++;
                    if (count >= length) break;
                    temp[k] = result[k];
                }
                result = temp;
            }
            return result;
        }
    }
}
