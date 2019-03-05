using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackStuff
{
    public partial class Form1 : Form
    {
        static char[] start = {'{', '[', '(', '<'};
        static char[] end = {'}', ']', ')', '>'};


        Queue<string> queue = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            ControleerString(InputBox.Text);
        }

        void ControleerString(string s)
        {
            label1.Text = "";
            var st = new Stack<char>();

            var regex = new Regex(@"([\[\]\{\}\(\)\<\>])");
            var y = true;

            foreach (var x in s)
            {
                label1.Text +=
                    $"\n {x}";

                var match = regex.Match($"{x}");
                if (!match.Success)
                    continue;

                if (start.Contains(x))
                {
                    st.Push(x);
                }
                else
                {
                    var i = Array.FindIndex(end, w => w == x);
                    var n = st.Pop();
                    label1.Text += $" {n == start[i]}";
                    if (n != start[i])
                        y = false;
                }
            }

            OuputLabel.Text = $"Resutlt {y}";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (queue.Length() == 0)
            {
                timer1.Stop();
                return;
            }


            var x = queue.Dequeue();
            UpdateList();
        }

        void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (var y in queue.GetList())
            {
                listBox1.Items.Add(y);
            }
        }

        private void AddRanThing_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Start();



            queue.Enqueue(RandString());
            UpdateList();
        }


        // Make the random words.
        private string RandString()
        {

            // Get the number of words and letters per word.
            int num_letters = 20;
            int num_words = 1;

            // Make an array of the letters we will use.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Make a random number generator.
            Random rand = new Random();


            // Make a word.
            string word = "";
            for (int j = 1; j <= num_letters; j++)
            {
                // Pick a random number between 0 and 25
                // to select a letter from the letters array.
                int letter_num = rand.Next(0, letters.Length - 1);

                // Append the letter.
                word += letters[letter_num];
            }

            return word;
        }

    }
}