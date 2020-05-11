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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string text = textBox1.Text;
            bool hasLetters = false;
            hasLetters = FindLetters(text, hasLetters);
            if (hasLetters == true)
            {
                Word data = new Word();
                Analyzer textAn = new Analyzer(text);
                textAn.FindInDict();
                textAn.SelectPartOfSpeech();

                for (int i = 0; i < textAn.WordsInf.Count; i++)
                {
                    IPrintable word = Analyzer.GetElemFromWordsInfList(i);
                    textBox2.Text += word.Print(i) + "\r\n";
                }
            }
        }

        public TextBox getTextBox()
        {
            return textBox2;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Word data = new Word();
            string text = textBox1.Text;
            bool hasLetters = false;
            hasLetters = FindLetters(text, hasLetters);
            if (hasLetters == true)
            {
                Analyzer textAn = new Analyzer(text);
                textAn.FindInDict();
                textAn.SelectPartOfSpeech();
                string tempInf = "";

                for (int i = 0; i < textAn.WordsInf.Count; i++)
                {
                    textBox2.Text = "";
                    IPrintable word = Analyzer.GetElemFromWordsInfList(i);
                    tempInf += word.Print(i).Split(',').First() + "\r\n";
                }

                textBox2.Text += tempInf;
            }     
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Word data = new Word();
            string text = "";
            text = textBox1.Text;
            bool hasLetters = false;
            hasLetters = FindLetters(text, hasLetters);
            if (hasLetters == true)
            {
                Analyzer textAn = new Analyzer(text);
                textAn.FindInDict();
                textAn.SelectPartOfSpeech();
                string tempInf = "";


                for (int i = 0; i < textAn.WordsInf.Count; i++)
                {
                    textBox2.Text = "";
                    IPrintable word = Analyzer.GetElemFromWordsInfList(i);
                    if (word is Noun || word is Adjective || word is Pronoun || word is Numeral)
                    {
                        tempInf += word.Print(i).Split(',').First() + ", " + word.Print(i).Split(',').Last() + "\r\n";
                    }
                    else
                    {
                        tempInf += word.Print(i).Split(',').First() + ", не склоняется или нет данных\r\n";
                    }

                }

                textBox2.Text += tempInf;
            }
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private bool FindLetters(string text, bool hasLetters)
        {
            hasLetters = System.Text.RegularExpressions.Regex.IsMatch(text, @"\p{L}");
            if (!hasLetters)
            {
                MessageBox.Show("Введите слова");
            }

            return hasLetters;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            string helpText = "Данное приложение предназначено для \nморфологического анализа отдельных слов \nна русском языке.\n" +
                "Введите слова в верхнем textBox'е через \nзапятую, пробел или enter и \nвыберите нужное действие";
            helpForm.label1.Text = helpText;
            helpForm.Show();
        }
    }
}
