using Lolphite.Core.Model;
using Lolphite.Core.RiotAPI.Endpoints;
using Lolphite.Core.Utilities;

namespace Lolphite.Core
{
    /// <summary>
    /// This class is OPTIONAL. You can use it to lower the chance of unexpected exceptions or any errors, because it follows
    /// the correct path of initializing this library certain classes properly.
    /// </summary>
    /// 
    /// <remarks>
    /// Using this or not, make sure to set the correct path in GetKey class of your API key
    /// </remarks>
    public class EntryPoint
    {
        public static SummonerDTO? Initialize(PlatformRoute route, string SummonerName)
        {
            // Step 0 - Important, before proceeding using this library in any way
            // go to GetKey Class, and set the CORRECT path to your api key, otherwise none of this will work.

            // Step 1 - initialize Constants Class Property "Region" to start making api requests
            // and Property "SummonerName" to make your first request.
            Constants.Platform = route;
            Constants.SummonerName = SummonerName;

            // Step 2 - Perform SummonerV4 request, which will set Other Constants Class properties "Puuid" and "SummonerID".
            var Summoner = SummonerV4.GetSummonerByName();
            return Summoner;

            // Step 3 - Class library is ready to be used fully.
        }
    }
}
