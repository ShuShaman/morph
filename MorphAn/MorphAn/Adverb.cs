using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{//наречие
    class Adverb:Word, IPrintable
    {
        string textWord;
        string rankOfAdv;
        string lexicalAndGramRank;//лексико-грамматический разряд

        public Adverb()
        {
            textWord = "-";
            rankOfAdv = Word.ranks.Last();
            lexicalAndGramRank = Word.lexicalAndGramRanks.Last();
        }

        public new string Print(int indexOfWord)
        {
            Word word = Analyzer.GetElemFromWordsInfList(indexOfWord);
            string infAboutWord = TextWord + " - " + "наречие, ";
            infAboutWord += rankOfAdv != Word.ranks.Last() ? (rankOfAdv + ", ") : "";
            infAboutWord += lexicalAndGramRank != Word.lexicalAndGramRanks.Last() ? lexicalAndGramRank : "";

            return infAboutWord;
        }

        public static List<Word> FillTheAdverbCharacteristics(List<Word> wordsInf, string textData, string wordFromText)
        {
            Adverb adv = new Adverb();
            adv.TextWord = wordFromText;
            adv.RankOfAdv = Analyzer.SelectRank(textData);
            adv.lexicalAndGramRank = Analyzer.SelectLexicalGramRank(textData);

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

        public string RankOfAdv
        {
            set
            {
                rankOfAdv = value;
            }
            get { return rankOfAdv; }
        }

        public string LexicalAndGramRank
        {
            set
            {
                lexicalAndGramRank = value;
            }
            get { return lexicalAndGramRank; }
        }

    }
}
