using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Prueba4
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string apiKey = "RGAPI-b5a96238-888c-4836-a5f8-42ddd4a84145";
        private static readonly string summonerName = "Notplayerclassic";
        private static readonly string region = "na1"; // e.g., "na1", "euw1", etc.

        static async Task Main(string[] args)
        {
            var summoner = await GetSummonerInfo(summonerName, region);
            if (summoner != null)
            {
                Console.WriteLine($"Summoner Name: {summoner.Name}");
                Console.WriteLine($"Summoner Icon ID: {summoner.ProfileIconId}");
                string iconUrl = $"https://ddragon.leagueoflegends.com/cdn/11.1.1/img/profileicon/{summoner.ProfileIconId}.png";
                Console.WriteLine($"Icon URL: {iconUrl}");
                // Optionally, you can download and display the icon image using the ProfileIconId
                // DownloadImage(iconUrl);
            }
            else
            {
                Console.WriteLine("Summoner not found.");
            }
        }

        private static async Task<Summoner> GetSummonerInfo(string summonerName, string region)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
                var response = await client.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Summoner>(json);
                }
                else
                {
                    return null;
                }
            }
        }

        public class Summoner
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("accountId")]
            public string AccountId { get; set; }

            [JsonProperty("puuid")]
            public string Puuid { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("profileIconId")]
            public int ProfileIconId { get; set; }

            [JsonProperty("revisionDate")]
            public long RevisionDate { get; set; }

            [JsonProperty("summonerLevel")]
            public int SummonerLevel { get; set; }
        }
    }
}