using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Wpf;
using LiveCharts;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;
using Dynamitey;
using DocumentFormat.OpenXml.Office.CustomUI;


namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl7.xaml
    /// </summary>
    public partial class UserControl7 : UserControl
    {
        public SeriesCollection ChartBar { get; set; }
        public List<string> LaBar { get; set; }

        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;

                }
            }
        }

        public List<Grid> grids = new List<Grid>();

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
                Stroke = new SolidColorBrush(System.Windows.Media.Colors.Cyan),
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(90, 0, 173, 181))
            };

            // Agregar la serie a la colección
            SeriesCollection.Add(lineSeriesG);

            
            Labels = new List<string> { "1", "2", "3", "4", "5", "6", "7" };

            YFormatter = value => value.ToString("N");

            ImageSource = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\V6KSP6ZEUNGXBPZRBJTR25ZFIM.jpg";

            ChartBar = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Fiddlesticks",
                    Values = new ChartValues<double> { 9, 6, 2},
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(90, 0, 173, 181)),  
                }
            };

            LaBar = new List<string> { "A", "D", "K" };
            Gr_Imagen.DataContext = this;
            Grafic1.DataContext = this;
            Grafic2.DataContext = this;
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


            
            CreatePdf();

        }

        private void FontAwesome_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewPartida();
        }


        public void controltoimage(UIElement element)
        {
            string filePath = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\testing.jpg";
            RenderTargetBitmap rtb = new RenderTargetBitmap(
                (int)element.RenderSize.Width + 15,
                (int)element.RenderSize.Height + 15,
                96, 
                96,
                PixelFormats.Default
            );


               
            rtb.Render(element);

            TransformedBitmap transformedBitmap = new TransformedBitmap(
            rtb,
            new ScaleTransform(4,4)
            );

            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(transformedBitmap));
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                pngEncoder.Save(fs);
            }
        }

        public void CreatePdf()
        {
            string ruta = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\testing.pdf";

            using (var fileStream = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            {
               
                var document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document,fileStream);
                document.Open();
                PdfContentByte cb = writer.DirectContent;


                #region
                // Definir la posición y el tamaño del gráfico


                //int ngrids = grids.Count;

                //for (int i = 0; i < ngrids; i++)
                //{

                //    string filePath = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\testing.jpg";
                //    controltoimage(grids[i]);
                //    var image = iTextSharp.text.Image.GetInstance(filePath);


                //    image.ScaleToFit(300f, 400f);


                //    document.Add(image);

                //}
                #endregion

                List<Tuple<float,float>> puntos = new List<Tuple<float,float>>();
                var s = puntos[1].Item1;
                Tuple<float, float> e = Tuple.Create(float.Parse("2"), float.Parse("5"));
                puntos.Add(e);
        

                List<List<Tuple<float>>> LP = new List<List<Tuple<float>>>();


                float valre1 = 1;
                float valre2 = 1;
                int contadorl = 1;
                int contador = 1;

                for (int i = 0; i < LP.Count; i++)
                {
                    if (contador == 1)
                    {
                        valre1 = 1;
                    }
               
                    if (contador == 2)
                    {
                        valre1 = 6.3f;
                    }


                    if (contador == 3)
                    {
                        valre1 = 1;
                        contadorl++;
                        contador = 1;
                    }
                    if (contadorl == 2)
                    {
                        
                        valre2 = 1.65f;
                    }
                    if (contadorl == 3)
                    {
                        valre2 = 5f;
                    }
                    insert(cb, valre1, valre2, LP[i]);
                    contador++;
           
                    
                }



                document.Close();
               
            }
             grids.Clear();
        }


        private void insert(PdfContentByte cb , float valre1 , float valre2, List<Tuple<float>> datos )
        {
            var datosx = new List<float>();
            var datosy = new List<float>();

            datos.ForEach(d => datosx.Add(d.Item1));
            datos.ForEach(d => datosy.Add(d.Item1));



            //punto 0
            float chartX = 50 * valre1;
            float chartY = 620 / valre2;

            //Dimensiones del chart
            float chartWidth = 500 * 0.45f;
            float chartHeight = 300 * 0.5f;

            // Dibujar el eje X y el eje Y
            cb.MoveTo(chartX, chartY + chartHeight);
            cb.LineTo(chartX, chartY);
            cb.LineTo(chartX + chartWidth, chartY);


            // Dibujar el gráfico lineal
            float[] dataPoints = datosx.ToArray(); // Datos Y
            float[] dataPointsx = datosy.ToArray(); // Datos X

            float maxDataPointy = dataPoints.Max();
            float maxDataPointx = dataPointsx.Max();


            float stepX = chartWidth / maxDataPointx;//--| Separadares
            float stepY = chartHeight / maxDataPointy;//-| 

            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            string text1 = $"{dataPoints[0]}";

            //punto de partida
            cb.BeginText();
            cb.SetFontAndSize(font.BaseFont, font.Size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text1, chartX + 10 + dataPointsx[0] * stepX, chartY + 2 + dataPoints[0] * stepY, 0);
            cb.EndText();
            cb.MoveTo(chartX + dataPointsx[0] * stepX, chartY + dataPoints[0] * stepY);
            cb.Circle(chartX + dataPointsx[0] * stepX, chartY + dataPoints[0] * stepY, 3);

            //lineas que le siguen
            for (int i = 1; i < dataPoints.Length; i++)
            {
                float val = maxDataPointx;

                text1 = $"{dataPoints[i]}";
                cb.BeginText();
                cb.SetFontAndSize(font.BaseFont, font.Size);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text1, chartX + 10 + dataPointsx[i] * stepX, chartY + 2 + dataPoints[i] * stepY, 0);
                cb.EndText();
                cb.LineTo(chartX + dataPointsx[i] * stepX, chartY + dataPoints[i] * stepY);
            }

            cb.Stroke();

            // Circulos
            for (int i = 0; i < dataPoints.Length; i++)
            {
                cb.Circle(chartX + dataPointsx[i] * stepX, chartY + dataPoints[i] * stepY, 3);
                cb.Fill();
            }

            //Numero y
            for (int i = 0; i < 5; i++)
            {

                string ytext = (i * 1).ToString();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ytext, chartX - 15, chartY + (i * 1) * stepY, 0);
            }

            //Numero x
            //for (int i = 0; i < 10; i++)
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(font.BaseFont, font.Size);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{(i + 1) * 1}", chartX + 15 + i * 60 , chartY - 15, 0);
            //    cb.EndText();
            //}

            for (int i = 0; i < 7; i++)
            {
        
                string xtext = (i * 5).ToString();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, xtext, chartX + (i * 5) * stepX , chartY - 15, 0);
            }

            //for (int i = 1; i < dataPointsx.Length; i++)
            //{

            //    text1 = $"{dataPointsx[i]}";
            //    cb.BeginText();
            //    cb.SetFontAndSize(font.BaseFont, font.Size);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text1, chartX + dataPointsx[i] * stepX, chartY - 15, 0);

            //    cb.EndText();
            //}




            //con lista mucho coso
            //List<float> puntos = new List<float> { 150 ,400 ,760};

            //float max = puntos[0];

            //for(int  i = 1; i < puntos.Count; i++)
            //{
            //    if (puntos[i] > max)
            //    {
            //        max = puntos[i];
            //    }
            //}

            //float sepy = max / 800;

            //float sepx = puntos.Count / 500;


            ////0, 0 550 , 800

            ////Punto partida
            //cb.MoveTo(50, 800);

            ////linea que salen de alli
            //cb.LineTo(50, 500);
            //cb.LineTo(550, 500);
            //cb.Stroke();

            //cb.MoveTo(50, 500);


            //for(int i = 0;  i < puntos.Count; i++)
            //{
            //    cb.LineTo(i * sepx == 0 ? 500 : i * sepx, puntos[i]);
            //    cb.Stroke();
            //    cb.Circle(i * sepx == 0 ? 500 : i * sepx, puntos[i] + max / 800 , 3);
            //    cb.Fill();
            //}









        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Grid grid)
            {
                RecorrerGridsEnBorder(grid);     
            }
            if (sender is Border borde)
            {
                RecorrerGridsEnBorder(borde);
            }         
        }

        public void RecorrerGridsEnBorder(DependencyObject parent)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is Grid grid)
                {
                    if (grid.Name.StartsWith("Gr_"))
                    {
                        grids.Add(grid);
                    }
                }
                else if (child is Border border)
                {
                    RecorrerGridsEnBorder(border);
                }
                else
                {
                    RecorrerGridsEnBorder(child);
                }
            }
        }

    }
}

            