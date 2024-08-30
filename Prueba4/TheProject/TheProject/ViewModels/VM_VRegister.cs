using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Forms;
using System.Windows.Input;
using TheProject.Models;

namespace TheProject.ViewModels
{
    public partial class VM_VRegister : ObservableObject
    {
        public M_Summoner summoner { get; set; } = new M_Summoner();

        public List<LeagueRank> ranks { get; set; }

        public List<LeagueRegion> regions { get; set; }

        public List<M_Summoner> summoners { get; set; } = new List<M_Summoner>();

        public M_Summoner summonerD { get; set; } = new M_Summoner();

        public ICommand save { get; }

        public ICommand saveAll { get; }

        public VM_VRegister()
        {
            summoner.Name = "Example";
            summoner.Level = 0;
            summoner.Region = LeagueRegion.TR;
            summoner.Rank = LeagueRank.Unranked;
            summoner.Phrase = "I am the best";

            ranks = Enum.GetValues(typeof(LeagueRank)).Cast<LeagueRank>().ToList();
            regions = Enum.GetValues(typeof(LeagueRegion)).Cast<LeagueRegion>().ToList();

            save = new RelayCommand(OnSaveSummoner);

            saveAll = new RelayCommand(OnSaveAll);



        }

        private void setD()
        {
            summoner.Name = "Example";
            summoner.Level = 0;
            summoner.Region = LeagueRegion.TR;
            summoner.Rank = LeagueRank.Unranked;
            summoner.Phrase = "I am the best";
            

        }

        private void OnSaveSummoner()
        {

            summoners.Add(new M_Summoner().build(summoner));
            setD();
        }

        private void OnSaveAll()
        {
            Tools tools = new Tools();
            var loadedSummoners = tools.LoadFromBinaryFile<M_Summoner>("C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\TheProject\\TheProject\\Controls\\summoners.dat");

            tools.SaveToBinaryFile(summoners, "C:\\Users\\eecheto\\Desktop\\MyProjet\\Prueba4\\TheProject\\TheProject\\Controls\\summoners.dat");
        }

        public static async Task ContarConEsperaAsync()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(5000); // Espera 5000 milisegundos (5 segundos) de manera asíncrona
            }
        }

        public static async Task tem()
        {

            var s = ContarConEsperaAsync();


            await s;

            MessageBox.Show("finish");
        }


    }
}
