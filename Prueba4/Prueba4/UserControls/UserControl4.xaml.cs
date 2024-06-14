using LiveCharts.Configurations;
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
using LiveCharts;
using LiveCharts.Helpers;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        
        List<int> filtery = new List<int>();
        List<string> filterx = new List<string>();
        List<Escaleras> listO = new List<Escaleras>();
        List<string> items = new List<string>();

        int MaxN;
        int MinN;
        public ChartValues<int> Results { get; set; }
        public List<string> Labels { get; set; }
        public UserControl4()
        {
            InitializeComponent();

            Results = new ChartValues<int>{ 0, 0, 0 ,0};
  

     
            Labels = new List<string> { "nada", "nada", "nada", "Nada" };

            CB_Fil.ItemsSource = Labels;


            MaxN = 0;
            MinN = 0;

            



            DataContext = this;

            listO = UserControl3.Esca;

            for (int i = 0; listO.Count > i; i++)
            {
                if (listO[i].ID > MaxN)
                {
                    MaxN = listO[i].ID;
                }
            }

            for (int i = 0; listO.Count > i; i++)
            {
                if (listO[i].ID < MinN)
                {
                    MaxN = listO[i].ID;
                }
            }

            CordY();
            MoreLabels();

        }

        public void CordY()
        {
            int Nitem = listO.Count;
            Results.Clear();

            for (int i = 0; i < Nitem; i++)
            {
                Results.Add(listO[i].ID);
                
            }



        }

        public void MoreLabels()
        {
            int Nitem = listO.Count;
            Labels.Clear();

            for (int i = 0; i < Nitem; i++)
            {
                Labels.Add(listO[i].tipo);

            }

            items.AddRange(Labels);
        }

        private void TB_Sech_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Nitem = listO.Count;
            filterx.Clear();
            filtery.Clear();
            MoreLabels();
            CordY();
            if ( TB_Sech.Text != null & TB_Sech.Text != "")
            {
 

                for (int i = 0; i < Nitem; i++)
                {
                    
                    if (TB_Sech.Text == Labels[i])
                    {
                        filtery.Add(listO[i].ID);
                        filterx.Add(listO[i].tipo);
                    }

                }

                Labels.Clear();
                Results.Clear();
                Results.AddRange(filtery);
                Labels.AddRange(filterx);
            }
            else if (TB_Sech.Text == null || TB_Sech.Text == "")
            {
                Results.Clear();
                Labels.Clear();
                MoreLabels();
                CordY();
                filterx.Clear();
                filtery.Clear();
            }


        }
    }
}
