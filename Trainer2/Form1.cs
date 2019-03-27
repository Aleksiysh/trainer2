using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Trainer2
{
    public partial class Form1 : Form
    {
        static String[] letter = {
                "Ш","Б",                            //  v0.1
                "М","Н","К",                        //  v0.2
                "Ы","М","Б","Ш",                    //  v0.3
                "Б","Ы","Н","К","М",                //  v0.4
                "И","Н","Ш","М","К",                //  v0.5
                "Н","Ш","Ы","И","К","Б",            //  v0.6
                "Ш","И","Н","Б","К","Ы",            //  v0.7
                "К","Н","Ш","М","Ы","Б","И",        //  v0.8
                "Б","К","Ш","М","И","Ы","Н",        //  v0.9
                "Н","К","И","Б","М","Ш","Ы","Б"     //  v1.0
            };

        static Dictionary<int, string> key = new Dictionary<int, string>
            {
                        {73,"Ш" },
                        {188,"Б"},
                        {86,"М" },
                        {89,"Н" },
                        {82, "К" },
                        {83,"Ы" },
                        {66,"И" }
                    };

        static Label[] lb;

        static int mode = 0;

        static int element;

        static int[] res = new int[53];

        public Form1()
        {
            InitializeComponent();

        }

        public Label[] CreatLabel()
        {
            return new Label[] {
                lb1,lb2,                                // Ш Б
                lb3,lb4,lb5,                            // М Н К
                lb6,lb7,lb8,lb9,                        // Ы М Б Ш
                lb10,lb11,lb12,lb13,lb14,               // Б Ы Н Л М
                lb15,lb16,lb17,lb18,lb19,               // И Н Ш М К 
                lb20,lb21,lb22,lb23,lb24,lb25,          // Н Ш Ы И К Б          v0.6
                lb26,lb27,lb28,lb29,lb30,lb31,          // Ш И Н Б К Ы          v0.7
                lb32,lb33,lb34,lb35,lb36,lb37,lb38,     // К Н Ш М Ы Б И        v0.8
                lb39,lb40,lb41,lb42,lb43,lb44,lb45,     // Б К Ш М И Ы Н        v0.9
                lb46,lb47,lb48,lb49,lb50,lb51,lb52,lb53 // Н К И Б М Ш Ы Б
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lb = CreatLabel();
            ResetRes();
            Run(0);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Label[] lb = CreatLabel();
            for (int i = 0; i < 53; i++)
                lb[i].Text = "X";
        }

        private void Run(int e)
        {
            //Random rnd = new Random();
            //var lb = CreatLabel();
            //int number = rnd.Next(0, 53); 


            //while (lb[number].BackColor != SystemColors.Control)
            //    number = (number + 1) % 52;

            if (letter[element] == key[e])
            {
                lb[element].BackColor = System.Drawing.Color.Green;
                res[element] = 1;
            }
            else
            {
                lb[element].BackColor = System.Drawing.Color.Red;
                res[element] = 2;
            }
            lb[element].Text = letter[element];

            element = GetNextElement(mode);
            lb[element].BackColor = System.Drawing.Color.Gray;
            //lb1.Text = letter[0];
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (key.ContainsKey(e.KeyValue))
            {

                Run(e.KeyValue);
                label11.Text = element.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 53; i++)
                lb[i].Text = letter[i];
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            mode = 0;
            ResetRes();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
            ResetRes();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mode = 2;
            ResetRes();
        }

        private int GetNextElement(int mode)
        {
            if (mode == 0)
                element++;

            if (element == 53)
            {
                ResetRes();
            }
            return element;


            //Random rnd = new Random();
            //return rnd.Next(0, 53); 
        }

        void ResetRes()
        {
            for (int i = 0; i < 53; i++)
            {
                res[i] = 0;
                lb[i].BackColor = System.Drawing.SystemColors.Control;
            }
            element = 0;
        }
        
    }
}
