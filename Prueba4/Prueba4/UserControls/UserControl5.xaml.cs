using LiveCharts.Wpf;
using LiveCharts;
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
using LiveCharts.Defaults;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl
    {
        List<int> listx = new List<int>();
        List<int> listy = new List<int>();
        List<Escaleras> obj = new List<Escaleras>();
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public UserControl5()
        {
            InitializeComponent();

            

            // Inicializar la colección de series
            SeriesCollection = new SeriesCollection();

            // Crear una nueva serie
            var lineSeriesG = new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<ObservablePoint>(),
                Stroke = new SolidColorBrush(Colors.Green), 
                Fill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 0))
            };

            //var lineSeriesR = new LineSeries
            //{
            //    Title = "Series 1",
            //    Values = new ChartValues<ObservablePoint>(),
            //    Stroke = new SolidColorBrush(Colors.Red),
            //    Fill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 0))
            //};


            SeriesCollection.Add(lineSeriesG);
            //SeriesCollection.Add(lineSeriesR);


            obj = UserControl3.Esca;
            int Nitem = obj.Count;
            relleo();
            for (int i = 0; i < Nitem; i++)
            {
                lineSeriesG.Values.Add(new ObservablePoint(listx[i], listy[i]));
            }
           

            // Establecer el contexto de datos
            DataContext = this;
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


    }
}

