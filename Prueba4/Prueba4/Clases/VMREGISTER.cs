using NPOI.SS.Formula.Functions;
using Prueba4.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace Prueba4
{
    public class VM_USER3
    {
        public static List<Game> games = new List<Game>();
        public static Game game { get; set; }
        public VM_USER3()
        {          
            
            var a = new Game.BuildGame("Campeon usuado", 0, 0)
                          .SetKDA(new KDA_TOTAL(0, 0, 0))
                          .Build();
            game = a;

            savepartidad = new Command<int>(guardar);

            //Game g = new Game("FIid", 30, kda1, 120, 1);
        } 
        
        public static void newgame()
        {
            game = new Game.BuildGame("Campeon usuado", 0, 0)
                           .SetKDA(new KDA_TOTAL(0, 0, 0))
                           .Build();
        }


        public static ICommand savepartidad { get; private set; }

     

        public static void guardar(int p)
        {

            games.Add(game);
            newgame();
            App.register.DataContext = null;
            App.register.DataContext = App.register.vm;



        }

        private static bool CanSave(object p)
        {
            return game != null;
        }



    }

}
