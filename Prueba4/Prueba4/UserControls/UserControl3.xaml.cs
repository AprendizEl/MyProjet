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
using DocumentFormat.OpenXml.Spreadsheet;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {

        public ObservableCollection<Escaleras> Items { get; set; } = new ObservableCollection<Escaleras>();


        public static List<Escaleras> Esca = new List<Escaleras>();
        //List<int> datos1 = new List<int>();
        //List<int> datos2 = new List<int>();
        //List<int> datos3 = new List<int>();
        int nitems;
        public UserControl3()
        {
            InitializeComponent();
            Dataso.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TB_1.Text) || string.IsNullOrEmpty(TB_2.Text) || string.IsNullOrEmpty(TB_3.Text))
                return;

            // Convertir los valores de los TextBoxes y añadir un nuevo elemento a la colección
            Escaleras esc = new Escaleras(int.Parse(TB_1.Text), TB_2.Text, TB_3.Text);
            Esca.Add(esc);



            Items.Add(esc);

            // Limpiar los TextBoxes después de añadir el elemento
            TB_1.Clear();
            TB_2.Clear();
            TB_3.Clear();

        }


    }
}
