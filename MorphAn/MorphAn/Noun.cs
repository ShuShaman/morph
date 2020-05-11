using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    class Noun : Word, IPrintable
    {
        bool animated;
        bool plural;
        bool initialForm;
        string gend;//Gender gend;
        string nounCase;//Cases nounCase;
        string textWord;


        public Noun()
        {
            animated = false;
            plural = false;
            initialForm = false;
            gend = Word.genders.Last();
            nounCase = Word.cases.Last();
            textWord = "-";
        }

        public new string Print(int indexOfWord)
        {
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string infAboutWord = TextWord + " - " + "существительное, ";
            infAboutWord +=  animated == true? "одушевленное, " : "неодушевленное, ";
            infAboutWord += plural == true? "единственное, " : "множественное, ";
            infAboutWord += initialForm == true ? "начальная форма, " : "" ;
            infAboutWord += gend != Word.genders.Last() ? (gend + ", ") : " ";
            infAboutWord += nounCase != Word.cases.Last() ? nounCase : "";

            return infAboutWord;
        }

        public static List<Word> FillTheNounCharacteristics(List<Word> wordsInf, string textData, string wordFromText)
        {
            Noun noun = new Noun();
            noun.TextWord = wordFromText;
            textData.Replace("'", "").Replace(wordFromText, "");
            noun.Plural = Analyzer.SelectPlural(textData);
            noun.Gend = Analyzer.SelectGend(textData);
            noun.NounCase = Analyzer.SelectCase(textData);

            if (textData.Contains(Analyzer.GetCasesInDict(0)))//Если падеж именительный
            {
                noun.InitialForm = true;
            }
            if (textData.Contains("одуш"))// Если существительное одушевленное
            {
                noun.Animated = true;
            }

            wordsInf.Add(noun);

            return wordsInf;
        }

        public bool Animated
        {
            set
            {
                animated = value;
            }
            get { return animated; }
        }

        public bool Plural
        {
            set
            {
                plural = value;
            }
            get { return plural; }
        }

        public string Gend
        {
            set
            {
                gend = value;
            }
            get { return gend; }
        }

        public string NounCase
        {
            set
            {
                nounCase = value;
            }
            get { return nounCase; }
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
