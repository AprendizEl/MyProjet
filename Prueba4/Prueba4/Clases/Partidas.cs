using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prueba4.Clases
{
    public class Partidas
    {

        private string campeon;
        private float duracion;
        private KDA_TOTAL kda;
        private int recoleccion;
        private string vic_Der;

        public string Campeon
        {
            get { return campeon; }
            set
            {
                if (campeon != value)
                {
                    campeon = value;
                    OnPropertyChanged();
                }
            }
        }

        public float Duracion
        {
            get { return duracion; }
            set
            {
                if (duracion != value)
                {
                    duracion = value;
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

        public int Recoleccion
        {
            get { return recoleccion; }
            set
            {
                if (recoleccion != value)
                {
                    recoleccion = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Vic_Der
        {
            get { return vic_Der; }
            set
            {
                if (vic_Der != value)
                {
                    vic_Der = value;
                    OnPropertyChanged();
                }
            }
        }

        public Partidas(string c, float d, KDA_TOTAL es, int s, string vd)
        {
            Campeon = c;
            Duracion = d;
            KDA = es;
            Recoleccion = s;
            Vic_Der = vd;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
