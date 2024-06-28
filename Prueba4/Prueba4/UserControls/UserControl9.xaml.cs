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
        private ObservableCollection<BitmapImage> listaDeImagenes = new ObservableCollection<BitmapImage>();
        private List<string> Parra = new List<string>();
        private List<string> rutas = new List<string>();
        private List<string> Porros = new List<string>();
        private List<string> column = new List<string>();




        public UserControl9()
        {
            InitializeComponent();
            
        }


        private void Freepire_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Test.docx";
            string Plantilla = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Plantilla.docx";
            string IMge = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Coche negro.jpg";
            CreateDocumentsSpire_SDK();
            //CreateWordDocument();
            //CreateSimpleWordDocument(filePath);
            //CreateWordDocument(filePath);

            //CreateDocumentD(filePath);

            //GenerarDocumentoDesdePlantilla( Plantilla , filePath, IMge);
            UpdateTableOfContents(filePath);
        }

        private void CreateDocumentsSpire_SDK()
        {
            string templatePath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Plantilla.docx";
            string outputPath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Test.docx";
            string imagePath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Coche negro.jpg";

            // Copiar el archivo de plantilla al archivo de salida
            System.IO.File.Copy(templatePath, outputPath, true);

            // Abrir el documento con Open XML SDK
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                // Obtener el cuerpo del documento
                DocumentFormat.OpenXml.Wordprocessing.Body body = wordDoc.MainDocumentPart.Document.Body;

                // Crear un título de nivel 1
                string titles = GetHeading1StyleId(templatePath);
                DocumentFormat.OpenXml.Wordprocessing.Paragraph title = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Título")));
                title.ParagraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                title.ParagraphProperties.ParagraphStyleId = new ParagraphStyleId() { Val = titles };
                body.AppendChild(title);

                // Insertar párrafos
                for (int i = 0; i < Parra.Count; i++)
                {
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph para = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                    DocumentFormat.OpenXml.Wordprocessing.Run run1 = new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(Parra[i]));
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

                #region
                // Insertar tabla
                //DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
                //TableProperties tableProperties = new TableProperties(
                //    new TableJustification() { Val = TableRowAlignmentValues.Center },

                //               new TableBorders(
                //               new DocumentFormat.OpenXml.Wordprocessing.TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                //               new DocumentFormat.OpenXml.Wordprocessing.BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                //               new DocumentFormat.OpenXml.Wordprocessing.LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                //               new DocumentFormat.OpenXml.Wordprocessing.RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                //               new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 },
                //               new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 0 }
                //                               ));

                //table.AppendChild(tableProperties);

                //// Crear una fila (encabezado)
                //DocumentFormat.OpenXml.Wordprocessing.TableRow headerRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                //// Crear celdas para el encabezado
                //headerRow.Append(CreateHeaderCell("ID"));
                //headerRow.Append(CreateHeaderCell("Nombre"));


                //// Agregar las celdas al encabezado



                //// Agregar la fila de encabezado a la tabla
                //table.Append(headerRow);

                //// Crear filas de datos
                //DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow1 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                //DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell1 = CreateTableCellWithText("Dato 1");
                //DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell2 = CreateTableCellWithText("Dato 2");
                //dataRow1.Append(dataCell1, dataCell2);

                //DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow2 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                //DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell3 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Celda 2"))));
                //DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell4 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Celda 2"))));
                //dataRow2.Append(dataCell3, dataCell4);

                //// Agregar filas de datos a la tabla
                //table.Append(dataRow1, dataRow2);

                //// Agregar la tabla al cuerpo del documento
                //body.AppendChild(table);
                #endregion
            }

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.Body;

                // Crear una tabla
                DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                // Obtener el estilo de tabla de la plantilla

                //if (!string.IsNullOrEmpty(tableStyleId))
                //{
                    table.AppendChild(new TableProperties(new DocumentFormat.OpenXml.Wordprocessing.TableStyle() { Val = "Tablaconcuadrcula4-nfasis5" }));

                DocumentFormat.OpenXml.Wordprocessing.TableRow headerRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                headerRow.TableRowProperties = new TableRowProperties(new TableHeader(),
                                        new TableLook() { FirstRow = true } // Esto marca la primera fila como encabezado
);
                for (int c = 0; c < 3; c++)
                {
                    DocumentFormat.OpenXml.Wordprocessing.TableCell tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text($"Encabezado {c + 1}"))));
                    tc.TableCellProperties = new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "2400" });
                    headerRow.Append(tc);
                }
                table.Append(headerRow);

                // Crear las filas de datos
                for (int r = 0; r < 3; r++)
                {
                    DocumentFormat.OpenXml.Wordprocessing.TableRow tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    for (int c = 0; c < 3; c++)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.TableCell tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text($"Fila {r + 1}, Columna {c + 1}"))));
                        tr.Append(tc);
                    }
                    table.Append(tr);
                }
                body.Append(table);
            }

            // Insertar imagen con NPOI
            InsertImageNPOI(outputPath, imagePath);

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
            // No necesitas abrir el documento nuevamente, solo guardarlo
            // usando la misma instancia wordDoc que ya tienes abierta
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                wordDoc.MainDocumentPart.Document.Save();
            }
        }

        static DocumentFormat.OpenXml.Wordprocessing.TableCell CreateHeaderCell(string text)
        {
            DocumentFormat.OpenXml.Wordprocessing.TableCell cell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(text))));
            TableCellProperties cellProperties = new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto });
            cellProperties.Append(new DocumentFormat.OpenXml.Wordprocessing.Shading() { Fill = "A9D08E" }); // Ejemplo: color de fondo verde claro
            cell.Append(cellProperties);
            return cell;
        }

        static string GetTableStyleId(MainDocumentPart mainPart)
        {
            // Buscar el estilo de tabla predeterminado en la plantilla
            StyleDefinitionsPart stylePart = mainPart.StyleDefinitionsPart;
            if (stylePart != null)
            {
                DocumentFormat.OpenXml.Wordprocessing.Style tableStyle = stylePart.Styles.Descendants<DocumentFormat.OpenXml.Wordprocessing.Style>()
                    .FirstOrDefault(s => s.Type == DocumentFormat.OpenXml.Wordprocessing.StyleValues.Table && s.Default == OnOffValue.FromBoolean(true));

                if (tableStyle != null)
                {
                    return tableStyle.StyleId;
                }
            }
            return null;
        }






        static DocumentFormat.OpenXml.Wordprocessing.TableCell CreateTableCell(string text)
        {
            DocumentFormat.OpenXml.Wordprocessing.TableCell cell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(text))));
            return cell;
        }

        static void InsertImageNPOI(string outputPath, string imagePath)
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
                    run.AddPicture(pic, (int)PictureType.PNG, "imagen.png" ,Units.ToEMU(300), Units.ToEMU(200));
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
        

        private void Ejemp_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Seleccionar Imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Crear una nueva BitmapImage desde el archivo seleccionado
                string rutaArchivo = openFileDialog.FileName;
                rutas.Add(rutaArchivo);
            }




        }

        private void NewP_Click(object sender, RoutedEventArgs e)
        {
            Parra.Add(TB_TEXT.Text);


        }






        private List<string> CargarDatosDesdeExcel()
        {
            string celda;

            // Ruta de tu archivo Excel
            string filePath = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\TEst2.xlsx";

            // Cargar el archivo Excel usando ClosedXML
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                // Selecciona la hoja que quieres leer (por ejemplo, la primera hoja)
                IXLWorksheet worksheet = workbook.Worksheet(1);



                // Asumiendo que la primera fila es la cabecera
                bool firstRow = true;
                foreach (IXLRow row in worksheet.Rows())
                {
                    // Agrega las columnas al DataTable
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            cell.Value.ToString();
                        }
                        firstRow = false;

                    }
                    if (!firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            cell.Value.ToString();

                        }
                        // Agrega filas al DataTable

                    }
                }

                return Porros;

            }
        }



    }
}



