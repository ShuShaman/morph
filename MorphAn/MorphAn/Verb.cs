using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{

    class Verb : Word, IPrintable
    {
        bool plural; //число
        bool infinitive; //начальная форма 
        string gend; //род
        string person;//лицо
        string mood;//наклонение
        string tran;//переходность
        bool perfectForm;
        string textWord;
        
        public Verb()
        {
            plural = false;
            infinitive = true;
            gend = Word.genders.Last();
            person = Word.persons.Last();
            mood = Word.moods.Last();
            tran = Word.transitivity.Last();
            perfectForm = false;
            textWord = "-";
        }

        public new string Print(int indexOfWord)
        {
            string personOfVerb = person + "лицо";
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string infAboutWord = TextWord + " - " + "прилагательное, ";
            infAboutWord += person != Word.persons.Last() ? personOfVerb : "";
            infAboutWord += plural == true ? "единственное ч., " : "множественное ч., ";
            infAboutWord += infinitive == true ? "начальная форма, " : "";
            infAboutWord += mood != Word.moods.Last() ? (mood + ", ") : "";
            infAboutWord += gend != Word.genders.Last() ? gend : "";
            infAboutWord += perfectForm == true ? "совершенный вид, " : "несовершенный вид, ";

            return infAboutWord;
        }

        public static List<Word> FillTheVerbCharacteristics(List<Word> wordsInf, string textData, string wordFromText)
        {
            Verb verb = new Verb();
            verb.TextWord = wordFromText;
            textData.Replace("'", "").Replace(wordFromText, "");
            verb.Gender = Analyzer.SelectGend(textData);
            verb.Plural = Analyzer.SelectPlural(textData);
            wordsInf.Add(verb);

            if (textData.Contains("инф"))
            {
                verb.Infinitive = true;
            }
            if (textData.Contains("сов"))
            {
                verb.PerfectForm = true;
            }

            verb.Person = Analyzer.SelectPerson(textData);
            verb.Mood = Analyzer.SelectMood(verb, textData);
            verb.Tran = Analyzer.SelectTransitivity(textData);

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

        public bool PerfectForm
        {
            set
            {
                perfectForm = value;
            }
            get { return perfectForm; }
        }

        public string Gender
        {
            set
            {
                gend = value;
            }
            get { return gend; }
        }

        public string Person
        {
            set
            {
                person = value;
            }
            get { return person; }
        }

        public string Mood
        {
            set
            {
                mood = value;
            }
            get { return mood; }
        }

        public string Tran
        {
            set
            {
                tran = value;
            }
            get { return tran; }
        }

        public bool Infinitive
        {
            set
            {
                infinitive = value;
            }
            get { return infinitive; }
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
