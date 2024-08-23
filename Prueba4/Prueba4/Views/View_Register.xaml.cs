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

namespace Prueba4.Views
{
    /// <summary>
    /// Lógica de interacción para View_Register.xaml
    /// </summary>
    public partial class View_Register : UserControl
    {
        public VM_USER3 vm = new VM_USER3();

        public View_Register()
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
