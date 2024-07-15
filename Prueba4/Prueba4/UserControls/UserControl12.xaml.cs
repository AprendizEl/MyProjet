using Prueba4.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl12.xaml
    /// </summary>
    public partial class UserControl12 : UserControl
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }



        public UserControl12()
        {
            InitializeComponent();

            KDA_TOTAL KDA_TOTAL = new KDA_TOTAL(0,4,10);
            KDA_TOTAL.KILLS = 0;
            KDA_TOTAL.ASSISTS = 4;
            KDA_TOTAL.DEATHS = 10;
            Partidas Partidas = new Partidas("SEE", 10, KDA_TOTAL, 7, "WIN");




            Text1 = Partidas.Vic_Der = "Victoria";
            Text2 = Partidas.Campeon = "Fiddlestick";
            Text3 = $"{Partidas.KDA.KILLS}/{Partidas.KDA.DEATHS}/{Partidas.KDA.ASSISTS}";

            DataContext = this;
        }


        private void cargart()
        {




        }

























    }
}
