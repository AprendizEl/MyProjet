using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProject.Models;

namespace TheProject.ViewModels
{
    public partial class VM_WContainer : ObservableObject
    {

        public M_WContainer model = new M_WContainer();

        public ObservableCollection<string> PersonalityTypes { get; }

        public IRelayCommand SaveCommand { get; }

        public VM_WContainer()
        {
            SaveCommand = new RelayCommand(SaveUser);
            PersonalityTypes = new ObservableCollection<string>
            {
                "Amigable",
                "Mezquino",
                "Antipático"
            };

            model = new M_WContainer();
            model.age = 60;
            model.Name = "Abulito";
            model.PersonalityType = "Amigable";

        }


        private void SaveUser()
        {
            // Aquí puedes añadir la lógica para guardar la información, por ejemplo, en una base de datos o archivo.
            System.Windows.MessageBox.Show($"Usuario {model.Name} guardado correctamente.");
        }
    }
}