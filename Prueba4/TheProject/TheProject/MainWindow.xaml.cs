using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheProject.ViewModels;
using TheProject.Views;

namespace TheProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VM_WContainer();
            


        }

        //private void SlideLeft_Click(object sender, RoutedEventArgs e)
        //{
        //    var storyboard = (Storyboard)FindResource("SlideLeft");
        //    storyboard.Begin(MainContent);

        //    var w = new V_ContainerB();
        //    w.Show();
        //}

        //private void SlideRight_Click(object sender, RoutedEventArgs e)
        //{
        //    var storyboard = (Storyboard)FindResource("SlideRight");
        //    storyboard.Begin(MainContent);
        //}

        //private void SlideUp_Click(object sender, RoutedEventArgs e)
        //{
        //    var storyboard = (Storyboard)FindResource("SlideUp");
        //    storyboard.Begin(MainContent);
        //}

        //private void SlideDown_Click(object sender, RoutedEventArgs e)
        //{
        //    var storyboard = (Storyboard)FindResource("SlideDown");
        //    storyboard.Begin(MainContent);
        //}
    }
}