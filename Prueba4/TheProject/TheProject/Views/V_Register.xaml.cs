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
using TheProject.ViewModels;

namespace TheProject.Views
{
    /// <summary>
    /// Lógica de interacción para V_Register.xaml
    /// </summary>
    public partial class V_Register : UserControl
    {
        public V_Register()
        {
            InitializeComponent();
            VM_VRegister vm = new VM_VRegister();
            DataContext = vm;

        }
    }
}
