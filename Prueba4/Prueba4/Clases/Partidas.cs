using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prueba4.Clases
{
    public class Game
    {

        private string champion;
        private int duration;
        private KDA_TOTAL kda;
        private int collection;
        private string vic_def;

        public string Champion
        {
            get { return champion; }
            set
            {
                if (champion != value)
                {
                    champion = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                if (duration != value)
                {
                    duration = value;
                    OnPropertyChanged();
                }
            }
        }

        public KDA_TOTAL KDA
        {
            get { return kda; }
            set
            {
                if (kda != value)
                {
                    kda = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Collection
        {
            get { return collection; }
            set
            {
                if (collection != value)
                {
                    collection = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Vic_Def
        {
            get { return vic_def; }
            set
            {
                if (vic_def != value)
                {
                    vic_def = value;
                    OnPropertyChanged();
                }
            }
        }



        public class BuildGame
        {
            public Game game = new Game();
           
            public BuildGame(string champ, int duration, int collection)
            {
                game.Champion = champ;
                game.Duration = duration;
                game.Collection = collection;
            }

            public BuildGame SetKDA(KDA_TOTAL kda)
            {
                game.KDA = kda;
                return this;
            }

            public BuildGame SetVictory(bool isVictory)
            {
                game.Vic_Def = isVictory ? "Victoria" : "Derrota";
                return this;
            }

            public Game Build()
            {
                return game;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
