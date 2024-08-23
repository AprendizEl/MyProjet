using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prueba4.Clases
{
    public class Summoner
    {
        private string _name;
        private int _level;
        private int _rank;

        public Summoner(string name, int level, int rank)
        {
            _name = name;
            _level = level;
            _rank = rank;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(); // Notifica el cambio de la propiedad
                }
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Rank
        {
            get { return _rank; }
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
