using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    //Местоимение
    class Pronoun : Word
    {//не указаны разряд и лицо
        string textWord;
        Cases pronounCase;
        Genders pronounGender;
        bool plural;//является ли число множественным
        
        public Pronoun()
        {
            textWord = "-";
            pronounCase = Cases.NoData;
            pronounGender = Genders.NoData;
            plural = false;
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

        public Cases PronounCase
        {
            set
            {
                pronounCase = value;
            }
            get { return pronounCase; }
        }

        public Genders PronounGender
        {
            set
            {
                pronounGender = value;
            }
            get { return pronounGender; }
        }

    }
}
