using System.Configuration;
using System.Data;
using System.Windows;
using TheProject.Views;

namespace TheProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static V_DashBoard DashBoard { get; set; }

        public static MainWindow main {  get; set; }

        public static V_ContainerB init {  get; set; }

        public static V_Load loda { get; set; }

        public App()
        {
            InitializeComponent();
            main = new MainWindow();
            DashBoard = new V_DashBoard();
            main.item7.Children.Add( DashBoard );

            loda = new V_Load();



            init = new V_ContainerB();
            init.contentGrid.Children.Add(new V_Register());


            loda.Show();

        }




    }

}
