using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using FontAwesome.WPF;


namespace Prueba4.Clases
{
    public class M_WDP : INotifyPropertyChanged
    {
        private ePageView _pageView;
        private ePageColor _pageColor;
        private Summoner _player;
        private FontAwesomeIcon _icon;

        // Evento que se dispara cuando una propiedad cambia
        public event PropertyChangedEventHandler PropertyChanged;

        // Propiedad para PageView
        public ePageView PageView
        {
            get { return _pageView; }
            set
            {
                if (_pageView != value)
                {
                    _pageView = value;
                    OnPropertyChanged(); // Notifica el cambio
                }
            }
        }

        // Propiedad para PageColor
        public ePageColor PageColor
        {
            get { return _pageColor; }
            set
            {
                if (_pageColor != value)
                {
                    _pageColor = value;
                    OnPropertyChanged(); // Notifica el cambio
                }
            }
        }

        // Propiedad para Player (Summoner)
        public Summoner Player
        {
            get { return _player; }
            set
            {
                if (_player != value)
                {
                    _player = value;
                    OnPropertyChanged(); // Notifica el cambio
                }
            }
        }

        // Propiedad para Icon (FontAwesomeIcon)
        public FontAwesomeIcon Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    OnPropertyChanged(); // Notifica el cambio
                }
            }
        }

        public M_WDP(ePageView pagev = ePageView.DashBoard, ePageColor pagec = ePageColor.Blue, Summoner player = null, FontAwesomeIcon icon = FontAwesomeIcon.Home)
        {
            PageView = pagev;
            PageColor = pagec;
            Player = player;
            Icon = icon;

        }


        // Enums para usar
       

        // Método que dispara el evento PropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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