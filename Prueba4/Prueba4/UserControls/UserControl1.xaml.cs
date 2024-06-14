using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

//using Xceed.Document.NET;
//using Xceed.Words.NET;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl
    {
        List<Escaleras> Esca = new List<Escaleras>();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string text = TBT.Text;
            //// Definir la ruta donde se guardará el documento
            string rutaDocumento = @"C:\Users\eecheto\Desktop\Pruebas\prueba2\Prueba 4\Prueba4\Prueba4\img\Test.docx";

            //    // Crear un nuevo documento
            //    using (var doc = DocX.Create(rutaDocumento))
            //    {
            //        // Agregar un título al documento como encabezado
            //        var titulo = doc.InsertParagraph("¡Hola, mundo!")
            //                        .FontSize(20)
            //                        .Bold()
            //                        .Heading(HeadingType.Heading1) // Aplica el estilo de encabezado
            //                        .Alignment = Xceed.Document.NET.Alignment.center; // Alineación del título

            //        // Agregar un párrafo con texto

            //        // Agregar un párrafo con texto
            //        doc.InsertParagraph(text)
            //            .FontSize(12)
            //            .SpacingAfter(10);

            //        doc.InsertParagraph("Otro párrafo de ejemplo que está debajo del título.")
            //            .FontSize(12)
            //            .SpacingAfter(10);


            //        // Guardar el documento
            //        doc.Save();

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(rutaDocumento, WordprocessingDocumentType.Document))
            {
                // Agregar la parte principal del documento
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                // Agregar estilos al documento
                AddStyles(mainPart);

                // Crear un párrafo con estilo de título 1
                DocumentFormat.OpenXml.Wordprocessing.Paragraph titleParagraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties titleParagraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                ParagraphStyleId titleStyle = new ParagraphStyleId() { Val = "Heading1" }; // Estilo de título 1
                titleParagraphProperties.Append(titleStyle);
                titleParagraph.Append(titleParagraphProperties);

                DocumentFormat.OpenXml.Wordprocessing.Run titleRun = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.Text titleText = new DocumentFormat.OpenXml.Wordprocessing.Text("Título 1");
                titleRun.Append(titleText);
                titleParagraph.Append(titleRun);
                body.Append(titleParagraph);

                // Agregar un párrafo adicional con texto de ejemplo
                DocumentFormat.OpenXml.Wordprocessing.Paragraph contentParagraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new Text("Este es un ejemplo de contenido después del título.")));
                body.Append(contentParagraph);

                // Guardar el documento
                mainPart.Document.Save();
            }

            Console.WriteLine($"Archivo Word creado en: {rutaDocumento}");
        }

        private static void AddStyles(MainDocumentPart mainPart)
        {
            StyleDefinitionsPart stylePart;
            if (mainPart.StyleDefinitionsPart == null)
            {
                stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
                stylePart.Styles = new DocumentFormat.OpenXml.Wordprocessing.Styles();
            }
            else
            {
                stylePart = mainPart.StyleDefinitionsPart;
            }

            Styles styles = stylePart.Styles;

            // Crear el estilo Heading1
            DocumentFormat.OpenXml.Wordprocessing.Style style = new DocumentFormat.OpenXml.Wordprocessing.Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = "Heading1",
                CustomStyle = true
            };
            StyleName styleName = new StyleName() { Val = "Heading 1" };
            BasedOn basedOn = new BasedOn() { Val = "Normal" };
            NextParagraphStyle nextParagraphStyle = new NextParagraphStyle() { Val = "Normal" };
            UIPriority uIPriority = new UIPriority() { Val = 9 };
            DocumentFormat.OpenXml.Wordprocessing.PrimaryStyle primaryStyle = new DocumentFormat.OpenXml.Wordprocessing.PrimaryStyle();
            Rsid rsid = new Rsid() { Val = "00401F4C" };

            style.Append(styleName);
            style.Append(basedOn);
            style.Append(nextParagraphStyle);
            style.Append(uIPriority);
            style.Append(primaryStyle);
            style.Append(rsid);

            DocumentFormat.OpenXml.Wordprocessing.StyleRunProperties styleRunProperties = new DocumentFormat.OpenXml.Wordprocessing.StyleRunProperties();
            DocumentFormat.OpenXml.Wordprocessing.Bold bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
            DocumentFormat.OpenXml.Wordprocessing.Color color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "2E74B5" };
            FontSize fontSize = new FontSize() { Val = "32" }; // Tamaño de fuente en medios puntos (16 pt)

            styleRunProperties.Append(bold);
            styleRunProperties.Append(color);
            styleRunProperties.Append(fontSize);
            style.Append(styleRunProperties);

            styles.Append(style);
        }
    }
}
