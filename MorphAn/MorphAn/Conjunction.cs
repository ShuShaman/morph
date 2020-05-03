using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{//Союз
    class Conjunction : Word
    {//не указан разряд и то, простой или составной союз, т к нет в разметке
        string textWord;

        public Conjunction()
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
