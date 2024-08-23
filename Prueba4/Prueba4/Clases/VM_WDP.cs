using DocumentFormat.OpenXml.EMMA;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using FontAwesome.WPF;

namespace Prueba4.Clases
{
    public class VM_WDP : INotifyPropertyChanged
    {
        public static M_WDP model;

        public VM_WDP()
        {
            model = new M_WDP();

            
            changepages = new Command<ePageView>(changepage);
        }


        public static ICommand changepages { get; private set; }



        public static void changepage(ePageView page)
        {
            switch (page)
            {
                case ePageView.DashBoard:

                    model.Icon = FontAwesomeIcon.Home;
                    model.PageView = ePageView.DashBoard;
                    App.window2.item7.Children.Clear();
                    App.window2.item7.Children.Add(App.dashboard);

                    break;

                case ePageView.Register:

                    model.Icon = FontAwesomeIcon.Wpforms;
                    model.PageView = ePageView.Register;
                    App.window2.item7.Children.Clear();
                    App.window2.item7.Children.Add(App.register);

                    break;

                case ePageView.ViewChamps:

                    model.Icon = FontAwesomeIcon.Home;
                    model.PageView = ePageView.DashBoard;
                    App.window2.item7.Children.Clear();


                    break;
                case ePageView.Graphic:

                    model.Icon = FontAwesomeIcon.Home;
                    model.PageView = ePageView.DashBoard;
                    App.window2.item7.Children.Clear();


                    break;

                case ePageView.Stats:

                    model.Icon = FontAwesomeIcon.Home;
                    model.PageView = ePageView.DashBoard;
                    App.window2.item7.Children.Clear();


                    break;

                case ePageView.GenerateDocument:

                    model.Icon = FontAwesomeIcon.Home;
                    model.PageView = ePageView.DashBoard;
                    App.window2.item7.Children.Clear();


                    break;

                case ePageView.Information:

                    model.Icon = FontAwesomeIcon.Home;
                    model.PageView = ePageView.DashBoard;
                    App.window2.item7.Children.Clear();


                    break;
            }

        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
