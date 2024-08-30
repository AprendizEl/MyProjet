using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WPF;
using Microsoft.VisualBasic;
using Microsoft.Xaml.Behaviors;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheProject.Controls
{
    /// <summary>
    /// Lógica de interacción para GrC.xaml
    /// </summary>
    public partial class GrC : System.Windows.Controls.UserControl
    {
        public GrC()
        {
            InitializeComponent();

            // Datos de ejemplo para las series
            var lineSeries = new LineSeries<int>
            {
                Values = new List<int> { 4, 6, 9, 12, 7, 10 },
                Name = "Línea",
                Stroke = new SolidColorPaint(SKColors.Blue),
                Fill = new SolidColorPaint(SKColors.Transparent),

            };

            var columnSeries = new ColumnSeries<int>
            {
                Values = new List<int> { 5, 8, 12, 6, 7, 9 },
                Name = "Columnas",
                Fill = new SolidColorPaint(SKColors.Orange),
                Stroke = new SolidColorPaint(SKColors.Transparent),

            };


            // Configurar ejes
            var xAxis = new Axis
            {
                Name = "Eje X",
                Labels = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun" },
                Labeler = value => value.ToString(),
            };

            var yAxis = new Axis
            {
                Name = "Eje Y",
                Labeler = value => value.ToString(),

            };

            // Configurar el gráfico
            chart.XAxes = new Axis[] { xAxis };
            chart.YAxes = new Axis[] { yAxis };

            // Agregar una anotación de línea vertical (si LineAnnotation está disponible, usa otra clase si no está)

         
        }
    }
}