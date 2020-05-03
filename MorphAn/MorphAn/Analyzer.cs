using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MorphAn
{
    class Analyzer
    {
        string text;
        List<string> words = new List<string>();

        public Analyzer(string firstText)
        {
            text = firstText;
        }

        public string Text
        {
            set
            {
                text = value;
            }
            get { return text; }
        }

        public List<string> Words
        {
            get { return words; }
        }

        public List<string> FindInDict()
        {
            string path = "dict.txt";
            string[] wordsFromText = text.Split(new char[] { ' ', ',', '.', ':', ';', '\n' });
            string str = "";

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                for (int j = 0; j < wordsFromText.Length; j++)
                {
                    while(!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        try
                        {
                            if (str.Contains(wordsFromText[j]))
                            {
                                wordsFromText[j] = str;
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }

                    }
                }

            }

            words.AddRange(wordsFromText);

            return words;
        }


    }
}