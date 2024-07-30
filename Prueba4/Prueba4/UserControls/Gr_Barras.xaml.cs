using LiveCharts;
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

namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para Gr_Barras.xaml
    /// </summary>
    /// 
    public partial class Gr_Barras : UserControl
    {


        List<Escaleras> listO = new List<Escaleras>();
        List<string> items = new List<string>();

        int MaxN;
        int MinN;
        public ChartValues<int> Results { get; set; }
        public List<string> Labels { get; set; }


        public Gr_Barras()
        {
            InitializeComponent();
            Results = new ChartValues<int> { 3 , 2 , 5 };

            Labels = new List<string> { "K", "D", "A" };

            MaxN = 0;
            MinN = 0;

            

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

            DataContext = this;
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

        //private void TB_Sech_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    int Nitem = listO.Count;
        //    filterx.Clear();
        //    filtery.Clear();
        //    MoreLabels();
        //    CordY();
        //    if (TB_Sech.Text != null & TB_Sech.Text != "")
        //    {


        //        for (int i = 0; i < Nitem; i++)
        //        {

        //            if (TB_Sech.Text == Labels[i])
        //            {
        //                filtery.Add(listO[i].ID);
        //                filterx.Add(listO[i].tipo);
        //            }

        //        }

        //        Labels.Clear();
        //        Results.Clear();
        //        Results.AddRange(filtery);
        //        Labels.AddRange(filterx);
        //    }
        //    else if (TB_Sech.Text == null || TB_Sech.Text == "")
        //    {
        //        Results.Clear();
        //        Labels.Clear();
        //        MoreLabels();
        //        CordY();
        //        filterx.Clear();
        //        filtery.Clear();
        //    }


        
    }
}
