﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    class Adjective:Word, IPrintable
    {
        bool plural;
        bool initialForm;
        bool adjectiveFull;
        string gend;//Gender gend;
        string adjCase;//Cases nounCase;
        string textWord;

        public Adjective()
        {
            plural = false;
            initialForm = true;
            gend = Word.genders.Last();
            adjCase = Word.cases.Last();
            adjectiveFull = true;
            textWord = "-";
        }

        public new string Print(int indexOfWord)
        {
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string infAboutWord = TextWord + " - " + "прилагательное, ";
            infAboutWord += plural == true ? "единственное, " : "множественное, ";
            infAboutWord += initialForm == true ? "начальная форма, " : "";
            infAboutWord += gend != Word.genders.Last() ? gend : "";
            infAboutWord += adjectiveFull == true ? "полная форма, " : "краткая форма, ";
            infAboutWord += adjCase != Word.cases.Last() ? adjCase : "";

            return infAboutWord;
        }

        public static List<Word> FillTheAdjCharacteristics(List<Word> wordsInf, string textData, string wordFromText)
        {
            Adjective adj = new Adjective();
            adj.TextWord = wordFromText;
            textData.Replace("'", "").Replace(wordFromText, "");
            adj.Plural = Analyzer.SelectPlural(textData);
            adj.Gender = Analyzer.SelectGend(textData);
            adj.AdjCase = Analyzer.SelectCase(textData);
            int indexForInitForm = 0;

            if (textData.Contains(Analyzer.GetCasesInDict(indexForInitForm)) && 
                textData.Contains(Analyzer.GetGendInDict(indexForInitForm)))//Если именительный падеж и мужской род
            {
                adj.InitialForm = true;
            }
            if (textData.Contains("крат"))//краткая форма прилагательного
            {
                adj.AdjectiveFull = false;
            }

            wordsInf.Add(adj);

            return wordsInf;
        }

        public bool AdjectiveFull
        {
            set
            {
                adjectiveFull = value;
            }
            get { return adjectiveFull; }
        }

        public bool Plural
        {
            set
            {
                plural = value;
            }
            get { return plural; }
        }

        public string Gender
        {
            set
            {
                gend = value;
            }
            get { return gend; }
        }

        public string AdjCase
        {
            set
            {
                adjCase = value;
            }
            get { return adjCase; }
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
