using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Lesson3CS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GENERATE WORDCLOUD
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphicsCanvas = Graphics.FromImage(canvas);
            graphicsCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsCanvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            pictureBox1.Image = canvas;
            values = new Dictionary<string, int>();
            string text = richTextBox1.Text;
            string[] subs = text.Split();
            List<string> stopWordsIta = new List<string> { "\n", "-", "\\", "/","0", "1", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "2", "20", "3", "4", "5", "6", "7", "8", "9", "A", "ABBIA", "ABBIAMO", "ABBIANO", "ABBIATE", "AD", "AGL", "AGLI", "AI", "AL", "ALL", "ALLA", "ALLE", "ALLO", "ALTRA", "ALTRE", "ALTRI", "ALTRO", "ANCHE", "ANCOR ", "ANCORA", "AVEMMO", "AVENDO", "AVESSE", "AVESSERO", "AVESSI", "AVESSIMO", "AVESTE", "AVESTI", "AVETE", "AVEVA", "AVEVAMO", "AVEVANO", "AVEVATE", "AVEVI", "AVEVO", "AVRAI", "AVRANNO", "AVREBBE", "AVREBBERO", "AVREI", "AVREMMO", "AVREMO", "AVRESTE", "AVRESTI", "AVRETE", "AVRÃ€", "AVRÃ’", "AVUTA", "AVUTE", "AVUTI", "AVUTO", "B", "C", "C'E'", "C'Ãˆ", "CE", "CH", "CHE", "CHI", "CHÃ‰", "CI", "CINQUE", "COI", "COL", "COME", "CON", "CONTRO", "COOKIE", "COOKIES", "CUI", "D", "DA", "DAGL", "DAGLI", "DAI", "DAL", "DALL", "DALLA", "DALLE", "DALLO", "DE", "DEGL", "DEGLI", "DEI", "DEL", "DELL", "DELLA", "DELLE", "DELLO", "DI", "DIECI", "DOV", "DOVE", "DUE", "E", "EBBE", "EBBERO", "EBBI", "ED", "ERA", "ERANO", "ERAVAMO", "ERAVATE", "ERI", "ERO", "ESSENDO", "F", "FA", "FACCIA", "FACCIAMO", "FACCIANO", "FACCIATE", "FACCIO", "FACEMMO", "FACENDO", "FACESSE", "FACESSERO", "FACESSI", "FACESSIMO", "FACESTE", "FACESTI", "FACEVA", "FACEVAMO", "FACEVANO", "FACEVATE", "FACEVI", "FACEVO", "FAI", "FANNO", "FARAI", "FARANNO", "FAREBBE", "FAREBBERO", "FAREI", "FAREMMO", "FAREMO", "FARESTE", "FARESTI", "FARETE", "FARÃ€", "FARÃ’", "FECE", "FECERO", "FECI", "FOSSE", "FOSSERO", "FOSSI", "FOSSIMO", "FOSTE", "FOSTI", "FU", "FUI", "FUMMO", "FURONO", "G", "GIÃ€", "GLI", "H", "HA", "HAI", "HANNO", "HO", "I", "II", "III", "IL", "IN", "IO", "IV", "IX", "K", "L", "LA", "LE", "LEI", "LI", "LO", "LORO", "LUI", "LÃ€", "M", "MA", "ME", "MI", "MIA", "MIE", "MIEI", "MIO", "N", "NE", "NEGL", "NEGLI", "NEI", "NEL", "NELL", "NELLA", "NELLE", "NELLO", "NOI", "NON", "NOSTRA", "NOSTRE", "NOSTRI", "NOSTRO", "NOVE", "NÃ‰", "O", "OD", "OGNI ", "OR", "OTTO", "P", "PASSWORD", "PAURA", "PER", "PERCHÃ‰", "PIÃ™", "POCO", "POI", "PUÃ’", "Q", "QUAL", "QUALE", "QUANDO ", "QUANTA", "QUANTE", "QUANTI", "QUANTO", "QUATTRO", "QUEL ", "QUELLA", "QUELLE", "QUELLI", "QUELLO", "QUESTA", "QUESTE", "QUESTI", "QUESTO", "R", "S", "SARAI", "SARANNO", "SAREBBE", "SAREBBERO", "SAREI", "SAREMMO", "SAREMO", "SARESTE", "SARESTI", "SARETE", "SARÃ€", "SARÃ’", "SE", "SEI", "SETTE", "SI", "SIA", "SIAMO", "SIANO", "SIATE", "SIETE", "SONO", "STA", "STAI", "STANDO", "STANNO", "STARAI", "STARANNO", "STAREBBE", "STAREBBERO", "STAREI", "STAREMMO", "STAREMO", "STARESTE", "STARESTI", "STARETE", "STARÃ€", "STARÃ’", "STAVA", "STAVAMO", "STAVANO", "STAVATE", "STAVI", "STAVO", "STEMMO", "STESSE", "STESSERO", "STESSI", "STESSIMO", "STESTE", "STESTI", "STETTE", "STETTERO", "STETTI", "STIA", "STIAMO", "STIANO", "STIATE", "STO", "SU", "SUA", "SUE", "SUGL", "SUGLI", "SUI", "SUL", "SULL", "SULLA", "SULLE", "SULLO", "SUO", "SUOI", "SÃŒ", "T", "TANTA ", "TANTE", "TANTI", "TANTO", "TI", "TRA", "TRE", "TU", "TUA", "TUE", "TUO", "TUOI", "TUTTI", "TUTTO", "U", "UN", "UNA", "UNO", "V", "VI", "VIA", "VII", "VIII", "VOI", "VOSTRA", "VOSTRE", "VOSTRI", "VOSTRO", "W", "X", "XI", "XII", "XIII", "XIV", "XV", "Y", "Z", "Ã€", "Ãˆ", "Ã‰", "ÃŒ", "Ã’", "Ã™", "," };
            List<string> cleanSubs = new List<string>();
            bool stop = false;
            for (int i = 0; i < subs.Length; i++)
            {
                for (int j = 0; j < stopWordsIta.Count; j++)
                {
                    if (subs[i].ToUpper() == stopWordsIta[j])
                    {
                        stop = true;
                        break;
                    }
                }
                if (!stop) cleanSubs.Add(subs[i].Trim());
                stop = false;
            }
            SortedDictionary<int, List<string>> result = wordCloudValues(cleanSubs);
            int count = 0;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphicsCanvas = Graphics.FromImage(canvas);
            graphicsCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsCanvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Random rnd = new Random();
            List<RectangleF> rects = new List<RectangleF>();
            foreach (int key in result.Keys)
            {
                if (count == 40)
                {
                    break;
                }
                foreach (string value in result[key])
                {
                    if (count == 40)
                    {
                        break;
                    }
                    Font font = new Font("Times New Roman", 3f * key);
                    SizeF s = graphicsCanvas.MeasureString(value, font);
                    int tries = 0;
                    bool drawn = false;
                    while (tries < 1000)
                    {
                        tries++;
                        int x = rnd.Next(0, pictureBox1.Width -50);
                        int y = rnd.Next(0, pictureBox1.Height -50);
                        RectangleF drawRect = new RectangleF(new Point(x, y), s);
                        if (!spotAlreadyOccupied(rects, drawRect))
                        {
                            graphicsCanvas.DrawString(value, font, randomColor(), drawRect);
                            rects.Add(drawRect);
                            drawn = true;
                            count++;
                        }
                        if (drawn) break;
                    }
                }
            }

            pictureBox1.Image = canvas;
            // DEBUG 
            /*
            richTextBox1.Text += "-------------------------------\n";
            foreach (int key in result.Keys)
            {
                richTextBox1.Text += key.ToString() + " ";
                foreach (string value in result[key])
                {
                    richTextBox1.Text += value + " ";
                }
                richTextBox1.Text += "\n";
            }
            */
        }

        private bool spotAlreadyOccupied(List<RectangleF> rects, RectangleF target)
        {
            if (rects.Count == 0) return false;

            foreach (RectangleF rect in rects)
            {
                if (rect.IntersectsWith(target)) return true;
                if (rect.Contains(target)) return true;
                if (target.Contains(rect)) return true;
            }
            return false;
        }

        //CALCULATE THE WORDCLOUD TOP VALUES
        public SortedDictionary<int, List<string>> wordCloudValues(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (values.ContainsKey(input[i]))
                {
                    values[input[i]] += 1;
                }
                else
                {
                    values[input[i]] = 1;
                }
            }
            SortedDictionary<int, List<string>> orderedValues = new SortedDictionary<int, List<string>>(new DescendingComparer<int>());
            foreach (string key in values.Keys)
            {
                if (orderedValues.ContainsKey(values[key]))
                {
                    orderedValues[values[key]].Add(key);
                }
                else
                {
                    orderedValues[values[key]] = new List<string> { key };
                }
            }
            SortedDictionary<int, List<string>> result = new SortedDictionary<int, List<string>>(new DescendingComparer<int>());
            int count = 0;
            foreach (int key in orderedValues.Keys)
            {
                result[key] = orderedValues[key];
                count++;
                if (count == 20) {
                    break;
                }
            }
            return result;
        }

        public Brush randomColor()
        {
            List<System.Drawing.Brush> brushes = new List<System.Drawing.Brush>();
            brushes.Add(Brushes.Red);
            brushes.Add(Brushes.Yellow);
            brushes.Add(Brushes.Black);
            brushes.Add(Brushes.Blue);
            brushes.Add(Brushes.Orange);
            brushes.Add(Brushes.Green);
            Random rnd = new Random();
            return brushes[rnd.Next(6)];
        }

        class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
