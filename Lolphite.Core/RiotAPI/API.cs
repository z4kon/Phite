using Lolphite.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.RiotAPI
{
    public class API
    {
        private static string? api_key;
        public static string API_Key
        {
            get 
            {
                if(api_key == null)
                {
                    throw new ArgumentNullException(nameof(api_key), "API Key is null! Set the API Key before making requests!");
                }
                return api_key; 
            }
            set { api_key = value; }
        }

        static API()
        {
            API_Key = GetKey.Get();
        }
        
        protected static HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new())
            {
                var response = client.GetAsync(URL);
                response.Wait();

                return response.Result;
            }
        }

        /// <summary>
        /// IMPORTANT: Requires Constants Class to be initialized before!
        /// <para>Important: Three valid routes are: americas, asia, europe.</para>
        /// </summary>
        /// <param name="path"> endpoint path</param>
        /// By default it is set to Europe Region.
        /// <param name="IgnoreRegionalRoute"> 
        /// By default set to true. Certains requests need platform routes, such as EUW1, NA1 or RU,
        /// while others require a regional Route such as americas, asia or europe.
        /// By setting this to false, this method will return a uri using Regional Route.
        /// </param>
        /// <returns></returns>
        protected static string GetURI(string path, bool IgnoreRegionalRoute = true)
        {
            if(IgnoreRegionalRoute)
                return $"https://{Constants.Platform}.api.riotgames.com/{path}&api_key={API_Key}";
            else
            {
                switch(Constants.Region)
                {
                    case RegionRoute.EUROPE:
                        return $"https://europe.api.riotgames.com/{path}&api_key={API_Key}";
                    case RegionRoute.ASIA:
                        return $"https://asia.api.riotgames.com/{path}&api_key={API_Key}";
                    case RegionRoute.AMERICAS:
                        return $"https://americas.api.riotgames.com/{path}&api_key={API_Key}";
                    default:
                        return new Exception("Route was invalid!").ToString();
                }
            }
        }
    }
}
