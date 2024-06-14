using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public static List<Escaleras> Esca = new List<Escaleras>();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWidth = e.NewSize.Width;

            if (newWidth > 1000)
            {
                Ccambiar.Width = new GridLength(0.2, GridUnitType.Star);
                item1.FontSize = 20;
                item2.FontSize = 15;
                item3.FontSize = 15;
                item4.FontSize = 15;
                item5.FontSize = 15;
                item6.FontSize = 15;
                item7.Margin = new Thickness(30, 83, 30, 0);
            }
            if (newWidth < 1000)
            {
                Ccambiar.Width = new GridLength(0.2, GridUnitType.Star);
                item1.FontSize = 17;
                item2.FontSize = 13;
                item3.FontSize = 13;
                item4.FontSize = 13;
                item5.FontSize = 13;
                item6.FontSize = 13;
                item7.Margin = new Thickness(20);
            }


        }

        private void item4_Click(object sender, RoutedEventArgs e)
        {
            item7.Children.Clear();
            item7.Children.Add(new UserControl3());
        }

        private void item3_Click(object sender, RoutedEventArgs e)
        {
            item7.Children.Clear();
            item7.Children.Add(new UserControl4());

            
        }

        private void item5_Click(object sender, RoutedEventArgs e)
        {
            item7.Children.Clear();
            item7.Children.Add(new UserControl5());

        }
    }

}
//private void Button_Click(object sender, RoutedEventArgs e)
//        {
//          Window1 w = new Window1();w.Show();

//        }
//    }
//}
