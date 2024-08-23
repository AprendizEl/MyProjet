using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para UserControl13.xaml
    /// </summary>
    public partial class UserControl13 : UserControl
    {
        List<List<Tuple<float,float>>> LP = new List<List<Tuple<float, float>>>();
        List<Tuple<float, float>> puntos = new List<Tuple<float, float>>();
        public UserControl13()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender == BT_Cancelar)
            {
               
            }
            else if( sender == BT_Guardar)
            {
                LP.Add(puntos);
            }
            else if(sender == BT_Documentar)
            {
                CreatePdf();
            }
            else
            {
                var cord = Tuple.Create(float.Parse(C_x.Text), float.Parse(C_y.Text));
                puntos.Add(cord);

            }



        }


        public void CreatePdf()
        {
            string ruta = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\testing.pdf";

            using (var fileStream = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            {

                var document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
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

              
                var s = puntos[1].Item1;
                Tuple<float, float> e = Tuple.Create(float.Parse("2"), float.Parse("5"));
                puntos.Add(e);




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

        }


        private void insert(PdfContentByte cb, float valre1, float valre2, List<Tuple<float, float>> datos)
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

            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 8);
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
            };

            // Circulos
            for (int i = 0; i < dataPoints.Length; i++)
            {
                cb.Circle(chartX + dataPointsx[i] * stepX, chartY + dataPoints[i] * stepY, 2);
                cb.Fill();
            }

            //Numero y
            for (int i = 0; i < 5; i++)
            {

                string ytext = (i * 1).ToString();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ytext, chartX - 15, chartY + (i * 1) * stepY, 0);
            }

            //Numero x
            for (int i = 0; i < 7; i++)
            {

                string xtext = (i * 5).ToString();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, xtext, chartX + (i * 5) * stepX, chartY - 15, 0);
            }            
        }
    }
}
