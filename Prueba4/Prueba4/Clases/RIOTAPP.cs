using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prueba4.Clases
{
    internal class RIOTAPP
    {

        private static readonly HttpClient client = new HttpClient();
        public string SummonerName { get; private set; }
        public int SummonerLevel { get; private set; }

        public async Task LoadSummonerDataAsync(string summonerName, string apiKey)
        {
            string url = $"https://americas.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={apiKey}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(responseBody);
            SummonerName = data["name"]?.ToString();
            SummonerLevel = (int)data["summonerLevel"];
        }
    }
}