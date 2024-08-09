using Prueba4.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
//using DocumentFormat.OpenXml.Spreadsheet;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {

        public ObservableCollection<Escaleras> Items { get; set; } = new ObservableCollection<Escaleras>();
        public static Partidas Partidas;

        public static List<Escaleras> Esca = new List<Escaleras>();
        //List<int> datos1 = new List<int>();
        //List<int> datos2 = new List<int>();
        //List<int> datos3 = new List<int>();

        public UserControl3()
        {
            InitializeComponent();
            var kda = new KDA_TOTAL(1,1,1);
            var s = new Partidas("BRRRRR", 0,kda,0,"");
            Partidas = s;
            DataContext = Partidas;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"SS{Partidas.Campeon}");
   

        }


    }
}
