using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba4.Clases
{
    internal class Partidas
    {

        public string Campeon { get; set; }
        public float Duracion { get; set; }

        public KDA_TOTAL KDA { get; set; }

        public int Recoleccion { get; set; }

        public string Vic_Der { get; set; }

        public Partidas( string c, float d, KDA_TOTAL es, int s, string vd )
        {
            Campeon = c;
            Duracion = d;
            KDA = es;
            Recoleccion = s;
            Vic_Der = vd;
        }





















    }


}
