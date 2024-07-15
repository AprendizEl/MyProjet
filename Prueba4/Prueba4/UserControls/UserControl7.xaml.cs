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
using LiveCharts.Wpf;
using LiveCharts;
using Spire.Doc.Fields.Shapes.Charts;
using DocumentFormat.OpenXml.Drawing;

namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl7.xaml
    /// </summary>
    public partial class UserControl7 : UserControl
    {
        public SeriesCollection ChartBar { get; set; }
        public List<string> LaBar { get; set; }

        List<int> listx = new List<int>();
        List<int> listy = new List<int>();
        List<Escaleras> obj = new List<Escaleras>();
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public UserControl7()
        {
            InitializeComponent();



            // Inicializar la colección de series
            SeriesCollection = new SeriesCollection();

            // Crear una nueva serie con datos predefinidos
            var lineSeriesG = new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<double> { 1, 3, 2, 4, 5, 6, 7 },
                Stroke = new SolidColorBrush(Colors.Cyan),
                Fill = new SolidColorBrush(Color.FromArgb(90, 0, 173, 181))
            };

            // Agregar la serie a la colección
            SeriesCollection.Add(lineSeriesG);

            // Crear etiquetas para el eje X si es necesario
            Labels = new List<string> { "1", "2", "3", "4", "5", "6", "7" };

            // Establecer el formato del eje Y si es necesario
            YFormatter = value => value.ToString("N");

            // Establecer el contexto de datos


            ChartBar = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Fiddlesticks",
                    Values = new ChartValues<double> { 4, 6, 2},
                    Fill = new SolidColorBrush(Color.FromArgb(90, 0, 173, 181)),
  
 
                }
            };

            LaBar = new List<string> { "A", "D", "K" };

            Grafic1.DataContext = this;
            Grafic2.DataContext = this;
        }
    


        private void relleo()
        {
            int Nitem = obj.Count;

            for (int i = 0; i < Nitem; i++)
            {
                listx.Add(obj[i].ID);
                listy.Add(int.Parse(obj[i].name));

            }

        }

        private void NewPartida()
        {
            UserControl12 userControl12 = new UserControl12();

            ListBoxItem s = new ListBoxItem
            {
                Content = userControl12
            };

            LB_P.Items.Add(s);
            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewPartida();
        }
    }
}

            