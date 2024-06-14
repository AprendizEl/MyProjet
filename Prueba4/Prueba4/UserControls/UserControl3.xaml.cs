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

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public static List<Escaleras> Esca = new List<Escaleras>();
        List<int> datos1 = new List<int>();
        List<int> datos2 = new List<int>();
        List<int> datos3 = new List<int>();
        int nitems;
        public UserControl3()
        {
            InitializeComponent();
            List<int> datos1 = new List<int> { 1 , 1};
            List<int> datos2 = new List<int> { 1, 1 };
            List<int> datos3 = new List<int> { 1, 1 };



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Escaleras esc = new Escaleras(int.Parse(TB_1.Text), TB_2.Text.ToString(), TB_3.Text.ToString());
            Esca.Add(esc);

            nitems = Esca.Count;

            for (int i = 0; i < nitems; i++)
            {
                datos1.Add(Esca[i].ID);
                datos2.Add(int.Parse(Esca[i].tipo));
                datos3.Add(int.Parse(Esca[i].name));
            }
            







            MainWindow.Esca.AddRange(Esca);



            DataContext = this;
        }


    }
}
