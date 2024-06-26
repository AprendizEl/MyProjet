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

        }

   


        private void CreateDocumentsSpire_SDK()
        {


            int Npara = Parra.Count;
            int Nimg = listaDeImagenes.Count;

             string templatePath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Plantilla.docx";
             string outputPath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Test.docx";
             //string imagePath = @"C:\Users\eecheto\Desktop\MyProjet\Prueba4\Prueba4\img\Coche negro.jpg";
    


            // Copiar el archivo de plantilla al archivo de salida
            System.IO.File.Copy(templatePath, outputPath, true);

            // Abrir el documento de salida con Open XML SDK
            string titles = GetTitleFromTemplate(templatePath, "Heading1");



            for (int i = 0; i < Npara; i++ )
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
                {
                    // Obtener el cuerpo del documento

                    DocumentFormat.OpenXml.Wordprocessing.Body body = wordDoc.MainDocumentPart.Document.Body;

                    // Crear un título de nivel 1
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph title = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Título")));
                    title.ParagraphProperties = new ParagraphProperties();
                    title.ParagraphProperties.ParagraphStyleId = new ParagraphStyleId() { Val = titles };

                    title.ParagraphProperties = new ParagraphProperties(
                    new ParagraphBorders(),
                    new Justification() { Val = JustificationValues.Center }, // Alineación izquierda
                    new Shading() { Color = "red" }
                    );


                    body.AppendChild(title);

                    SpacingBetweenLines paras3 = new SpacingBetweenLines() { After = "240", Line = "360", LineRule = LineSpacingRuleValues.Auto };
                    title.Append(paras3);



                    for (int l = 0; l < 5; l++)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.Paragraph para = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                        DocumentFormat.OpenXml.Wordprocessing.Run run1 = new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(Parra[i]));
                        para.Append(run1);

                        para.ParagraphProperties = new ParagraphProperties(
                        new ParagraphBorders(),
                        new Justification() { Val = JustificationValues.Left }, // Alineación izquierda
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

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
                {
                    // Obtener el cuerpo del documento
                    DocumentFormat.OpenXml.Wordprocessing.Body body = wordDoc.MainDocumentPart.Document.Body;

                    //Tabla


                    DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
                    TableProperties tableProperties = new TableProperties(
                    new TableJustification() { Val = TableRowAlignmentValues.Center }
                    );
                    table.AppendChild(tableProperties);

                    // Crear una fila (encabezado)
                    DocumentFormat.OpenXml.Wordprocessing.TableRow headerRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                    // Crear celdas para el encabezado
                    DocumentFormat.OpenXml.Wordprocessing.TableCell headerCell1 = CreateTableCellWithText("Encabezado 1");
                    DocumentFormat.OpenXml.Wordprocessing.TableCell headerCell2 = CreateTableCellWithText("Encabezado 2");

                    // Agregar las celdas al encabezado
                    headerRow.Append(headerCell1, headerCell2);

                    // Agregar la fila de encabezado a la tabla
                    table.Append(headerRow);

                    // Crear filas de datos
                    DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow1 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell1 = CreateTableCellWithText("Dato 1");
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell2 = CreateTableCellWithText("Dato 2");
                    dataRow1.Append(dataCell1, dataCell2);

                    DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow2 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell3 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Celda 2"))));
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell4 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Celda 2"))));
                    dataRow2.Append(dataCell3, dataCell4);



                    // Agregar filas de datos a la tabla
                    table.Append(dataRow1, dataRow2);

                    // Agregar la tabla al cuerpo del documento
                    body.AppendChild(table);



                    TableProperties tableBorders = new TableProperties(
                       new TableBorders(
                       new DocumentFormat.OpenXml.Wordprocessing.TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                       new DocumentFormat.OpenXml.Wordprocessing.BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                       new DocumentFormat.OpenXml.Wordprocessing.LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                       new DocumentFormat.OpenXml.Wordprocessing.RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 8 },
                       new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 },
                       new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 0 }
                                        )
                   );
                    table.AppendChild(tableBorders);


                }

             

                InsertImageWithSpire(outputPath, rutas[i]);
            }
               
            


            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputPath, true))
            {
                // Obtener el cuerpo del documento
                DocumentFormat.OpenXml.Wordprocessing.Body body = wordDoc.MainDocumentPart.Document.Body;

                // Crear un título de nivel 1
                wordDoc.MainDocumentPart.Document.Save();
            }


        }

 

        private static void InsertImageWithSpire(string docPath, string imagePath)
        {
            // Abrir el documento con FreeSpire.Doc
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(docPath);

            // Crear una sección y agregar un párrafo
            Spire.Doc.Section section = document.Sections[0];
            Spire.Doc.Documents.Paragraph paragraph = section.AddParagraph();

            // Insertar la imagen en el párrafo
            DocPicture picture = paragraph.AppendPicture(imagePath);
            picture.Width = 100;  // Ajusta el ancho según sea necesario
            picture.Height = 100;
            // Ajusta la altura según sea necesario

            // Guardar los cambios
            document.SaveToFile(docPath, FileFormat.Docx);
        }





        static DocumentFormat.OpenXml.Wordprocessing.TableCell CreateTableCellWithText(string text)
        {
            // Crear un parrafo con el texto especificado
            DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(text)));
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "20" });
            // Crear una celda de tabla con el párrafo
            DocumentFormat.OpenXml.Wordprocessing.TableCell cell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(paragraph);

            // Crear propiedades de celda y aplicar formato (ejemplo: color de fondo)
            TableCellProperties cellProperties = new TableCellProperties();
            Shading shading = new Shading() { Color = "auto", Fill = "A9D08E" }; // Color de fondo (verde claro)
            cellProperties.Append(shading);
            cell.Append(cellProperties);

            return cell;
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


        private static string GetTitleFromTemplate(string templatePath, string headingStyle)
        {
            // Abrir el documento con Spire.Doc
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(templatePath);

            // Buscar el párrafo con el estilo de título deseado
            foreach (Spire.Doc.Section section in document.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    if (para.StyleName == headingStyle)
                    {
                        // Retornar el texto del título
                        return para.Text;
                    }
                }
            }

            // Si no se encuentra el título, retornar una cadena vacía
            return string.Empty;
        }


        //private static void InsertImage(MainDocumentPart mainPart, DocumentFormat.OpenXml.Wordprocessing.Body body, string imagePath)
        // {
        //     ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
        //     using (FileStream stream = new FileStream(imagePath, FileMode.Open))
        //     {
        //         imagePart.FeedData(stream);
        //     }

        //     AddImageToBody(mainPart.GetIdOfPart(imagePart), body);
        // }

        // private static void AddImageToBody(string relationshipId, DocumentFormat.OpenXml.Wordprocessing.Body body)
        // {
        //     var element =
        //          new DocumentFormat.OpenXml.Wordprocessing.Drawing(
        //              new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
        //                  new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent() { Cx = 990000L, Cy = 792000L },
        //                  new DocumentFormat.OpenXml.Drawing.Wordprocessing.EffectExtent()
        //                  {
        //                      LeftEdge = 0L,
        //                      TopEdge = 0L,
        //                      RightEdge = 0L,
        //                      BottomEdge = 0L
        //                  },
        //                  new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties()
        //                  {
        //                      Id = (UInt32Value)1U,
        //                      Name = "Picture 1"
        //                  },
        //                  new DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties(
        //                      new DocumentFormat.OpenXml.Drawing.GraphicFrameLocks() { NoChangeAspect = true }),
        //                  new DocumentFormat.OpenXml.Drawing.Graphic(
        //                      new DocumentFormat.OpenXml.Drawing.GraphicData(
        //                          new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
        //                              new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
        //                                  new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
        //                                  {
        //                                      Id = (UInt32Value)0U,
        //                                      Name = "New Bitmap Image.jpg"
        //                                  },
        //                                  new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
        //                              new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
        //                                  new DocumentFormat.OpenXml.Drawing.Blip(
        //                                      new DocumentFormat.OpenXml.Drawing.BlipExtensionList(
        //                                          new DocumentFormat.OpenXml.Drawing.BlipExtension()
        //                                          {
        //                                              Uri =
        //                                                 "{28A0092B-C50C-407E-A947-70E740481C1C}"
        //                                          })
        //                                  )
        //                                  {
        //                                      Embed = relationshipId,
        //                                      CompressionState =
        //                                      DocumentFormat.OpenXml.Drawing.BlipCompressionValues.Print
        //                                  },
        //                                  new DocumentFormat.OpenXml.Drawing.Stretch(
        //                                      new DocumentFormat.OpenXml.Drawing.FillRectangle())),
        //                              new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
        //                                  new DocumentFormat.OpenXml.Drawing.Transform2D(
        //                                      new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
        //                                      new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 990000L, Cy = 792000L }),
        //                                  new DocumentFormat.OpenXml.Drawing.PresetGeometry(
        //                                      new DocumentFormat.OpenXml.Drawing.AdjustValueList()
        //                                  )
        //                                  { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle }))
        //                      )
        //                      { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
        //              )
        //              {
        //                  DistanceFromTop = (UInt32Value)0U,
        //                  DistanceFromBottom = (UInt32Value)0U,
        //                  DistanceFromLeft = (UInt32Value)0U,
        //                  DistanceFromRight = (UInt32Value)0U
        //              });

        //     DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(element));
        //     body.Append(paragraph);
        // }
        //public void GenerarDocumentoDesdePlantilla(string plantillaPath, string nuevoDocumentoPath, string IMge)
        //{
        //    #region
        //    //Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
        //    //Microsoft.Office.Interop.Word.Document doc = null;

        //    //try
        //    //{
        //    //    // Abrir la plantilla
        //    //    object missing = System.Reflection.Missing.Value;
        //    //    doc = wordApp.Documents.Add(plantillaPath, ref missing, ref missing, ref missing);

        //    //    // Modificar el contenido (opcional)
        //    //    // Aquí puedes agregar contenido dinámico si es necesario

        //    //    // Agregar contenido al documento
        //    //    // Agregar un título
        //    //    Microsoft.Office.Interop.Word.Paragraph title = doc.Content.Paragraphs.Add(ref missing);
        //    //    title.Range.Text = "Título del Documento";
        //    //    title.Range.set_Style(WdBuiltinStyle.wdStyleHeading1);
        //    //    title.Range.InsertParagraphAfter();

        //    //    // Agregar un párrafo
        //    //    Microsoft.Office.Interop.Word.Paragraph para1 = doc.Content.Paragraphs.Add(ref missing);
        //    //    para1.Range.Text = "Este es un párrafo agregado desde C# utilizando Microsoft.Office.Interop.Word.";
        //    //    para1.Range.InsertParagraphAfter();

        //    //    // Agregar otro título
        //    //    Microsoft.Office.Interop.Word.Paragraph title2 = doc.Content.Paragraphs.Add(ref missing);
        //    //    title2.Range.Text = "Otro Título";
        //    //    title2.Range.set_Style(WdBuiltinStyle.wdStyleHeading2);
        //    //    title2.Range.InsertParagraphAfter();

        //    //    // Agregar otro párrafo
        //    //    Microsoft.Office.Interop.Word.Paragraph para2 = doc.Content.Paragraphs.Add(ref missing);
        //    //    para2.Range.Text = "Este es otro párrafo agregado desde C#.";
        //    //    para2.Range.InsertParagraphAfter();

        //    //    // Agregar una tabla
        //    //    Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(title2.Range, 3, 3, ref missing, ref missing);
        //    //    table.Borders.Enable = 1; // Habilitar bordes para la tabla
        //    //    for (int r = 1; r <= 3; r++)
        //    //    {
        //    //        for (int c = 1; c <= 3; c++)
        //    //        {
        //    //            table.Cell(r, c).Range.Text = $"Fila {r}, Columna {c}";
        //    //        }
        //    //    }

        //    //    // Agregar una imagen
        //    //    Microsoft.Office.Interop.Word.Paragraph paraImagen = doc.Content.Paragraphs.Add(ref missing);
        //    //    paraImagen.Range.InsertParagraphAfter();
        //    //    InlineShape picture = paraImagen.Range.InlineShapes.AddPicture(IMge, ref missing, ref missing, ref missing);
        //    //    picture.Width = 200; // Ajusta el ancho de la imagen
        //    //    picture.Height = 150; // Ajusta el alto de la imagen
        //    //    paraImagen.Range.InsertParagraphAfter();



        //    //    // Guardar el nuevo documento
        //    //    doc.SaveAs2(nuevoDocumentoPath);



        //    //    // Guardar el nuevo documento
        //    //    doc.SaveAs2(nuevoDocumentoPath);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Manejar cualquier excepción

        //    //}
        //    //finally
        //    //{
        //    //    // Cerrar Word y liberar recursos
        //    //    if (doc != null)
        //    //    {
        //    //        doc.Close();
        //    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
        //    //    }
        //    //    wordApp.Quit();
        //    //    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
        //    //}
        //    #endregion
        //    // Cargar la plantilla
        //    Spire.Doc.Document doc = new Spire.Doc.Document();
        //    doc.LoadFromFile(plantillaPath);

        //    // Obtener la sección
        //    Spire.Doc.Section section = doc.Sections[0];

        //    // Agregar un título
        //    Spire.Doc.Documents.Paragraph title = section.AddParagraph();
        //    title.AppendText("Título del Documento");
        //    title.ApplyStyle(BuiltinStyle.Heading1);

        //    int Nparra = Parra.Count;
        //    int Nimgs = listaDeImagenes.Count;

        //    for (int i = 0;  i < Nparra; i++)
        //    {
        //        Spire.Doc.Documents.Paragraph paras = section.AddParagraph();
        //        paras.AppendText(Parra[i]);

        //        Spire.Doc.Documents.Paragraph paraImagens = section.AddParagraph();

        //        DocPicture pictures = paraImagens.AppendPicture(rutas[i]);
        //        pictures.Width = 200;
        //        pictures.Height = 150;
        //        pictures.HorizontalAlignment = ShapeHorizontalAlignment.Center;

        //    }



        //    //for (int i = 1; i < 450 ; i++) {
        //    //    Spire.Doc.Documents.Paragraph para2 = section.AddParagraph();
        //    //    para2.AppendText("de hecho tomaría muy pocas cosas con seriedad.\r\n\r\nSería menos higiénico.");

        //    //}
        //    // Agregar un párrafo


        //    //Como agregar un parrafo
        //    Spire.Doc.Documents.Paragraph para1 = section.AddParagraph();
        //    para1.AppendText("Este es un párrafo agregado desde C# utilizando Spire.Doc.");

        //    //Como agregar una imagen 
        //    Spire.Doc.Documents.Paragraph paraImagen = section.AddParagraph();
        //    DocPicture picture = paraImagen.AppendPicture(IMge);
        //    picture.Width = 200;
        //    picture.Height = 150;

        //    //Como agregar titulos
        //    Spire.Doc.Documents.Paragraph title2 = section.AddParagraph();
        //    title2.AppendText("Tabla de Ejemplo");
        //    title2.ApplyStyle(BuiltinStyle.Heading2);

        //    //Como agregar una tabla
        //    Spire.Doc.Table table = section.AddTable(true);
        //    table.ResetCells(3, 3);

        //    for (int r = 0; r < 3; r++)
        //    {
        //        Spire.Doc.TableRow row = table.Rows[r];
        //        for (int c = 0; c < 3; c++)
        //        {
        //            row.Cells[c].AddParagraph().AppendText($"Fila {r + 1}, Columna {c + 1}");
        //        }
        //    }

        //    //Como guardar el documento
        //    doc.SaveToFile(nuevoDocumentoPath, FileFormat.Docx);
        //}
        #region Free spire
        //private void CreateWordDocument()
        //{
        //    var texto = TB_TEXT.Text;
        //    //Crear un nuevo documento
        //    Spire.Doc.Document document = new Spire.Doc.Document();

        //    // Añadir una sección
        //    Spire.Doc.Section section = document.AddSection();

        //    // Añadir un encabezado
        //    Spire.Doc.HeaderFooter header = section.HeadersFooters.Header;
        //    Spire.Doc.Table headerTable = header.AddTable();
        //    headerTable.ResetCells(1, 2);

        //    // Añadir texto a la celda izquierda del encabezado
        //    Spire.Doc.TableCell leftCell = headerTable.Rows[0].Cells[0];
        //    Spire.Doc.Documents.Paragraph leftParagraph = leftCell.AddParagraph();
        //    Spire.Doc.Fields.TextRange leftText = leftParagraph.AppendText("Texto a la izquierda");
        //    leftText.CharacterFormat.FontSize = 9;

        //    // Añadir texto a la celda derecha del encabezado
        //    Spire.Doc.TableCell rightCell = headerTable.Rows[0].Cells[1];
        //    Spire.Doc.Documents.Paragraph rightParagraph = rightCell.AddParagraph();
        //    rightParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
        //    Spire.Doc.Fields.TextRange rightText = rightParagraph.AppendText("Texto a la derecha");
        //    rightText.CharacterFormat.FontSize = 9;

        //    // Añadir un título
        //    Spire.Doc.Documents.Paragraph title = section.AddParagraph();
        //    title.AppendText("Poesia de ejemplo");
        //    title.ApplyStyle(BuiltinStyle.Title);

        //    title.Format.BeforeSpacing = 10;
        //    title.Format.AfterSpacing = 20;

        //    // Añadir texto normal
        //    Spire.Doc.Documents.Paragraph para1 = section.AddParagraph();
        //    para1.AppendText(texto);

        //    para1.Format.BeforeSpacing = 20;
        //    para1.Format.AfterSpacing = 10;

        //    // Añadir una imagen
        //    Spire.Doc.Documents.Paragraph imageParagraph = section.AddParagraph();
        //    DocPicture picture = imageParagraph.AppendPicture(System.Drawing.Image.FromFile("C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\Coche Azul.jpeg"));
        //    picture.Width = 100;
        //    picture.Height = 100;

        //    // Guardar el documento
        //    document.SaveToFile("C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\TEST.docx", FileFormat.Docx);


        //}
        #endregion

        //public class CreateWordDocument
        //{
        //    public static void set(String[] args)
        //    {
        //        // Crear un nuevo documento Word
        //        XWPFDocument document = new XWPFDocument();

        //        // Crear un párrafo para el título (título de nivel 1)
        //        XWPFParagraph title = document.CreateParagraph();
        //        title.SetStyle("Heading1"); // Estilo de título de nivel 1
        //        XWPFRun run = title.CreateRun();
        //        run.SetText("Título del Documento");

        //        // Crear párrafos para el contenido
        //        String[] contents = {
        //            "Este es el primer párrafo de contenido.",
        //            "Este es el segundo párrafo de contenido."
        //        };

        //        for (String content = contents)
        //        {
        //            XWPFParagraph paragraph = document.CreateParagraph();
        //            XWPFRun paraRun = paragraph.CreateRun();
        //            paraRun.SetText(content);
        //        }

        //        // Guardar el documento en un archivo
        //        try (FileOutputStream out = new FileOutputStream("documento.docx")) {
        //            document.write(out);
        //            System.out.println("Documento creado satisfactoriamente.");
        //        } catch (Exception e)
        //        {
        //            System.err.println("Error al crear el documento: " + e.GetMessage());
        //        }
        //    }

        //static string GetHeading1FromTemplate(string templatePath)
        //{
        //    // Crear un documento Spire.Doc y cargar la plantilla
        //    Spire.Doc.Document document = new Spire.Doc.Document();
        //    document.LoadFromFile(templatePath);

        //    // Buscar el primer título de nivel 1 en el documento
        //    foreach (Spire.Doc.Section section in document.Sections)
        //    {
        //        foreach (DocumentObject obj in section.Body.ChildObjects)
        //        {
        //            if (obj is Spire.Doc.Documents.Paragraph)
        //            {
        //                Spire.Doc.Documents.Paragraph para = obj as Spire.Doc.Documents.Paragraph;
        //                if (para.StyleName == "Heading1")
        //                {
        //                    // Retornar el texto del título de nivel 1
        //                    return para.Text;
        //                }
        //            }
        //        }
        //    }

        //    // Retornar null si no se encontró ningún título de nivel 1
        //    return null;
        //}

        #region DocX
        //private void CreateDocumentD(string ruta)
        //{

        //    using (DocX document = DocX.Create(ruta))
        //    {
        //        // Agregar un título de nivel 1
        //        document.InsertParagraph("Título del Documento").Heading(HeadingType.Heading1).Alignment = Xceed.Document.NET.Alignment.center;

        //        // Agregar dos párrafos
        //        Xceed.Document.NET.Paragraph p1 = document.InsertParagraph("Este es el primer párrafo.");
        //        Xceed.Document.NET.Paragraph p2 = document.InsertParagraph("Este es el segundo párrafo.");

        //        // Guardar el documento
        //        document.Save();
        //    }



        //}
        #endregion

        #region Open xml
        //public static void CreateSimpleWordDocument(string filePath)
        //{
        //    // Crear el documento de Word
        //    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        //    {
        //        // Agregar un MainDocumentPart al documento
        //        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

        //        // Crear el cuerpo del documento
        //        mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
        //        DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

        //        // Añadir un título
        //        DocumentFormat.OpenXml.Wordprocessing.Paragraph titlePara = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
        //        DocumentFormat.OpenXml.Wordprocessing.Run titleRun = titlePara.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
        //        titleRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Título del Documento"));
        //        titlePara.ParagraphProperties = new ParagraphProperties(new SpacingBetweenLines() { After = "200" }); // Espaciado después del título

        //        // Añadir primer párrafo de texto
        //        DocumentFormat.OpenXml.Wordprocessing.Paragraph para1 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
        //        DocumentFormat.OpenXml.Wordprocessing.Run para1Run = para1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
        //        para1Run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Este es el primer párrafo de texto en el documento."));

        //        // Añadir segundo párrafo de texto
        //        DocumentFormat.OpenXml.Wordprocessing.Paragraph para2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
        //        DocumentFormat.OpenXml.Wordprocessing.Run para2Run = para2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
        //        para2Run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Este es el segundo párrafo de texto en el documento."));
        //    }
        //}
        #endregion

        #region NPOI
        //public static void CreateWordDocument(string filePath)
        //{
        //    // Crear el documento de Word
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //    {
        //        XWPFDocument doc = new XWPFDocument();

        //        XWPFHeader header = doc.CreateHeader(NPOI.WP.UserModel.HeaderFooterType.FIRST);
        //        XWPFParagraph headerPara = header.CreateParagraph();
        //        XWPFRun headerRun = headerPara.CreateRun();
        //        headerRun.SetText("Encabezado del Documento");

        //        XWPFHeader header2 = doc.CreateHeader(NPOI.WP.UserModel.HeaderFooterType.EVEN);
        //        XWPFParagraph headerPara2 = header2.CreateParagraph();
        //        XWPFRun headerRun2 = headerPara2.CreateRun();
        //        headerRun2.SetText("Encabezado del Documento");

        //        // Añadir título
        //        XWPFParagraph titlePara = doc.CreateParagraph();
        //        XWPFRun titleRun = titlePara.CreateRun();
        //        titleRun.SetText("Título del Documento");
        //        titleRun.FontSize = 24; // Tamaño de fuente del título
        //        titleRun.IsBold = true; // Negrita

        //        titlePara.Style = "Título1";

        //        // Añadir párrafo de texto
        //        XWPFParagraph para = doc.CreateParagraph();
        //        XWPFRun paraRun = para.CreateRun();
        //        paraRun.SetText("Este es un párrafo de texto en el documento.");

        //        // Insertar una imagen
        //        //string imagePath = @"C:\ruta\imagen_ejemplo.png";
        //        //XWPFParagraph imgPara = doc.CreateParagraph();
        //        //XWPFRun imgRun = imgPara.CreateRun();
        //        //imgRun.AddPicture(new FileStream(imagePath, FileMode.Open), (int)PictureType.PNG, "imagen_ejemplo.png", Units.ToEMU(300), Units.ToEMU(150));

        //        // Guardar el documento
        //        doc.Write(fs);
        //    }
        //}
        #endregion
    }
}
