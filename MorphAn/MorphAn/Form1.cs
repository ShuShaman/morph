using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorphAn
{
    //Род
    enum Genders
    {
        NoData,
        Masculine,
        Feminine,
        Neuter
    }

    //Падежи
    enum Cases
    {
        NoData,
        Nominative,
        Genitive,
        Dative,
        Accusative,
        Instrumental,
        Prepositional
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            Analyzer textAn = new Analyzer(text);
            textAn.FindInDict();
            for (int i = 0; i < textAn.Words.Count; i++)
            {
                textBox2.Text += textAn.Words[i].ToString() + "\r\n";
            }

        }
    }
}
