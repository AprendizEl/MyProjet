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
using System.Windows.Shapes;
using NPOI.SS.Formula.Functions;
using DocumentFormat.OpenXml.Bibliography;


namespace Prueba4.Windows
{
    /// <summary>
    /// Lógica de interacción para Window3.xaml
    /// </summary>
    /// 
    public partial class Window3 : System.Windows.Window
    {
        List<List<System.Windows.Point>> LP = new List<List<System.Windows.Point>>();
        List<System.Windows.Point> puntos = new List<System.Windows.Point>();
        bool stepx = true;
        public Window3()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == BT_Cancelar)
            {
                Close();
            }
            else if (sender == BT_Guardar)
            {
                if(puntos.Count > 0 & puntos != null)
                {
                    LP.Add(new List<System.Windows.Point>(puntos));
                    puntos.Clear();
    
                }
                else
                {
                    MessageBox.Show("MAL");
                }


            }
            else if (sender == BT_Documentar)
            {
               CreatePdf();
            }
            else if (sender == BT_Borrar)
            {
                LP.Clear();
            }
            else
            {
                if (C_x.Text != "" & C_y.Text != "")
                {

                    var cord = new System.Windows.Point(Double.Parse(C_x.Text), Double.Parse(C_y.Text));
                    puntos.Add(cord);
                    C_x.Text = "";
                    C_y.Text = "";
                }
                else
                {
                    MessageBox.Show("MAL");
                }


            }


