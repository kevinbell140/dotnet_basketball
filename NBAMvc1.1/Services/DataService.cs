using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace NBAMvc1._1.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient client)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri("https://api.fantasydata.net/v3/nba/stats/json/");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b841ecb4f4ee4e70a93858ea65ba2bfa");
        }

        public async Task<List<Team>> FetchTeamsAsync()
        {
            var response = await _httpClient.GetAsync("teams");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<Team>>();
            return result;
        }

        public async Task<List<Player>> FetchPlayersAsync()
        {
            var response = await _httpClient.GetAsync("players");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<Player>>();
            return result;
        }

        public async Task<List<PlayerSeasonStats>> FetchSeasonStatsAsync()
        {
            var response = await _httpClient.GetAsync("PlayerSeasonStats/2019");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<PlayerSeasonStats>>();
            return result;
        }

        public async Task<List<Standings>> FetchStandingsAsync()
        {
            var response = await _httpClient.GetAsync("standings/2019");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<Standings>>();
            return result;
        }

        public async Task<List<Game>> FetchGamesAsync()
        {
            var response = await _httpClient.GetAsync("games/2019");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //there were null date time values in response string today, the settings ignored the exception
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var games = JsonConvert.DeserializeObject<List<Game>>(responseString, settings);
            return games;
        }

        public async Task<List<Game>> FetchGamesPostAsync()
        {
            var response = await _httpClient.GetAsync("games/2019POST");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //there were null date time values in response string today, the settings ignored the exception
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var games = JsonConvert.DeserializeObject<List<Game>>(responseString, settings);
            return games;
        }

        public async Task<List<PlayerGameStats>> FetchGameStatsAsync(string date)
        {
            var response = await _httpClient.GetAsync("PlayerGameStatsByDate/" + date);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<PlayerGameStats>>();
            return result;
        }

        public async Task<List<News>> FetchNewsAsync()
        {
            var response = await _httpClient.GetAsync("news");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<News>>();
            return result;
        }
    }
}
 

