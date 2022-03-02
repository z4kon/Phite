using Lolphite.Core.Model;
using Lolphite.Core.Utilities;
using Newtonsoft.Json;

namespace Lolphite.Core.RiotAPI.Endpoints
{

    /// <summary>
    /// IMPORTANT: SummonerV4 serves as a great entry point for the rest of the library, because it holds important properties such as: PUUID, Encrypted
    /// Summoner ID. Therefore, a good practice is to first perform an api request to this class, initialize the Constants Class, and continue
    /// using the rest of the library.
    /// </summary>
    public class SummonerV4 : API
    {
        public SummonerV4() : base()
        {
        }
        public static SummonerDTO? GetSummonerByName()
        {
            if (Constants.Initialized)
            {
                string path = $"lol/summoner/v4/summoners/by-name/{Constants.SummonerName}?";

                var response = GET(GetURI(path));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var Summoner = JsonConvert.DeserializeObject<SummonerDTO>(content);
                    Constants.Puuid = Summoner.Puuid;
                    Constants.SummonerID = Summoner.Id;
                    return Summoner;
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
