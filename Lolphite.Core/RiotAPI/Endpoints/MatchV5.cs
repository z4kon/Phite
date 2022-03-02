using Lolphite.Core.Model;
using Lolphite.Core.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.RiotAPI.Endpoints
{

    /// <summary>
    /// MatchV5 Gets any match Data in two steps: 1. Perform an api request to get a list of match ids.
    /// 2. With a list of match ids, you can then perform an api request, to get data of every match by its ID.
    /// </summary>
    public class MatchV5 : API
    {
        public MatchV5() : base()
        {

        }

        /// <summary>
        /// Returns a list of strings of matchIDs
        /// </summary>
        /// <param name="count">important, by default it is 20, meaning, it will return player last 20 matchids, but 
        /// feel free, to set it to higher or lower</param>
        /// <returns></returns>
        public static List<string>? GetMatchesList(int count = 20)
        {
            if (Constants.Initialized)
            {
                var path = $"lol/match/v5/matches/by-puuid/{Constants.Puuid}/ids?start=0&count={count}";

                var response = GET(GetURI(path, false));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<string>>(content);
                }
                else return null;
            }
            else throw new Exception("Constants Class Exception - Class was not initialized!");
        }

        public static List<MatchDTO>? GetMatchData(List<string> gameIDs)
        {
            var MatchList = new List<MatchDTO>();

            foreach (var game in gameIDs)
            {
                string path = $"lol/match/v5/matches/{game}?";

                var response = GET(GetURI(path, false));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var match = JsonConvert.DeserializeObject<MatchDTO>(content);
                    MatchList.Add(match);
                }
                else return null;

            }
            return MatchList;

        }
    }
}
