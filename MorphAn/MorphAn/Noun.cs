using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    class Noun : Word
    {
        bool animated;
        bool plural;
        bool normalized;
        Genders gend;
        Cases nounCase;
        string textWord;



        public Noun()
        {
            animated = false;
            plural = false;
            normalized = true;
            gend = 0;
            nounCase = 0;
            textWord = "-";
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

        public Genders Gender
        {
            set
            {
                gend = value;
            }
            get { return gend ; }
        }

        public Cases NounCase
        {
            set
            {
                nounCase = value;
            }
            get { return nounCase; }
        }

        public bool Normalized
        {
            set
            {
                normalized = value;
            }
            get { return normalized; }
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
