using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MorphAn
{
    class Word:IPrintable
    {
        string wordText;
        string partOfSpeech;
        public static List<string> genders;
        public static List<string> cases;
        public static List<string> tenses;
        public static List<string> moods;
        public static List<string> transitivity;
        public static List<string> persons;
        public static List<string> ranks;
        public static List<string> lexicalAndGramRanks;

        public Word()
        {
            genders = new List<string>();
            genders.AddRange(new string[] { "мужской", "женский", "средний", "нет данных" });

            cases = new List<string>();
            cases.AddRange(new string[] { "именительный", "родительный", "дательный", "винительный",
                                          "творительный", "предложный", "нет данных" });
            tenses = new List<string>();
            tenses.AddRange(new string[] { "прошлое", "настоящее", "будущее", "нет данных" });

            moods = new List<string>();
            moods.AddRange(new string[] { "изъявительное", "повелительное", "нет данных" });

            transitivity = new List<string>();
            transitivity.AddRange(new string[] { "переходный", "непереходный", "переходный/непереходный", "нет данных" });

            persons = new List<string>();
            persons.AddRange(new string[] {"первое лицо","второе лицо","третье лицо", "нет данных"});

            ranks = new List<string>();
            ranks.AddRange(new string[] {"места", "времени","причины","цели","способа действия","меры и степени", "качества", "нет данных" });

            lexicalAndGramRanks = new List<string>();
            lexicalAndGramRanks.AddRange(new string[] {"обстоятельственное","определительное","знаменательное","местоименное","нет данных" });

            wordText = "-";
            partOfSpeech = "нет данных";
        }

        public string Print(int indexOfWord)
        {
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string InfAboutWord = WordText + " - ";
            if (partOfSpeech!= Analyzer.partsOfSpeech.Last())
            {
                InfAboutWord += partOfSpeech;
            }
            else
            {
                InfAboutWord += "часть речи неизвестна";
            }

            return InfAboutWord;
        }


        public static List<Word> FillTheWordCharacteristics(List<Word> wordsInf, string textData, string wordFromText, PartsOfSpeech partOfSp)
        {
            Word word = new Word();
            word.WordText = wordFromText;
            textData.Replace("'", "").Replace(wordFromText, "");
            if (partOfSp == PartsOfSpeech.Conjunction)
            {
                word.PartOfSpeech = "союз";
            }
            else if (partOfSp == PartsOfSpeech.Predicative)
            {
                word.PartOfSpeech = "предикатив";
            }
            wordsInf.Add(word);

            return wordsInf;
        }

        public static string GetElemFromGendersList(int number)
        {
            return genders[number];
        }

        public static string GetElemFromCasesList(int number)
        {
            return cases[number];
        }

        public static string GetElemFromTensesList(int number)
        {
            return tenses[number];
        }

        public static string GetElemFromMoodsList(int number)
        {
            return moods[number];
        }

        public static string GetElemFromPersonsList(int number)
        {
            return persons[number];
        }

        public static string GetElemFromTransitivityList(int number)
        {
            return transitivity[number];
        }

        public static string GetElemFromRanksList(int number)
        {
            return ranks[number];
        }//lexicaAndGramRanks


        public static string GetElemFromLexAndGramRanksList(int number)
        {
            return lexicalAndGramRanks[number];
        }

        public string WordText
        {
            set
            {
                wordText = value;
            }
            get { return wordText; }
        }

        public string PartOfSpeech
        {
            set
            {
                partOfSpeech = value;
            }
            get { return partOfSpeech; }
        }
    }
}
