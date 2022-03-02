using Lolphite.Core.Model;
using Lolphite.Core.Utilities;
using Newtonsoft.Json;

namespace Lolphite.Core.RiotAPI.Endpoints
{
    public class LeagueV4 : API
    {

        public LeagueV4() : base()
        {

        }
        public static List<LeagueEntryDTO>? GetPosition()
        {
            if (Constants.Initialized)
            {
                string path = $"lol/league/v4/entries/by-summoner/{Constants.SummonerID}?";

                var response = GET(GetURI(path));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(content);
                }
                else
                {
                    return null;
                }
            }
            else throw new Exception("Constants Class Exception - Class was not initialized!");
        }
    }
}
