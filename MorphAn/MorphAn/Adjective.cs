using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    class Adjective
    {
        bool plural;
        bool normalized;
        bool adjectiveFull;
        Genders gend;
        Cases nounCase;
        string textWord;

        public Adjective()
        {
            plural = false;
            normalized = true;
            gend = 0;
            nounCase = 0;
            adjectiveFull = true;
            textWord = "-";
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

        public Genders Gender
        {
            set
            {
                gend = value;
            }
            get { return gend; }
        }

        public Cases Case
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
