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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;
using System.ComponentModel;

namespace Prueba4.Windows
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window 
    {

        public Window2()
        {
            InitializeComponent();
            


        }



        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161,2,0);
        }

      

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

            item7.Children.Clear();
            item7.Children.Add(new UserControl3());



        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            item7.Children.Clear();
            item7.Children.Add(new UserControl4());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColC.Width = new GridLength(0.5, GridUnitType.Star);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ColC.Width = new GridLength(0, GridUnitType.Star);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            item7.Children.Clear();
            item7.Children.Add(new UserControl1());
        }
    }
}
