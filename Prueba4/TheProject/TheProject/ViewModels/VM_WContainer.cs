using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheProject.Models;
using FontAwesome.Sharp;

namespace TheProject.ViewModels
{
    public partial class VM_WContainer : ObservableObject
    {
        public M_WContainer model {  get; set; } = new M_WContainer();

        [ObservableProperty]
        public string pagestate;

        [ObservableProperty]
        public IconChar pageicon;

        public ICommand changepages { get; }

        public ICommand bloqconfig { get; }

        public VM_WContainer()
        {
            model = new M_WContainer();

            Pagestate = model.PageView.ToString();
            Pageicon = model.Icon;
            changepages = new RelayCommand<ePageView>(changepage);
            bloqconfig = new RelayCommand<ePageView>(Configuration);
        }




        public void changepage(ePageView page)
        {
            switch (page)
            {
                case ePageView.DashBoard:

                    model.Icon = IconChar.Home;
                    model.PageView = ePageView.DashBoard;
                    //App.window2.item7.Children.Clear();
                    //App.window2.item7.Children.Add(App.dashboard);

                    break;

                case ePageView.Register:

                    model.Icon = IconChar.Wpforms;
                    model.PageView = ePageView.Register;
                    //App.window2.item7.Children.Clear();
                    //App.window2.item7.Children.Add(App.register);

                    break;

                case ePageView.ViewChamps:

                    model.Icon = IconChar.Home;
                    model.PageView = ePageView.DashBoard;
                    //App.window2.item7.Children.Clear();


                    break;
                case ePageView.Graphic:

                    model.Icon = IconChar.Home;
                    model.PageView = ePageView.DashBoard;
                    //App.window2.item7.Children.Clear();


                    break;

                case ePageView.Stats:

                    model.Icon = IconChar.Home;
                    model.PageView = ePageView.DashBoard;
                    //App.window2.item7.Children.Clear();


                    break;

                case ePageView.GenerateDocument:

                    model.Icon = IconChar.Home;
                    model.PageView = ePageView.DashBoard;
                    //App.window2.item7.Children.Clear();


                    break;

                case ePageView.Information:

                    model.Icon = IconChar.Home;
                    model.PageView = ePageView.DashBoard;
                    //App.window2.item7.Children.Clear();


                    break;
            }

        }

        private static void Configuration(ePageView page)
        {

            if (App.main.G_Gear.Visibility == System.Windows.Visibility.Visible)
            {
                App.main.G_Gear.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                App.main.G_Gear.Visibility = System.Windows.Visibility.Visible;
            }
           


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}