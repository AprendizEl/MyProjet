using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheProject.ViewModels
{
    class VM_VLogin
    {

        public ICommand Start {  get;}


        public VM_VLogin()
        {

            Start = new RelayCommand(openpage);

        }


        public void openpage()
        {


            App.main.Show();

            App.init.Close();



        }




    }
}
