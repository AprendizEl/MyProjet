using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc;
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
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;

using DocumentFormat.OpenXml.Bibliography;

using System.Windows.Forms;
using System.Collections.ObjectModel;
using DocumentFormat.OpenXml.Vml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Spire.Doc.Formatting;
using Microsoft.Office.Interop.Word;
using NPOI.Util;
using NPOI.XWPF.UserModel;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using ClosedXML.Excel;
using NPOI.SS.Formula.Functions;
using DocumentFormat.OpenXml.Math;

namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl9.xaml
    /// </summary>
    public partial class UserControl9 : System.Windows.Controls.UserControl
    {

        List<List<string>> ListRuts = new List<List<string>>();
        List<List<string>> ListParras = new List<List<string>>();
        List<List<string>> filasT = new List<List<string>>();
        List<List<string>> ListaTabla = new List<List<string>>();


        private List<string> parra = new List<string>();
        private List<string> rutas = new List<string>();
        private List<string> titul = new List<string>();
        private List<string> rtablas = new List<string>();
        private bool Simg = false;
        private int Pimg = 0;
        private int Ptable = 0;




        string si = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\Libro1.xlsx";








        public UserControl9()
        {
            InitializeComponent();

           

           


        }

       

        private void Document_Click(object sender, RoutedEventArgs e)
        {


            CreateDocumentsSpire_SDK();


        }

        private void CreateDocumentsSpire_SDK()
        {
            string templatePath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Plantilla.docx";
            string outputPath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Test.docx";


            // Copiar el archivo de plantilla al archivo de salida
            System.IO.File.Copy(templatePath, outputPath, true);

            
            

            for (int t = 0; t < titul.Count; t++)
            {
                int cont = ListParras[t].Count;
                List<string> UseP = ListParras[t];
                List<string> UseI = ListRuts[t];
                List<string> UseT = ListaTabla[t];


                //Inserta Titulo con nivel 1
                inserTitulo(outputPath, titul[t], templatePath);
                

                for (int c = 0; c < cont; c++)
                {

                    //insertar parrafos
                    inserParra(outputPath, UseP[c]);


                    //insertar tablas

                    if (UseI[c] != "X")
                    {
                        // Insertar imagen con NPOI
                        InsertImageNPOI(outputPath, UseI[c], 300 , 200);
                    }

                    //inserTable(outputPath);
                    inserTable(outputPath , UseT[c]);


                }
            }                 
            
            #region
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {

                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.Body;

                // Crear una tabla
                DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                // Accede a la definición de estilos
                StyleDefinitionsPart styleDefinitionsPart = mainPart.StyleDefinitionsPart;

                if (styleDefinitionsPart != null)
                {
                    // Nombre del estilo de tabla que queremos aplicar
                    string desiredStyleName = "Grid Table 4 Accent 5";
                    string desiredStyleId = null;

                    // Verifica si el estilo existe
                    DocumentFormat.OpenXml.Wordprocessing.Styles styles = styleDefinitionsPart.Styles;
                    foreach (var style in styles.Elements<DocumentFormat.OpenXml.Wordprocessing.Style>())
                    {
                        // Filtra solo los estilos de tabla
                        if (style.Type != null && style.Type == DocumentFormat.OpenXml.Wordprocessing.StyleValues.Table)
                        {
                            // Imprimir todos los nombres de estilos de tabla disponibles para depuración
                            Console.WriteLine($"Estilo de tabla disponible: {style.StyleName?.Val}");

                            if (style.StyleName?.Val == desiredStyleName)
                            {
                                desiredStyleId = style.StyleId;
                                Console.WriteLine($"Estilo de tabla encontrado: {style.StyleName.Val}");
                                break;
                            }
                        }
                    }

                    if (desiredStyleId != null)
                    {
                        // Crear una nueva tabla
                        DocumentFormat.OpenXml.Wordprocessing.Table tableS = new DocumentFormat.OpenXml.Wordprocessing.Table();

                        // Crear propiedades de la tabla y aplicar el estilo de tabla
                        TableProperties tableProperties = new TableProperties();
                        DocumentFormat.OpenXml.Wordprocessing.TableStyle tableStyle = new DocumentFormat.OpenXml.Wordprocessing.TableStyle() { Val = desiredStyleId };
                        tableProperties.Append(tableStyle);

                        // Agregar propiedades a la tabla
                        table.AppendChild(tableProperties);

                        // Crear una fila
                        DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                        // Crear una celda
                        DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                        tableCell.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Contenido de la celda"))));

                        // Agregar la celda a la fila
                        tableRow.Append(tableCell);

                        // Agregar la fila a la tabla
                        table.Append(tableRow);

                        // Agregar la tabla al cuerpo del documento
                        mainPart.Document.Body.Append(table);

                        // Guardar cambios en el documento
                        mainPart.Document.Save();
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el estilo de tabla especificado en la plantilla.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron definiciones de estilo en la plantilla.");
                }
            }
            #endregion


            #region

            //string excelFilePath = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\TEst2.xlsx";
            //using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            //{
            //    MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            //    DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.Body;

            //    // Abrir el archivo Excel con ClosedXML
            //    using (var workbook = new XLWorkbook(excelFilePath))
            //    {
            //        // Obtener la primera hoja del libro
            //        var worksheet = workbook.Worksheet(1);

            //        // Iterar sobre las filas y columnas usadas en la hoja
            //        var usedRange = worksheet.RangeUsed();
            //        int rowCount = usedRange.RowCount();
            //        int colCount = usedRange.ColumnCount();

            //        // Crear una tabla en el documento Word
            //        DocumentFormat.OpenXml.Wordprocessing.Table wordTable = new DocumentFormat.OpenXml.Wordprocessing.Table();

            //        // Agregar filas y celdas a la tabla
            //        for (int r = 1; r <= rowCount; r++)
            //        {
            //            DocumentFormat.OpenXml.Wordprocessing.TableRow row = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
            //            for (int c = 1; c <= colCount; c++)
            //            {
            //                string cellValue = worksheet.Cell(r, c).Value.ToString();
            //                DocumentFormat.OpenXml.Wordprocessing.TableCell cell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(cellValue))));
            //                row.Append(cell);
            //            }
            //            wordTable.Append(row);
            //        }

            //        // Agregar la tabla al cuerpo del documento Word
            //        body.Append(wordTable);
            //    }
            //}
            #endregion
            // Guardar el documento final
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                wordDoc.MainDocumentPart.Document.Save();
            }
        }



        private void inserTitulo(string outputPath, string til,string templatePath )
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                // Obtener el cuerpo del documento
                DocumentFormat.OpenXml.Wordprocessing.Body body = wordDoc.MainDocumentPart.Document.Body;

                for(int i = 0; i < 15; i++)
                {
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph air = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                    DocumentFormat.OpenXml.Wordprocessing.Run run3 = new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(""));
                    air.Append(run3);

                    body.AppendChild(air);
                }
                

                // Crear un título de nivel 1
                string titles =GetHeading1StyleId(templatePath);
                DocumentFormat.OpenXml.Wordprocessing.Paragraph title = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(til)));
                title.ParagraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                title.ParagraphProperties.ParagraphStyleId = new ParagraphStyleId() { Val = titles };
                body.AppendChild(title);

                DocumentFormat.OpenXml.Wordprocessing.Paragraph jum = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();


                DocumentFormat.OpenXml.Wordprocessing.Run ru = new DocumentFormat.OpenXml.Wordprocessing.Run();
                ru.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.Page });
                jum.AppendChild(ru);

                body.AppendChild(jum);


            }
        }


        private void inserTable(string outputPath, string tab)
        {
            comvertir(tab);
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.Body;


                int countC = filasT[0].Count;


                // Crear una tabla
                DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
                table.AppendChild(new TableProperties(new DocumentFormat.OpenXml.Wordprocessing.TableStyle() { Val = "Tablaconcuadrcula4-nfasis5" }));

                int contC = filasT[0].Count;
                int contD = filasT.Count;

                // Crear las filas de datos
                for (int k = 0; k < contD; k++)
                {

                    var UseT = filasT[k];

                    DocumentFormat.OpenXml.Wordprocessing.TableRow tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    for (int j = 0; j < contC; j++)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.TableCell lc = new DocumentFormat.OpenXml.Wordprocessing.TableCell(
                            new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                new DocumentFormat.OpenXml.Wordprocessing.Run(
                                    new DocumentFormat.OpenXml.Wordprocessing.Text(UseT[j])
                                )
                            )
                        );

                        tr.Append(lc);
                    }
                    table.Append(tr);
                }

                // Añadir la tabla al cuerpo del documento
                body.Append(table);

                // Añadir un salto de página
                DocumentFormat.OpenXml.Wordprocessing.Paragraph jum = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.Run ru = new DocumentFormat.OpenXml.Wordprocessing.Run();
                ru.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.Page });
                jum.AppendChild(ru);

                body.AppendChild(jum);
            }

        }



        private void inserParra(string outputPath,string par)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                // Obtener el cuerpo del documento
                DocumentFormat.OpenXml.Wordprocessing.Body body = wordDoc.MainDocumentPart.Document.Body;

                // Insertar párrafos
                DocumentFormat.OpenXml.Wordprocessing.Paragraph para = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.Run run1 = new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(par));
                para.Append(run1);

                para.ParagraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                    new ParagraphBorders(),
                    new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left }, // Alineación izquierda
                    new Indentation()
                    {
                        Left = "720",  // Márgen izquierdo en puntos (1 pulgada = 72 puntos)
                    }
                );

                body.AppendChild(para);

                DocumentFormat.OpenXml.Wordprocessing.Paragraph air = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.Run run3 = new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(""));
                air.Append(run3);

                body.AppendChild(air);


            }
        }

        static void InsertImageNPOI(string outputPath, string imagePath, int w, int h)
        {
            // Cargar el documento creado con Open XML SDK utilizando NPOI
            using (FileStream fs = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XWPFDocument doc = new XWPFDocument(fs);

                // Insertar la imagen utilizando NPOI
                using (FileStream pic = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    XWPFParagraph para = doc.CreateParagraph();
                    para.Alignment = ParagraphAlignment.CENTER;
                    XWPFRun run = para.CreateRun();
                    run.AddPicture(pic, (int)PictureType.PNG, "imagen.png", Units.ToEMU(w), Units.ToEMU(h));
                }

                // Guardar el documento de Word con la imagen insertada
                using (FileStream fsout = new FileStream(outputPath, FileMode.Create))
                {
                    doc.Write(fsout);
                }
            }
        }


        private static string GetHeading1StyleId(string templatePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(templatePath, false))
            {
                StyleDefinitionsPart stylePart = wordDoc.MainDocumentPart.StyleDefinitionsPart;
                DocumentFormat.OpenXml.Wordprocessing.Styles styles = stylePart.Styles;

                // Buscar el estilo de título de nivel 1
                DocumentFormat.OpenXml.Wordprocessing.Style heading1Style = styles.Elements<DocumentFormat.OpenXml.Wordprocessing.Style>().FirstOrDefault(s => s.StyleName?.Val == "heading 1" || s.StyleId == "Heading1");

                return heading1Style?.StyleId ?? "Heading1";
            }
        }



        private void NewP_Click(object sender, RoutedEventArgs e)
        {
            parra.Add(TB_TEXT.Text);


            bool veri = VerificacionI(rutas);


       
            rutas.Add("X");

    


        }

        private void NewT_Click(object sender, RoutedEventArgs e)
        {
            titul.Add(TB_TEXT.Text);
        }

        private void NewI_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Seleccionar Imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Crear una nueva BitmapImage desde el archivo seleccionado
                string rutaArchivo = openFileDialog.FileName;


                rutas.Add(rutaArchivo);
                int c = rutas.Count;
                int a = parra.Count;
                if (c > a)
                {
                    rutas[c - 2] = rutaArchivo;
                    rutas.Remove(rutas.Last());
                }

            }


            

            bool veri = VerificacionI(rutas);

            if (veri == false)
            {
                rutas.Add("X");
                Pimg = rutas.Count;
            }



        }

        private void Star_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardaParras_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GuardarImg_Click(object sender, RoutedEventArgs e)
        {
            ListRuts.Add(rutas);
            ListParras.Add(parra);
            ListaTabla.Add(rtablas);
        }

        private void comvertir(string filtRuh)
        {

                     

            
            using (var workbook = new XLWorkbook(filtRuh))
            {
                var worksheet = workbook.Worksheet("Hoja1");
                var usedRange = worksheet.RangeUsed();
                var ContR = usedRange.RowCount();


                for (int i = 0; i < ContR; i++)
                {

                    var row = worksheet.Row(i+1);

                    var rowE = new List<string>();
                    foreach (var cell in row.Cells())
                    {
                        rowE.Add(cell.GetValue<string>());
                        
                    }
                    filasT.Add(rowE);

                }




            }



        }

        private bool VerificacionI(List<string> conten)
        {

            if (Pimg != conten.Count )
            {
                Simg = true;
                Pimg = conten.Count;
            }
            else
            {
                Simg= false;
            }

            return Simg;            



        }

        private static void UpdateTableOfContents(string docPath)
        {
            // Abrir el documento con Spire.Doc
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(docPath);

            // Actualizar la tabla de contenidos
            document.UpdateTableOfContents();

            // Guardar los cambios
            document.SaveToFile(docPath, FileFormat.Docx);
        }

        private void TB_TEXT_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                parra.Add(TB_TEXT.Text);


                bool veri = VerificacionI(rutas);



                rutas.Add("X");
                TB_TEXT.Clear();


            }



        }

        private void ExcelT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de excel|*.xlsx;";
            openFileDialog.Title = "Seleccionar excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Crear una nueva BitmapImage desde el archivo seleccionado
                string rutaArchivo = openFileDialog.FileName;


                rtablas.Add(rutaArchivo);
                int c = rtablas.Count;
                int a = parra.Count;
                if (c > a)
                {
                    rtablas[c - 2] = rutaArchivo;
                    rtablas.Remove(rtablas.Last());
                }

            }




        }
    }
}