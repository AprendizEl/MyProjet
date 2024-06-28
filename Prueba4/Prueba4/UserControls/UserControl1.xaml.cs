using ClosedXML.Excel;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Wordprocessing;
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

        public UserControl1()
        {


            InitializeComponent();

            CargarPrimerasDosColumnasDesdeExcel();
        }

        private void CargarPrimerasDosColumnasDesdeExcel()
        {

            string filePath = "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\Prueba4\\img\\TEst2.xlsx";

          
            DataTable dataTable = new DataTable();

            
            using (var workbook = new XLWorkbook(filePath))
            {
                // Selecciona la hoja
                var worksheet = workbook.Worksheet(1);

                // Obtiene el rango usado de la hoja
                var usedRange = worksheet.RangeUsed();
                if (usedRange != null)
                {
                    // Obtiene la cantidad de filas y columnas usadas
                    int rowCount = usedRange.RowCount();
                    int colCount = usedRange.ColumnCount();

                    // Agrega columnas al DataTable
                    for (int c = 1; c <= colCount; c++)
                    {
                        dataTable.Columns.Add("Columna" + c, typeof(string));
                    }

                    // Recorre las filas usadas en la hoja
                    for (int r = 1; r <= rowCount; r++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int c = 1; c <= colCount; c++)
                        {
                            dataRow["Columna" + c] = worksheet.Cell(r, c).Value.ToString();
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }

            
            ExcelGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}