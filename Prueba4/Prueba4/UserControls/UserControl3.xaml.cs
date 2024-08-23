using Prueba4.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
//using DocumentFormat.OpenXml.Spreadsheet;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {

        public VM_USER3 vm = new VM_USER3 ();

        public UserControl3()
        {
            InitializeComponent();
   
            DataContext = vm;

        }



    }
}
