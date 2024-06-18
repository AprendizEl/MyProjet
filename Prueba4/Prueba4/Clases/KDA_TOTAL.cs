using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba4
{
    public class KDA_TOTAL
    {
        public float KILLS {  get; set; }
        public float DEATHS { get; set; }
        public float ASSISTS { get; set; }

        public KDA_TOTAL(float k , float d, float a ) 
        {
            KILLS = k;
            DEATHS = d; 
            ASSISTS = a;
        
        
        
        }


    }
}
