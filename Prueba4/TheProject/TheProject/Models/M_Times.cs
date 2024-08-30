using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TheProject.Models
{
    public partial class RutineModel : ObservableObject
    {
        [ObservableProperty]
        public List<ExerciseModel> exercisemodels = new List<ExerciseModel>();

        [ObservableProperty]
        public List<BreaksModel> breaksModels = new List<BreaksModel>();

        [ObservableProperty]
        public List<TasksModel> tasksModels = new List<TasksModel>();

        [ObservableProperty]
        public List<WorkModel> workModels = new List<WorkModel>();

        [ObservableProperty]
        public SleepModel sleepModel = new SleepModel();


    }


    public partial class Day : ObservableObject
    {
        [ObservableProperty]
        private int number;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private RutineModel rutine;

        public Day(int number, string name, RutineModel rutines)
        {
            Number = number;
            Name = name;
            if ( rutines != null)
            {
                rutine = rutines;
            }
            else
            {
                RutineModel modelBase = new RutineModel();

                // Asignar valores a las propiedades
                modelBase.exercisemodels = new List<ExerciseModel>
                {
                    new ExerciseModel { ExerciseType = ExerciseType.Legs, Cardio = 0, Box = 0 , NumberOfExercises = 0, Time = 0}
                };

                modelBase.BreaksModels = new List<BreaksModel>
                {
                    new BreaksModel {  Time = 0 }
                };

                modelBase.TasksModels = new List<TasksModel>
                {
                    new TasksModel {  Status = TaskStates.Completed , TaskDuration = 0 , Title = "No reportado" }
                };

                modelBase.WorkModels = new List<WorkModel>
                {
                    new WorkModel {  Title = "No reportado" , Deadline = 0, Time = 0, },
                    new WorkModel { Title = "No reportado" , Deadline = 0, Time = 0, }
                };

                modelBase.SleepModel = new SleepModel
                {  
                    BedTime = TimeOnly.Parse("1am"), Sleep = (false, ""), WakeUpTime = TimeSpan.FromHours(10)              
                };

                rutine =  modelBase ;
            }
            
        }
    }


    public partial class Week : ObservableObject
    {
        [ObservableProperty]
        private int number;

        [ObservableProperty]
        private ObservableCollection<Day> days;

        public Week(int number)
        {
            Number = number;
            Days = new ObservableCollection<Day>();
        }

        public void AddDay(Day day)
        {
            Days.Add(day);
        }
    }

    public partial class Month : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ObservableCollection<Week> weeks;

        public Month(string name)
        {
            Name = name;
            Weeks = new ObservableCollection<Week>();
        }

        public void AddWeek(Week week)
        {
            Weeks.Add(week);
        }
    }


    public partial class Year : ObservableObject
    {
        [ObservableProperty]
        private int number;

        [ObservableProperty]
        private ObservableCollection<Month> months;

        public Year(int number)
        {
            Number = number;
            Months = new ObservableCollection<Month>();
        }

        public void AddMonth(Month month)
        {
            Months.Add(month);
        }
    }


}
