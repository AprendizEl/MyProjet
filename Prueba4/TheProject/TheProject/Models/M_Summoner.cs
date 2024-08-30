using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.Models
{
    public partial class M_Summoner : ObservableObject
    {

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int level;

        [ObservableProperty]
        private LeagueRank rank;

        [ObservableProperty]
        private LeagueRegion region;

        [ObservableProperty]
        private string phrase;



        public M_Summoner build( M_Summoner m)
        {
            var newsu = new M_Summoner();

            newsu.name = m.Name;
            newsu.level = m.Level;
            newsu.rank = m.Rank;
            newsu.region = m.Region;
            newsu.phrase = m.Phrase;

            return newsu;
        }


    }

    public enum LeagueRank
    {
        Unranked,
        Iron,
        Bronze,
        Silver,
        Gold,
        Platinum,
        Diamond,
        Master, 
        Grandmaster, 
        Challenger
    }

    public enum LeagueRegion
    {
        NA,       // North America
        EUW,      // Europe West
        EUNE,     // Europe Nordic & East
        LAN,      // Latin America North
        LAS,      // Latin America South
        BR,       // Brazil
        KR,       // Korea
        JP,       // Japan
        OCE,      // Oceania
        RU,       // Russia
        TR        // Turkey
    }
}
