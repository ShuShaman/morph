using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{//наречие
    class Adverb
    {
        string textWord;

        public Adverb()
        {
            textWord = "-";
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
