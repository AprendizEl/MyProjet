using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl10.xaml
    /// </summary>
    public partial class UserControl10 : UserControl
    {

        public ObservableCollection<Escaleras> Items
        {
            get { return (ObservableCollection<Escaleras>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<Escaleras>), typeof(UserControl10), new PropertyMetadata(new ObservableCollection<Escaleras >()));


        public UserControl10()
        {
            InitializeComponent();
            Items = new ObservableCollection<Escaleras>
            {
                new Escaleras { ID = 1, name = "Description 1", tipo = "path_to_image1.png" },
                new Escaleras { ID = 2, name = "Description 2", tipo = "path_to_image2.png" }
            };
        }
    }
}
