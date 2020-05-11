using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    class Numeral:Word, IPrintable
    {
        bool plural;
        bool initialForm;
        string gend;
        string numCase;
        string textWord;
        bool cardinal;//количественное числительное

        public Numeral()
        {
            plural = false;
            initialForm = false;
            cardinal = true;
            gend = Word.genders.Last();
            numCase = Word.cases.Last();
            textWord = "-";
        }

        public new string Print(int indexOfWord)
        {
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string infAboutWord = TextWord + " - " + "существительное, ";
            infAboutWord += cardinal == true ? "количественное, " : "порядковое, ";
            infAboutWord += plural == true ? "единственное, " : "множественное, ";
            infAboutWord += initialForm == true ? "начальная форма, " : "";
            infAboutWord += gend != Word.genders.Last() ? (gend + ", ") : "";
            infAboutWord += numCase != Word.cases.Last() ? numCase : "";

            return infAboutWord;
        }

        public static List<Word> FillTheNumCharacteristics(List<Word> wordsInf, string textData, string wordFromText)
        {
            Numeral num = new Numeral();
            num.TextWord = wordFromText;
            textData.Replace("'", "").Replace(wordFromText, "");
            num.Plural = Analyzer.SelectPlural(textData);
            num.Gender = Analyzer.SelectGend(textData);
            num.NumCase = Analyzer.SelectCase(textData);
            int indexForInitForm = 0;

            if (textData.Contains(Analyzer.GetCasesInDict(indexForInitForm)) && 
                textData.Contains(Analyzer.GetGendInDict(indexForInitForm)))//Если именительный падеж и мужской род
            {
                num.InitialForm = true;
            }
            if (textData.Contains("поряд"))
            {
                num.Cardinal = false;
            }

            wordsInf.Add(num);

            return wordsInf;
        }

        public bool Plural
        {
            set
            {
                plural = value;
            }
            get { return plural; }
        }

        public bool Cardinal
        {
            set
            {
                cardinal = value;
            }
            get { return cardinal; }
        }

        public string Gender
        {
            set
            {
                gend = value;
            }
            get { return gend; }
        }

        public string NumCase
        {
            set
            {
                numCase = value;
            }
            get { return numCase; }
        }

        public bool InitialForm
        {
            set
            {
                initialForm = value;
            }
            get { return initialForm; }
        }

        public string TextWord
        {
            set
            {
                textWord = value;
            }
            get { return textWord; }
        }
    }
}
