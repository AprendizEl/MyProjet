using Newtonsoft.Json;
using Prueba4.UserControls;
using Prueba4.Views;
using Prueba4.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static DashBoard dashboard;
        public static View_Register register;


        public static Window2 window2;

        public App()
        {

            InitializeComponent();
           
            register = new View_Register();
            dashboard = new DashBoard();
            window2 = new Window2();


        }



    }
}