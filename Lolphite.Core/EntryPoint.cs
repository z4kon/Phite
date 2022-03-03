using Lolphite.Core.Model;
using Lolphite.Core.RiotAPI;
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
        /// <summary>
        /// Entry Point of this library.
        /// </summary>
        /// <param name="route"> Define the platform in which the player you search is</param>
        /// <param name="SummonerName"></param>
        /// <param name="API_KEY">
        /// To save time, have fun, or build a small app, you pass api key directly
        /// through this parameter, although this is not recommended. Hard-Coding an api key
        /// in the code poses security risks to the key.
        /// Especially, if you plan to publish your app to any public repository.
        /// Consider using GetKey Class.
        /// </param>
        /// <returns></returns>
        public static SummonerDTO? Initialize(PlatformRoute route, string SummonerName, string API_KEY = null)
        {
            if (!String.IsNullOrEmpty(API_KEY))
                GetKey.Key = API_KEY;
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
