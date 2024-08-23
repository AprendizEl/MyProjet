using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.Models
{
    public partial class M_WContainer : ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string personalityType;


    }
}
