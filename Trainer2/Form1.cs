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

        static public Label[] lb;

        static int mode = 0;

        static int err, right;

        static int end = 53;

        static int begin = 0;

        static int element;

        struct StringOfTable
        {
            public int begin;
            public int amt;


            public StringOfTable(int f1, int f2)
            {
                begin = f1; amt = f2;
            }
        };

        static StringOfTable[] strTable =
        {
            new StringOfTable(0,2),
            new StringOfTable(2,3),
            new StringOfTable(5,4),
            new StringOfTable(9,5),
            new StringOfTable(14,5),
            new StringOfTable(19,6),
            new StringOfTable(25,6),
            new StringOfTable(31,7),
            new StringOfTable(38,7),
            new StringOfTable(45,8),
        };

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

        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            lb = CreatLabel();
            comboBox1.SelectedIndex = 9;
            Reset();
        }

        private void Run(int e)
        {
            if (letter[element] == key[e])
            {
                lb[element].BackColor = System.Drawing.Color.Green;
                right++;
            }
            else
            {
                lb[element].BackColor = System.Drawing.Color.Red;
                err++;
            }
            lb[element].Text = letter[element];

            if ((err + right) == end)
            {
                MessageBox.Show(String.Format("Верно {0} \n\nОшибок {1} ", right, err), "Сообщение", MessageBoxButtons.OK);
                Reset();
                return;
            }

            element = GetNextElement(mode);
            lb[element].BackColor = System.Drawing.Color.Gray;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (key.ContainsKey(e.KeyValue))
            {
                Run(e.KeyValue);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowMessage();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = 0;
            Reset();
            label11.Text = "Количество строк";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
            Reset();
            label11.Text = "Количество строк";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mode = 2;
            Reset();
            label11.Text = "Строка №";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            mode = 3;
            Reset();
            label11.Text = "Строка №";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            end = GetEnd();
            Reset();
            groupBox1.Focus();
        }

        private int GetNextElement(int mode)
        {
            switch (mode)
            {
                case 0:
                    element++;
                    break;

                case 1:
                    element = rnd.Next(begin, end);
                    while (lb[element].BackColor != System.Drawing.SystemColors.Control)
                        element = (element + 1) % end;
                    break;

                case 2:
                    element++;
                    break;

                case 3:
                    element =rnd.Next(begin, begin + end);
                    while (lb[element].BackColor != System.Drawing.SystemColors.Control)
                        element = rnd.Next(begin, begin + end);
                    break;
            }
            return element;
        }

        void Reset()
        {
            for (int i = 0; i < 53; i++)
                lb[i].BackColor = System.Drawing.SystemColors.Control;
            
            HideTable();

            err = 0; right = 0;

            switch (mode)
            {
                case 0:
                    begin = 0;
                    element = -1;
                    break;
                case 1:
                    begin = 0;
                    break;
                case 2:
                    begin = strTable[comboBox1.SelectedIndex].begin;
                    element = strTable[comboBox1.SelectedIndex].begin - 1;
                    break;
                case 3:
                    begin = strTable[comboBox1.SelectedIndex].begin;
                    break;
            }

            end = GetEnd();
            element = GetNextElement(mode);
            lb[element].BackColor = System.Drawing.Color.Gray;
        }

        void ShowMessage()
        {
            MessageBox.Show(String.Format("Букв {0} \n\nВерно {1} \n\nОшибок {2} ", right + err, right, err), "Сообщение", MessageBoxButtons.OK);
            HideTable();
            Reset();
        }

        void HideTable()
        {
            for (int i = 0; i < 53; i++)
                lb[i].Text = "X";
        }

        void ShowTable()
        {
            for (int i = 0; i < 53; i++)
                lb[i].Text = letter[i];
        }

        int GetEnd()
        {
            int end = 0;
            if (mode == 2 || mode == 3)
            {
                end = strTable[comboBox1.SelectedIndex].amt;
            }
            else
                for (int i = 0; i < comboBox1.SelectedIndex + 1; i++)
                {
                    end += strTable[i].amt;
                }
            return end;
        }
    }
}
