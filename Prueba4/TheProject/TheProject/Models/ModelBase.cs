using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.Models
{
    public partial class ModelBase : ObservableObject
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
        public List<SleepModel> sleepModels = new List<SleepModel>();


    }


    public partial class ExerciseModel : ObservableObject
    {
        [ObservableProperty]
        private ExerciseType _exerciseType;

        [ObservableProperty]
        private float _numberOfExercises;

        [ObservableProperty]
        private int _time;

        [ObservableProperty]
        private int _cardio;

        [ObservableProperty]
        private int _box;
    }

    public partial class SleepModel : ObservableObject
    {
        [ObservableProperty]
        private TimeOnly _bedTime;

        [ObservableProperty]
        private TimeSpan _wakeUpTime;

        [ObservableProperty]
        private (bool, string) _sleep;
    }

    public partial class BreaksModel : ObservableObject
    {
        [ObservableProperty]
        private int _time;
    }

    public partial class TasksModel : ObservableObject
    {
        [ObservableProperty]
        private int _taskDuration;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private TaskStates _status;
    }

    public partial class WorkModel : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _time;

        [ObservableProperty]
        private int _deadline;
    }

    public enum ExerciseType
    {
        Legs,
        Arms,
        Abs,
        Back
    }

    public enum TaskStates
    {
        Pending,
        InProgress,
        Completed
    }


}
