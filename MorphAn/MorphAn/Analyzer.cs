using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace MorphAn
{
    enum PartsOfSpeech
    {
        Noun,
        Adjective,
        Numeral,
        Verb,
        Adverb,
        Pronoun,
        Conjunction,
        Predicative,
        NoData
    }

    class Analyzer
    {
        string text;
        List<string> words;
        public static List<string> partsOfSpeech;
        List<string> wordsFromText;
        static List<Word> wordsInf;
        static string[] gendersInDict = new string[3] { "муж", "жен", "ср" };
        static string[] casesInDict = new string[6] { "им", "род", "дат", "вин", "тв", "пр" };
        static string[] personsInDict = new string[3] { "1-е", "2-е", "3-е" };
        static string[] moodsInDict = new string[3] { "изъяв", "пов", "сосл" };
        static string[] tranInDict = new string[3] { "пер", "непер", "пер/не" };
        static string[] ranksInDict = new string[7] { "мест", "врем", "прич", "цел", "спос", "степ", "кач" };
        static string[] lexGramRanksInDict = new string[4] {"опред","обст","знам","мест" };

        public Analyzer(string firstText)
        {
            text = firstText;
            wordsFromText = new List<string>();
            words = new List<string>();
            partsOfSpeech = new List<string>();
            wordsInf = new List<Word>();
            partsOfSpeech.AddRange(new string[] {"сущ", "прил", "числ", "гл", "нар", "мест", "союз","предик", "нет данных"});
        }

        public static string GetCasesInDict(int indexOfElem)
        {
            return casesInDict[indexOfElem];
        }

        public static string GetGendInDict(int indexOfElem)
        {
            return gendersInDict[indexOfElem];
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

        public List<Word> WordsInf
        {
            get { return wordsInf; }
        }

        public List<string> FindInDict()
        {
            wordsInf.Clear();
            wordsInf.Capacity = 0;
            wordsFromText.Clear();
            wordsFromText.Capacity = 0;
            string path = "dict.txt";
            wordsFromText.AddRange(text.Split(new char[] { ' ', ',', '.', ':', ';', '\n', '\r' }));
            wordsFromText.RemoveAll(x => x == "");
            bool found = false;
            string str = "";
            for (int j = 0; j < wordsFromText.Count; j++)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {

                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        try
                        {
                            if (str.Contains(wordsFromText[j]))
                            {
                                words.Add(str);
                                found = true;
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }
                    if (found == false)
                    {
                        words.Add(wordsFromText[j]);
                    }

                }
            }

            return words;
        }

        public List<Word> SelectPartOfSpeech()
        {
            string wordInf = "";

            for (int i = 0; i < words.Count; i++)//цикл по элементам-строкам words
            {
                wordInf = words[i];

                for (int j = 0; j < partsOfSpeech.Count; j++)//цикл по частям речи (поиск)
                {
                    if (wordInf.Contains(partsOfSpeech[j]))
                    {
                        PartsOfSpeech part = (PartsOfSpeech)j;
                        switch (part)
                        {
                            case PartsOfSpeech.Noun:
                                Noun.FillTheNounCharacteristics(wordsInf, words[i], wordsFromText[i]);
                                break;
                            case PartsOfSpeech.Adjective:
                                Adjective.FillTheAdjCharacteristics(wordsInf, words[i], wordsFromText[i]);
                                break;
                            case PartsOfSpeech.Numeral:
                                Numeral.FillTheNumCharacteristics(wordsInf, words[i], wordsFromText[i]);
                                break;
                            case PartsOfSpeech.Verb:
                                Verb.FillTheVerbCharacteristics(wordsInf, words[i], wordsFromText[i]);
                                break;
                            case PartsOfSpeech.Adverb:
                                Adverb.FillTheAdverbCharacteristics(wordsInf, words[i], wordsFromText[i]);
                                break;
                            case PartsOfSpeech.Pronoun:
                                Pronoun.FillThePronCharacteristics(wordsInf, words[i], wordsFromText[i]);
                                break;
                            case PartsOfSpeech.Conjunction:
                                Word.FillTheWordCharacteristics(wordsInf, words[i], wordsFromText[i], PartsOfSpeech.Conjunction);
                                break;
                            case PartsOfSpeech.Predicative:
                                Word.FillTheWordCharacteristics(wordsInf, words[i], wordsFromText[i], PartsOfSpeech.Predicative);
                                break;
                        }
                        break;
                    }
                    else if (j == partsOfSpeech.Count - 1)
                    {
                        Word.FillTheWordCharacteristics(wordsInf, words[i], wordsFromText[i], PartsOfSpeech.NoData);
                    }

                }
            }

            return wordsInf;
        }

        public static string SelectRank(string textData)
        {
            int indexOfrank = Word.ranks.IndexOf("нет данных");

            for (int i = 0; i < ranksInDict.Length; i++)
            {
                if (textData.Contains(ranksInDict[i]))
                {
                    indexOfrank = i;
                }
            }

            return Word.GetElemFromTransitivityList(indexOfrank);
        }

        public static string SelectLexicalGramRank(string textData)
        {
            int indexOfLexrank = Word.lexicalAndGramRanks.IndexOf("нет данных");

            for (int i = 0; i < lexGramRanksInDict.Length; i++)
            {
                if (textData.Contains(lexGramRanksInDict[i]))
                {
                    indexOfLexrank = i;
                }
            }

            return Word.GetElemFromLexAndGramRanksList(indexOfLexrank);
        }

        public static string SelectMood(Verb verb, string textData)
        {
            int indexOfmood = Word.moods.IndexOf("нет данных");

            if (textData.Contains(moodsInDict[1]))//повелительное наклонение
            {
                indexOfmood = 1;
            }
            else if(verb.Infinitive == false)
            {
                indexOfmood = 0;//изъявительное наклонение
            }

            return Word.GetElemFromMoodsList(indexOfmood);
        }

        public static string SelectTransitivity(string textData)
        {
            int indexOftran = Word.transitivity.IndexOf("нет данных");

            for (int i = 0; i < tranInDict.Length; i++)
            {
                if (textData.Contains(tranInDict[i]))
                {
                    indexOftran = i;
                }
            }

            return Word.GetElemFromTransitivityList(indexOftran);
        }

        public static string SelectPerson(string textData)
        {
            int indexOfperson = Word.persons.IndexOf("нет данных");

            for (int i = 0; i < personsInDict.Length; i++)
            {
                if (textData.Contains(personsInDict[i]))
                {
                    indexOfperson = i;
                }
            }

            return Word.GetElemFromPersonsList(indexOfperson);
        }

        public static bool SelectPlural(string textData)
        {
            bool plural = false;

            if (textData.Contains("множ"))
            {
                plural = true;
            }

            return plural;
        }

        public static string SelectGend(string textData)
        {
            int indexOfgend = Word.genders.IndexOf("нет данных");

            for(int i = 0; i<gendersInDict.Length; i++)
            {
                if (textData.Contains(gendersInDict[i]))
                {
                    indexOfgend = i;
                }
            }
            
            return Word.GetElemFromGendersList(indexOfgend);
        }

        public static string SelectCase(string textData)
        {
            int indexOfgend = Word.genders.IndexOf("нет данных");

            for (int i = 0; i < casesInDict.Length; i++)
            {
                if (textData.Contains(casesInDict[i]))
                {
                    indexOfgend = i;
                }
            }

            return Word.GetElemFromCasesList(indexOfgend);
        }

        public static Word GetElemFromWordsInfList(int number)
        {
            return wordsInf[number];
        }

        public static string GetElemFromPartsOfSpList(int number)
        {
            return partsOfSpeech[number];
        }

    }
}