using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FontAwesome.Sharp;
using System.Threading.Tasks;

namespace TheProject.Models
{
    public partial class M_WContainer : ObservableObject
    {
        [ObservableProperty]
        private ePageView _pageView;

        [ObservableProperty]
        private ePageColor _pageColor;

        [ObservableProperty]
        private M_Summoner _player;

        [ObservableProperty]
        private IconChar _icon;      

        public M_WContainer(ePageView pagev = ePageView.DashBoard, ePageColor pagec = ePageColor.Blue, M_Summoner player = null, IconChar icon = IconChar.Home)
        {
            PageView = pagev;
            PageColor = pagec;
            Player = player;
            Icon = icon;

        }
    }

    public enum ePageView
    {
        DashBoard,
        Register,
        Stats,
        ViewChamps,
        Graphic,
        GenerateDocument,
        Information
    }

    public enum ePageColor
    {
        Blue,
        Green,
        Purple,
        Red
    }

}