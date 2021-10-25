using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lesson2CS1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool randomDiscreteRunning = false;
        private bool randomContinuousRunning = false;
        private IDictionary<string, int> values;
        private List<Interval> continuousValues;
        private Random rnd;
        string[] inputs;
        private bool distribution;
        float meanValue = 0;
        int randomCount = 0;
        double baseValue = 100;
        double min = 0;
        double max = 100;
        int startingPoint = 150;
        int endingPoint = 160;


        private void Insert_Click(object sender, EventArgs e)
        {
            if (values == null)
            {
                values = new Dictionary<string, int>();
            }
            if (continuousValues == null)
            {
                continuousValues = new List<Interval>();
            }
            if (rnd == null)
            {
                rnd = new Random();
            }
            if (timer1 == null)
            {
                timer1 = new Timer();
            }
            if (inputs == null)
            {
                inputs = new string[] { };
            }
            if (textBox1.Text.Length != 0)
            {
                List<string> list = new List<string>();
                if (inputs.Length != 0) {
                    foreach (var item in inputs)
                        list.Add(item);
                }
                list.Add(textBox1.Text);    
                inputs = list.ToArray();

                bool isFloat = float.TryParse(textBox1.Text, out _);
                if (!distribution)
                {
                    distribution = !isFloat;
                }

                // DISTRIBUTION
                if (distribution)
                {
                    meanValue = 0;
                    richTextBox1.Text = "";
                    values.Clear();

                    for (int i = 0; i < inputs.Length; i++)
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
                        richTextBox1.Text += string.Format("{0}: {1}/{2}\n", item.Key, item.Value, inputs.Length);
                }
                else
                // ONLINE ARITMETHIC MEAN
                {
                    float val;
                    float.TryParse(textBox1.Text, out val);
                    if (meanValue != 0) {
                        meanValue = (meanValue * (inputs.Length - 1) + val) / inputs.Length;
                    } else
                    {
                        meanValue = val;
                    }
                    richTextBox1.Text = "Online arithmetic Mean: " + meanValue;
                    textBox1.Text = "";
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            values = new Dictionary<string, int>();
            continuousValues = new List<Interval>();
            rnd = new Random();
            timer1 = new Timer();
            randomDiscreteRunning = false;
            randomContinuousRunning = false;
            meanValue = 0;
            richTextBox1.Text = "";
            inputs = new string[] {};
            distribution = false;
            textBox1.Text = "";
            randomCount = 0;
        }

        private void Random_Click(object sender, EventArgs e)
        {
            if (values == null)
            {
                values = new Dictionary<string, int>();
            }
            if (continuousValues == null)
            {
                continuousValues = new List<Interval>();
            }
            if (rnd == null)
            {
                rnd = new Random();
            }
            if (timer1 == null)
            {
                timer1 = new Timer();
            }
            if (randomContinuousRunning)
            {
                timer1.Stop();
                randomContinuousRunning = false;
                richTextBox1.Text = "";
            }
            if (randomDiscreteRunning) {
                timer1.Stop();
                randomDiscreteRunning = false;
            } 
            else
            {   
                richTextBox1.Text = "";
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 500;
                timer1.Start();
                randomDiscreteRunning = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string value = rnd.Next(0, 100).ToString();
            float val;
            randomCount += 1;
            float.TryParse(value, out val);
            if (meanValue != 0)
            {
                meanValue = (meanValue * (randomCount - 1) + val) / randomCount;
            }
            else
            {
                meanValue = val;
            }
            richTextBox1.Text = "Online arithmetic Mean: " + meanValue + "\n";
            textBox1.Text = "";
            if (values.ContainsKey(value))
            {
                values[value] += 1;
            }
            else
            {
                values[value] = 1;
            }
            richTextBox1.Text += "Distribution:" + "\n";
            foreach (var item in values)
            {
                richTextBox1.Text += string.Format("Item {0}: {1} / {2}" + "\n", item.Key, item.Value, values.Keys.Count);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (values == null)
            {
                values = new Dictionary<string, int>();
            }
            if (continuousValues == null)
            {
                continuousValues = new List<Interval>();
            }
            if (rnd == null)
            {
                rnd = new Random();
            }
            if (timer1 == null)
            {
                timer1 = new Timer();
            }
            if (randomDiscreteRunning)
            {
                timer1.Stop();
                randomDiscreteRunning = false;
                richTextBox1.Text = "";
            }
            if (randomContinuousRunning)
            {
                timer1.Stop();
                randomContinuousRunning = false;
            }
            else
            {
                // first interval
                Interval interval0 = new Interval();
                interval0.lowerEnd = startingPoint;
                interval0.upperEnd = endingPoint;
                interval0.count = 0;
                continuousValues.Add(interval0);
                randomCount = 0;
                richTextBox1.Text = "";
                timer1.Tick += new EventHandler(continuous_Tick);
                timer1.Interval = 500;
                timer1.Start();
                randomContinuousRunning = true;
            }
        }

        private void continuous_Tick(object sender, EventArgs e)
        {
            // generate new continuous random value         
            double value = baseValue + (max - min) * rnd.NextDouble();
            randomCount +=1;
            bool valueAssigned = false;

            for (int i = 0; i < continuousValues.Count; i++)
            {
                if (value >= continuousValues[i].lowerEnd && value <= continuousValues[i].upperEnd) 
                {
                    continuousValues[i].count += 1;
                    break;
                }
                // LEFT
                if (value < continuousValues[i].lowerEnd)
                {
                    if (valueAssigned)
                    {
                        break;
                    }
                    Interval item = continuousValues[i];
                    int j = i;
                    while (value < item.lowerEnd)
                    {
                        if (j == 0) {
                            // generate a new interval on the left
                            Interval interval = new Interval();
                            interval.lowerEnd = item.lowerEnd - (endingPoint - startingPoint);
                            interval.upperEnd = item.lowerEnd;
                            interval.count = 0;
                            continuousValues.Insert(0, interval);
                        }
                        else
                        {
                            j--;
                        }
                        item = continuousValues[j];
                    }
                    if (value >= continuousValues[0].lowerEnd && value <= continuousValues[0].upperEnd)
                    {
                        continuousValues[0].count += 1;
                        valueAssigned = true;
                        break;
                    }
                }
                // RIGHT
                if (value > continuousValues[i].upperEnd)
                {
                    Interval item = continuousValues[i];
                    int j = i;
                    while (value > item.upperEnd)
                    {
                        if (j == continuousValues.Count-1)
                        {
                            // generate a new interval on the right
                            Interval interval = new Interval();
                            interval.lowerEnd = item.upperEnd;
                            interval.upperEnd = item.upperEnd + (endingPoint - startingPoint);
                            interval.count = 0;
                            continuousValues.Add(interval);
                        }
                        else
                        {
                            j++;
                        }
                        item = continuousValues[j];
                    }
                    int last = continuousValues.Count - 1;
                    if (value >= continuousValues[last].lowerEnd && value <= continuousValues[last].upperEnd)
                    {
                        continuousValues[last].count += 1;
                        valueAssigned = true;
                        break;
                    }
                }
            }


            richTextBox1.Text = "Distribution:" + "\n";
            for (int i = 0; i < continuousValues.Count; i++)
            {
                richTextBox1.Text += string.Format("Item {0} ( {1} - {2} ): {3} / {4}" + "\n", i, 
                    continuousValues[i].lowerEnd, continuousValues[i].upperEnd,
                    continuousValues[i].count, randomCount);
            }
        }
    }
}
