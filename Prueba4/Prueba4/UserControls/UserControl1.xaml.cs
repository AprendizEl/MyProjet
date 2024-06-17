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
            string filePath = @"C:\Users\jugad\OneDrive\Escritorio\MyProjet\Prueba4\Prueba4\img\Test.docx";

            //    // Crear un nuevo documento
            //    using (var doc = DocX.Create(rutaDocumento))
            //    {
            //        // Agregar un título al documento como encabezado
            //        var titulo = doc.InsertParagraph("¡Hola, mundo!")
            //                        .FontSize(20)
            //                        .Bold()
            //                        .Heading(HeadingType.Heading1) // Aplica el estilo de encabezado
            //                        .Alignment = Xceed.Document.NET.Alignment.center; // Alineación del título

            //        // Agregar un párrafo con texto DocumentFormat.OpenXml.Wordprocessing.

            //        // Agregar un párrafo con texto
            //        doc.InsertParagraph(text)
            //            .FontSize(12)
            //            .SpacingAfter(10);

            //        doc.InsertParagraph("Otro párrafo de ejemplo que está debajo del título.")
            //            .FontSize(12)
            //            .SpacingAfter(10);


            //        // Guardar el documento
            //        doc.Save();
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                // Crear marcador para simular el título expandible
                DocumentFormat.OpenXml.Wordprocessing.Paragraph titleParagraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                    new ParagraphProperties(
                        new Justification() { Val = JustificationValues.Center })
                );
                DocumentFormat.OpenXml.Wordprocessing.Run titleRun = new DocumentFormat.OpenXml.Wordprocessing.Run(new Text("Título expandible"));
                titleParagraph.AppendChild(titleRun);

                // Agregar marcador que contiene el contenido expandible
                DocumentFormat.OpenXml.Wordprocessing.Paragraph contentParagraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.Run contentRun = new DocumentFormat.OpenXml.Wordprocessing.Run(new Text("Contenido que puede expandirse o contraerse."));
                contentParagraph.AppendChild(contentRun);

                // Marcar el contenido como oculto
                contentParagraph.AppendChild(new RunProperties(
                    new Vanish()
                ));

                body.AppendChild(titleParagraph);
                body.AppendChild(contentParagraph);

                mainPart.Document.Save();
            }
        }

    }
}

