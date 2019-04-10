using NBAMvc1._1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace NBAMvc1._1.Services
{
    public class DataService
    {
        public async Task<List<Team>> FetchTeams()
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/scores/json/teams?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var teamList = JsonConvert.DeserializeObject<List<Team>>(responseString);

            return teamList;

        }
        public async Task<List<Player>> FetchPLayers()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/scores/json/Players?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var playersList = JsonConvert.DeserializeObject<List<Player>>(responseString);

            return playersList;
        }

        public async Task<List<PlayerSeasonStats>> FetchStats()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/stats/json/PlayerSeasonStats/2019?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var statsList = JsonConvert.DeserializeObject<List<PlayerSeasonStats>>(responseString);

            return statsList;
        }

        public async Task<List<Standings>> FetchStandings()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/stats/json/Standings/2019?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var standings = JsonConvert.DeserializeObject<List<Standings>>(responseString);

            return standings;
        }

        public async Task<List<Game>> FetchGames()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/stats/json/Games/2019?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var games = JsonConvert.DeserializeObject<List<Game>>(responseString);

            return games;
        }

        public async Task<List<PlayerGameStats>> FetchGamesStats(string date)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/stats/json/PlayerGameStatsByDate/" + date + "?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var stats = JsonConvert.DeserializeObject<List<PlayerGameStats>>(responseString);

            return stats;
        }


        public async Task<List<News>> FetchNews()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fe634e9053b84b238854e656b43138e6");

            var uri = "https://api.fantasydata.net/v3/nba/stats/json/News" + "?" + queryString;

            var response = await client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var news = JsonConvert.DeserializeObject<List<News>>(responseString);

            return news;
        }

    }
}
 