            var punto = new System.Windows.Point(8, 5);
        }

        private static void EncabezadoPlantilla(PdfWriter writer)
        {
            //Plantilla de encabezados 
            string plantilla = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\PlantillaMemorias.pdf";
            PdfReader ReadPlantilla = new PdfReader(plantilla);
            PdfContentByte content = writer.DirectContent;

            PdfImportedPage importedPage = writer.GetImportedPage(ReadPlantilla, 1);
            content.AddTemplate(importedPage, 0, 0);          

        }

        public void CreatePdf()
        {
            string ruta = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\testing.pdf";

            using (var fileStream = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            {

                var document = new iTextSharp.text.Document(PageSize.A4);
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

                InsertallChart(cb, document);

                document.Close();

            }

        }

        private void InsertallChart(PdfContentByte cb, iTextSharp.text.Document document)
        {
            int contgrafic = 0;
            float valre2 = 1;
            int contador = 1;

            for (int t = 0; t < LP.Count; t++)
            {

                if (contador == 1)
                {
                    valre2 = 1;
                }

                if (contador == 2)
                {

                    valre2 = 6f;       
                }

                insertChart(cb, valre2, LP[t]);
                contador++;
                contgrafic++;
                if (contgrafic == 2)
                {
                    document.NewPage();
                    contgrafic = 0;
                    valre2 = 1;
                    contador = 1;
                }

            }
        }

        private void insertChart(PdfContentByte cb, float valre2, List<System.Windows.Point> datos)
        {
            //para determinar la posición 
            var py = 0f;
            var px = 0f;

            //para calcular
            var calx = 0f;
            var caly = 0f;
            
            //texto
            string textx;
            string texty;

            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 8);

            #region back up

            //var datosx = new List<float>();
            //var datosy = new List<float>();

            //datos.ForEach(d => datosx.Add((float)d.X));
            //datos.ForEach(d => datosy.Add((float)d.Y));


            ////punto 0
            //float chartX = 40 * valre1;
            //float chartY = 620 / valre2;

            ////Dimensiones del chart
            //float chartWidth = 500 * 0.45f;
            //float chartHeight = 300 * 0.5f;

            //// Dibujar el eje X y el eje Y
            //cb.MoveTo(chartX, chartY + chartHeight);
            //cb.LineTo(chartX, chartY);
            //cb.LineTo(chartX + chartWidth, chartY);


            //float[] dataPoints = datosy.ToArray(); // Datos Y
            //float[] dataPointsx = datosx.ToArray(); // Datos X

            //if (dataPoints.Min().ToString().StartsWith("-"))
            //{
            //    chartY = chartY + dataPoints.Min() * -1;

            //}

            //if (dataPointsx.Min().ToString().StartsWith("-"))
            //{
            //    chartX = chartX + dataPointsx.Min() * -1;
            //}


            //float maxDataPointy = dataPoints.Max();
            //float maxDataPointx = dataPointsx.Max();


            //float stepX = chartWidth / maxDataPointx;//--| Separadares para escalar
            //float stepY = chartHeight / maxDataPointy;//-| 

            //iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 8);
            //string text1 = $"{dataPoints[0]}";

            //cb.BeginText();
            //cb.SetFontAndSize(font.BaseFont, font.Size);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", chartX - 7, chartY - 7, 0);
            //cb.EndText();


            ////punto de partida
            //cb.BeginText();
            //cb.SetFontAndSize(font.BaseFont, font.Size);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text1, chartX + 10 + dataPointsx[0] * stepX, chartY + dataPoints[0] * stepY, 0);
            //cb.EndText();
            //cb.MoveTo(chartX + dataPointsx[0] * stepX, chartY + dataPoints[0] * stepY);
            //cb.Circle(chartX + dataPointsx[0] * stepX, chartY + dataPoints[0] * stepY, 3);


            ////lineas que le siguen
            //for (int i = 1; i < dataPoints.Length; i++)
            //{
            //    //Texto que se coloca arriba, modificar al gusto
            //    text1 = $"{dataPoints[i]}";
            //    cb.BeginText();
            //    cb.SetFontAndSize(font.BaseFont, font.Size);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text1, chartX + 10 + dataPointsx[i] * stepX, chartY + dataPoints[i] * stepY, 0);
            //    cb.EndText();


            //    cb.LineTo(chartX + dataPointsx[i] * stepX, chartY + dataPoints[i] * stepY);
            //}

            //cb.Stroke();
            //// Circulos
            //for (int i = 0; i < dataPoints.Length; i++)
            //{
            //    cb.Circle(chartX + dataPointsx[i] * stepX, chartY + dataPoints[i] * stepY, 2);
            //    cb.Fill();
            //}


            ////lista para los numeros de los ejes
            //List<float> dtss = new List<float>();

            //dtss.Add((float)Math.Round(dataPoints.Max()));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.90f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.80f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.70f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.60f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.50f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.40f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.30f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.20f));
            //dtss.Add((float)Math.Round(dataPoints.Max() * 0.10f));
            //dtss.Add((float)Math.Round(dataPoints.Min()));



            //List<float> dtss2 = new List<float>();

            //dtss2.Add((float)Math.Round(dataPointsx.Max()));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.90f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.70f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.60f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.40f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.30f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.20f));
            //dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.10f));
            //dtss2.Add((float)Math.Round(dataPointsx.Min()));



            //float[] texteny = dtss.ToArray();
            //float[] textenx = dtss2.ToArray();

            //iTextSharp.text.Font font2 = FontFactory.GetFont(FontFactory.HELVETICA, 8);

            ////Numero y
            //for (int i = 0; i < texteny.Length; i++)
            //{

            //    string ytext = texteny[i].ToString() == "0" ? "" : texteny[i].ToString();
            //    cb.BeginText();
            //    cb.SetFontAndSize(font2.BaseFont, font2.Size);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ytext, chartX - 15, chartY + texteny[i] * stepY, 0);
            //    cb.EndText();
            //}

            ////Numero x
            //for (int i = 0; i < textenx.Length; i++)
            //{

            //    string xtext = textenx[i].ToString() == "0" ? "" : textenx[i].ToString();
            //    cb.BeginText();
            //    cb.SetFontAndSize(font2.BaseFont, font2.Size);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, xtext, chartX + textenx[i] * stepX, chartY - 15, 0);
            //    cb.EndText();
            //}




            #endregion

            var datosx = new List<float>();
            var datosy = new List<float>();

            datos.ForEach(d => datosx.Add((float)d.X));
            datos.ForEach(d => datosy.Add((float)d.Y));


            //punto 0
            float chartX = 50;
            float chartY = 480 / valre2;

            //Dimensiones del chart
            float chartWidth = 490;
            float chartHeight= 300;

            cb.BeginText();
            cb.SetFontAndSize(font.BaseFont, font.Size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "HAAAAAAAAAAAAAAAAAAAAAAAAA", 100 , 800 , 0);
            cb.EndText();

            // Dibujar el eje X y el eje Y
            cb.MoveTo(chartX, chartY + chartHeight + 10);
            cb.LineTo(chartX, chartY);
            cb.LineTo(chartX + chartWidth + 10, chartY);


            float[] dataPoints = datosy.ToArray(); // Datos Y
            float[] dataPointsx = datosx.ToArray(); // Datos X


            float maxDataPointy = dataPoints.Max();
            float maxDataPointx = dataPointsx.Max();

            if (dataPoints.Min() < 0)
            {
                maxDataPointy = dataPoints.Max() + (dataPoints.Min() * -1) + 1;

            }
            if (dataPointsx.Min() < 0 )
            {
                maxDataPointx = dataPointsx.Max() + (dataPointsx.Min() * -1) + 1;
            }           

            float stepX = chartWidth  / maxDataPointx;//--| Separadares para escalar
            float stepY = chartHeight / maxDataPointy;//-| 
                    


            if (dataPointsx.Min() > 0 & dataPoints.Min() > 0)
            {
                cb.BeginText();
                cb.SetFontAndSize(font.BaseFont, font.Size);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", chartX - 7, chartY - 7, 0);
                cb.EndText();
            }        

            px = dataPointsx[0];
            py = dataPoints[0] ;

            if(dataPoints.Min() < 0)
            {
                caly = dataPoints.Min() - py;
                py = caly < 0 ? caly * -1 : caly;
                
            }

            if(dataPointsx.Min() < 0)
            {
                calx = dataPointsx.Min() - px;
                px = calx < 0 ? calx * -1 : calx;
            }
           
            //punto de partida
            cb.MoveTo(chartX + 10 + px * stepX, chartY + 10 + py * stepY);
            cb.Circle(chartX + 10 + px * stepX, chartY + 10 + py * stepY, 3);
            

            //lineas que le siguen
            for (int i = 0; i < dataPoints.Length; i++)
            {
                string NoP = "Positivo";
                if (dataPoints[i].ToString().StartsWith("-"))
                {
                    NoP = "Negativo";
                }

                px = dataPointsx[i];
                py = dataPoints[i];

                if (dataPoints.Min() < 0)
                {
                    caly = dataPoints.Min() - py;
                    py = caly < 0 ? caly * -1 : caly;

                }

                if (dataPointsx.Min() < 0)
                {
                    calx = dataPointsx.Min() - px;
                    px = calx < 0 ? calx * -1 : calx;
                }


                //Texto que se coloca arriba, modificar al gusto
                texty = NoP;
                cb.BeginText();
                cb.SetFontAndSize(font.BaseFont, font.Size);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, texty, chartX + 15 + px * stepX, chartY + 15 + py * stepY, 0);
                cb.EndText();



                cb.LineTo(chartX + 10 +  px * stepX, chartY + 10 + py * stepY);
               
            }

            cb.Stroke();
            // Circulos
            for (int i = 0; i < dataPoints.Length; i++)
            {

                px = dataPointsx[i];
                py = dataPoints[i];

                if (dataPoints.Min() < 0)
                {
                    caly = dataPoints.Min() - py;
                    py = caly < 0 ? caly * -1 : caly;

                }

                if (dataPointsx.Min() < 0)
                {
                    calx = dataPointsx.Min() - px;
                    px = calx < 0 ? calx * -1 : calx;
                }


                cb.Circle(chartX + 10 + px * stepX, chartY + 10 + py * stepY, 2);
                cb.Fill();
            }


            //lista para los numeros de los ejes
            List<float> dtss = new List<float>();
            List<float> dtss2 = new List<float>();

            int cuant = 0;

            if (dataPoints.Min() <= maxDataPointy * 0.10)
            {
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.90));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.70));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.30));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.10));

                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);
                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));
                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }             

            }
            else if(dataPoints.Min() <= maxDataPointy * 0.20)
            {
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.80));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.60));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.40));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.20));

                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.20));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));

                    dtss.Add((float)Math.Round(dataPoints.Min()));

                }

                



            }
            else if (dataPoints.Min() >= maxDataPointy * 0.30)
            {
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.80));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.30));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.10));

                if(dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.20));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.80));

                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }             

            }
            else if (dataPoints.Min() >= maxDataPointy * 0.40)
            {

                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.90));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.30));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.10));


                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.30));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.80));

                    dtss.Add((float)Math.Round(dataPoints.Min()));

                }


            }
            else if (dataPoints.Min() >= maxDataPointy * 0.50)
            {              
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.80));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.30));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.10));


                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.40));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.60));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.80));

                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }




            }
            else if (dataPoints.Min() >= maxDataPointy * 0.60)
            {
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.80));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.30));


                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.10));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.30));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.90));

                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }

            }
            else if (dataPoints.Min() >= maxDataPointy * 0.70)
            {

                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.80));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.20));


                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.10));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.30));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.80));

                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }

                

            }
            else if (dataPoints.Min() >= maxDataPointy * 0.8)
            {               
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.20));

                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.10));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.30));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.90));

                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }               

            }
            else if (dataPoints.Min() >= maxDataPointy * 0.9)
            {
                dtss.Add((float)Math.Round(dataPoints.Max()));
                dtss.Add((float)Math.Round(dataPoints.Max() * 0.50));

                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);
                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.10));
                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.30));
                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.50));
                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.70));
                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.90));
                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }
                
            }
            else
            {
                dtss.Add((float)Math.Round(dataPoints.Max()));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.80));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.60));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.40));

                dtss.Add((float)Math.Round(dataPoints.Max() * 0.20));

                if (dataPoints.Min() < 0)
                {
                    dtss.Add(0);

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.20));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.40));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.60));

                    dtss.Add((float)Math.Round(dataPoints.Min() * 0.80));

                    dtss.Add((float)Math.Round(dataPoints.Min()));
                }               

            }

            if (dataPointsx.Min() <= maxDataPointx * 0.10)
            {

                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.90));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.70));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.30));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.10));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));
                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }               
            }
            else if (dataPointsx.Min() <= maxDataPointx * 0.20)
            {
                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.60));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.40));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.20));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.20));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }
            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.30)
            {
                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.30));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.10));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.20));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.80));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }


                //

            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.40)
            {

                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.90));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.30));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.10));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.30));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.80));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));

                }
                
            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.50)
            {
                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.30));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);


                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.10));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.30));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.90));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }              
                                
            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.60)
            {

                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.30));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.10));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.40));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.60));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.80));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }

            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.70)
            {

                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.20));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.10));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.30));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.80));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }             
                
            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.8)
            {

                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.20));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);


                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.10));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.30));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.90));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }           
                
            }
            else if (dataPointsx.Min() >= maxDataPointx * 0.9)
            {
                dtss2.Add((float)Math.Round(dataPointsx.Max()));
                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.50));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);


                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.10));
                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.30));
                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.50));
                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.70));
                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.90));
                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                    //
                }



            }
            else
            {

                dtss2.Add((float)Math.Round(dataPointsx.Max()));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.80));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.60));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.40));

                dtss2.Add((float)Math.Round(dataPointsx.Max() * 0.20));


                if (dataPointsx.Min() < 0)
                {
                    dtss2.Add(0);



                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.20));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.40));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.60));

                    dtss2.Add((float)Math.Round(dataPointsx.Min() * 0.80));

                    dtss2.Add((float)Math.Round(dataPointsx.Min()));
                }                
            }

            //var cuant2 = 10 - cuant;

            //int c = 0;
            //string number;

            float[] texteny = dtss.ToArray();
            float[] textenx = dtss2.ToArray();

            iTextSharp.text.Font font2 = FontFactory.GetFont(FontFactory.HELVETICA, 8);

            //Numero y
            for (int i = 0; i < texteny.Length; i++)
            {

                py = texteny[i];

                if (texteny.Min() < 0)
                {
                    caly = texteny.Min() - py;
                    py = caly < 0 ? caly * -1 : caly;

                }

                texty = texteny[i].ToString();
                cb.BeginText();
                cb.SetFontAndSize(font2.BaseFont, font2.Size);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, texty, chartX - 15, chartY + 10 + py * stepY, 0);
                cb.EndText();
            }

            //Numero x
            for (int i = 0; i < textenx.Length; i++)
            {
                px = textenx[i];                

                if (textenx.Min() < 0)
                {
                    calx = textenx.Min() - px;
                    px = calx < 0 ? calx * -1 : calx;
                }

                textx = textenx[i].ToString();
                cb.BeginText();
                cb.SetFontAndSize(font2.BaseFont, font2.Size);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, textx , chartX + 10 + px * stepX, chartY - 15, 0);
                cb.EndText();
            }

        }

        private void C_x_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                C_x.Text = "";

                if (C_x.Text != "" & C_y.Text != "")
                {

                    //var cord = Tuple.Create(float.Parse(C_x.Text), float.Parse(C_y.Text));
                    //puntos.Add(cord);
                }
                else
                {
                    MessageBox.Show("MAL");
                }

            
           


            }


        }

        static double GenerateOscillatingValue(int i, int totalPoints)
        {
            // Parámetros para controlar la forma de las oscilaciones
            double amplitude = 100;
            double frequency = 2 * Math.PI / totalPoints;
            double noise = 20;

            // Función oscilatoria con ruido
            double value = amplitude * Math.Sin(frequency * i) + (noise * Math.Cos(frequency * i / 2)) + 100;

            return value;
        }

        static double CalculateMoment(double axialLoad, double maxAxialLoad, double maxMoment)
        {
            // Ejemplo simplificado de cálculo del momento flector
            // En la práctica, este cálculo sería más complejo y dependiente de las propiedades del muro
            double ratio = axialLoad / maxAxialLoad;
            return maxMoment * (1 - ratio * ratio); // Parabólico para ilustrar
        }
    }
}

