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
using TheProject.Models;
using TheProject.ViewModels;

namespace TheProject.Views
{
    /// <summary>
    /// Lógica de interacción para V_Login.xaml
    /// </summary>
    public partial class V_Login : UserControl
    {

        VM_VLogin vm = new VM_VLogin();

        public V_Login()
        {
            InitializeComponent();

            DataContext = vm; 
        }


        private void close()
        {
            ModelBase modelBase = new ModelBase();

            // Asignar valores a las propiedades
            modelBase.exercisemodels = new List<ExerciseModel>
            {
                new ExerciseModel { ExerciseType = ExerciseType.Legs, Cardio = 0, Box = 0 , NumberOfExercises = 3, Time = 40   },
                new ExerciseModel { ExerciseType = ExerciseType.Arms, Cardio = 12, Box = 0 , NumberOfExercises = 5, Time = 100   }
            };

                modelBase.BreaksModels = new List<BreaksModel>
            {
                new BreaksModel {  Time = 20 },
                new BreaksModel { Time = 15 }
            };

                modelBase.TasksModels = new List<TasksModel>
            {
                new TasksModel {  Status = TaskStates.Pending , TaskDuration = 400 , Title = "Hacer vitacoras" },
                new TasksModel {  Status = TaskStates.Completed , TaskDuration = 300 , Title = "Ir a clase de manejo"  }
            };

                modelBase.WorkModels = new List<WorkModel>
            {
                new WorkModel {  Title = "Realizar boton de cancelar" , Deadline = 6000, Time = 40, },
                new WorkModel { Title = "Aprender a usar MVVM Tool Kit" , Deadline = 3000, Time = 60, }
            };

                modelBase.SleepModels = new List<SleepModel>
            {
                new SleepModel {  BedTime = TimeOnly.Parse("10pm") , Sleep = (false, ""), WakeUpTime = TimeSpan.FromHours(10) },
                new SleepModel { BedTime = TimeOnly.Parse("10pm") , Sleep = (true, "No me acuerdo"), WakeUpTime = TimeSpan.FromHours(5) }
            };

            var a = new List<ModelBase> { modelBase };

            Tools tools = new Tools();
            tools.SaveToBinaryFile<ModelBase>(a, "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\TheProject\\TheProject\\Controls\\modelbase.dat");

        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            close();
        }
    }
}
