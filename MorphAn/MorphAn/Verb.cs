using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphAn
{
    //первое, второе, третье лицо
    enum Persons
    {
        FirstPer,
        SecondPer,
        ThirdPer,
        NoData
    }

    //времена
    enum Tenses
    {
        NoData,
        Past,
        Present,
        Future
    }

    enum Moods
    {
        NoData,
        Indicative,//изъявительное наклонение
        Imperative//повелительное наклонение
    }

    //Переходность
    enum Transitivity
    {
        Transitive,//переходный
        Intransitive,//непереходный гл-л
        TranOrIntr
    }

    class Verb : Word
    {// не указаны спряжение и возвратность
        bool plural; //число
        bool infinitive; //начальная форма 
        Genders gend; //род
        Persons per;//лицо
        Moods mood;//наклонение
        Transitivity tran;
        bool perfectForm;
        string textWord;
        
        public Verb()
        {
            plural = false;
            infinitive = true;
            gend = Genders.NoData;
            per = Persons.NoData;
            mood = Moods.NoData;
            tran = Transitivity.TranOrIntr;
            perfectForm = false;
            textWord = "-";
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

        public Genders Gender
        {
            set
            {
                gend = value;
            }
            get { return gend; }
        }

        public Persons Per
        {
            set
            {
                per = value;
            }
            get { return per; }
        }

        public Moods Mood
        {
            set
            {
                mood = value;
            }
            get { return mood; }
        }

        public Transitivity Tran
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
