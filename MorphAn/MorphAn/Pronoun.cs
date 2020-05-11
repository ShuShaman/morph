using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    //Местоимение
    class Pronoun : Word
    {
        string textWord;
        string pronounCase;
        string pronounGender;
        bool plural;//является ли число множественным
        
        public Pronoun()
        {
            textWord = "-";
            pronounCase = Word.cases.Last();
            pronounGender = Word.genders.Last();
            plural = false;
        }

        public new string Print(int indexOfWord)
        {
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string infAboutWord = TextWord + " - " + "существительное, ";
            infAboutWord += plural == true ? "единственное, " : "множественное, ";
            infAboutWord += pronounGender != Word.genders.Last() ? (pronounGender + ", " ): "";
            infAboutWord += pronounCase != Word.cases.Last() ? pronounCase : "";

            return infAboutWord;
        }

        public static List<Word> FillThePronCharacteristics(List<Word> wordsInf, string textData, string wordFromText)
        {
            Pronoun pron = new Pronoun();
            pron.TextWord = wordFromText;
            textData.Replace("'", "").Replace(wordFromText, "");
            pron.Plural = Analyzer.SelectPlural(textData);
            pron.PronounGender = Analyzer.SelectGend(textData);
            pron.PronounCase = Analyzer.SelectCase(textData);
            wordsInf.Add(pron);

            return wordsInf;
        }

        public string TextWord
        {
            set
            {
                textWord = value;
            }
            get { return textWord; }
        }

        public bool Plural
        {
            set
            {
                plural = value;
            }
            get { return plural; }
        }

        public string PronounCase
        {
            set
            {
                pronounCase = value;
            }
            get { return pronounCase; }
        }

        public string PronounGender
        {
            set
            {
                pronounGender = value;
            }
            get { return pronounGender; }
        }

    }
}
