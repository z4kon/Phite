using Lolphite.Core.Model;
using Lolphite.Core.Utilities;
using Newtonsoft.Json;

namespace Lolphite.Core.RiotAPI.Endpoints
{
    public class ChampionMasteryV4 : API
    {

        public ChampionMasteryV4() : base() {}
        public static List<ChampionMasteryDTO>? GetChampionMasteries()
        {
            if (Constants.Initialized)
            {
                string path = $"lol/champion-mastery/v4/champion-masteries/by-summoner/{Constants.SummonerID}?";

                var response = GET(GetURI(path));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<ChampionMasteryDTO>>(content);
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
