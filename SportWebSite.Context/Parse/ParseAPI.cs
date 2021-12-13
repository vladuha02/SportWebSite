using SportWebSite.ServiceModels;
using System.Net.Http;
using System.Text.Json;

namespace SportWebSite.Data.Parse
{
    public class ParseAPI
    {
        public TeamInfoModel GetDataFromAPI()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Auth-Token", "d1f0459ed1864396b8bb092886783f72");
            client.BaseAddress = new System.Uri("http://api.football-data.org/v2");

            using (var response = client.GetAsync("v2/teams/19").Result)
            {
                var responseData = response.Content;
                string result = responseData.ReadAsStringAsync().Result;
                var teamInfo = JsonSerializer.Deserialize<TeamInfoModel>(result);

                return teamInfo;
            }
        }
    }
}
