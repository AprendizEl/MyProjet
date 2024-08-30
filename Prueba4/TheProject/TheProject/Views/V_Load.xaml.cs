using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TheProject.ViewModels;

namespace TheProject.Views
{
    /// <summary>
    /// Lógica de interacción para V_Load.xaml
    /// </summary>
    public partial class V_Load : Window
    {
        VM_VLoad vm = new VM_VLoad();

       
        public V_Load()
        {
            InitializeComponent();
            DataContext = vm;

        }

    }
}



