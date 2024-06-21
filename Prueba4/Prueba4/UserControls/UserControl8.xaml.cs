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

namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl8.xaml
    /// </summary>
    public partial class UserControl8 : UserControl
    {
        public Func<ChartPoint, string> PointLabel { get; set; }
        public ChartValues<double> Series1 { get; set; }
        public ChartValues<double> Series2 { get; set; }
        public UserControl8()
        {
            InitializeComponent();

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            Series1 = new ChartValues<double> { 3 };
            Series2 = new ChartValues<double> { 4 };

            DataContext = this;
        }

        

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}