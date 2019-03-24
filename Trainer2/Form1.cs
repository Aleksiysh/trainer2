using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trainer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }



        static public String[] CreatLetter()
        {
            String[] letter = {
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
            
            return letter;
        }

        

        

        private void Form1_Load(object sender, EventArgs e)
        {
            Label[] lb = new Label[] {
                lb1,lb2,                                // Ш Б
                lb3,lb4,lb5,                            // М Н К
                lb6,lb7,lb8,lb9,                        // Ы М Б Ш
                lb10,lb11,lb12,lb13,lb14,               // Б Ы Н Л М
                lb14,lb16,lb17,lb18,lb19,               // И Н Ш М К 
                lb20,lb21,lb22,lb23,lb24,lb25,          // Н Ш Ы И К Б          v0.6
                lb26,lb27,lb28,lb29,lb30,lb31,          // Ш И Н Б К Ы          v0.7
                lb32,lb33,lb34,lb35,lb36,lb37,lb38,     // К Н Ш М Ы Б И        v0.8
                lb39,lb40,lb41,lb42,lb43,lb44,lb45,     // Б К Ш М И Ы Н        v0.9
                lb46,lb47,lb48,lb49,lb50,lb51,lb52,lb53  // Н К И Б М Ш Ы Б
            };
            var letter = CreatLetter();
            for (int i = 0; i < 53; i++)
            {
                lb[i].Text = letter[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Label[] lb = new Label[] {
                lb1,lb2,                                // Ш Б
                lb3,lb4,lb5,                            // М Н К
                lb6,lb7,lb8,lb9,                        // Ы М Б Ш
                lb10,lb11,lb12,lb13,lb14,               // Б Ы Н Л М
                lb14,lb16,lb17,lb18,lb19,               // И Н Ш М К 
                lb20,lb21,lb22,lb23,lb24,lb25,          // Н Ш Ы И К Б          v0.6
                lb26,lb27,lb28,lb29,lb30,lb31,          // Ш И Н Б К Ы          v0.7
                lb32,lb33,lb34,lb35,lb36,lb37,lb38,     // К Н Ш М Ы Б И        v0.8
                lb39,lb40,lb41,lb42,lb43,lb44,lb45,     // Б К Ш М И Ы Н        v0.9
                lb46,lb47,lb48,lb49,lb50,lb51,lb52,lb53  // Н К И Б М Ш Ы Б
            };
            for (int i = 0; i < 53; i++)
            {
                lb[i].Text = "X";
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lb7_Click(object sender, EventArgs e)
        {

        }

        private void lb8_Click(object sender, EventArgs e)
        {

        }

        private void lb9_Click(object sender, EventArgs e)
        {

        }
    }
   
}
