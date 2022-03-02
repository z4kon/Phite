using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.Utilities
{

    /// <summary>
    /// Important: Constants Class holds data, that will remain static/unchanging throughout runtime. It is important, that this should be
    /// initialized as soon as possible before proceeding using the rest of the library, as multiple classes may or are dependant on this class properties.
    /// A good practice is to perform a SummonerV4 Request, because that holds all the necessary data, to initialize Constants Class properties.
    /// Region can be initialized in any way, depending on the architecture, but it is the most important property, because RiotAPI class is 
    /// directly dependant on Region Property, for making API requests, Therefore a good practice is 1. Initialize Region, 2. Perform SummonerV4
    /// api request and initialize others.
    /// </summary>
    public class Constants
    {

        ///<summary>
        /// For Exception Handling, as this class is required to be initialized before using the library.
        ///</summary> 
        public static bool Initialized
        {
            get
            {
                if (string.IsNullOrEmpty(Platform.ToString()) &&
                   string.IsNullOrEmpty(summonerName))
                    return false;
                return true;
            }
        }

        private static PlatformRoute? platform = null;
        public static PlatformRoute? Platform
        {
            get
            {
                if (!string.IsNullOrEmpty(platform.ToString()))
                    return platform;
                else throw new ArgumentNullException(nameof(platform), "Region Was null! Set Region");
            }
            set
            {
                platform = value;
            }
        }

        public static RegionRoute? Region => RouteUtils.ToRegional(Platform);

        private static string? puuid;
        public static string Puuid
        {
            get
            {
                if (!string.IsNullOrEmpty(puuid))
                    return puuid;
                else throw new ArgumentNullException(nameof(puuid), "Puuid Was null! Set Puuid");
            }
            set
            {
                puuid = value;
            }
        }


        private static string? summonerID;
        public static string SummonerID
        {
            get
            {
                if (!string.IsNullOrEmpty(summonerID))
                    return summonerID;
                else throw new ArgumentNullException(nameof(summonerID), "SummonerID Was null! Set SummonerID");
            }
            set
            {
                summonerID = value;
            }
        }

        private static string? summonerName;
        public static string SummonerName
        {
            get
            {
                if (!string.IsNullOrEmpty(summonerName))
                    return summonerName;
                else throw new ArgumentNullException(nameof(summonerName), "SummonerName Was null! Set SummonerName");
            }
            set
            {
                summonerName = value;
            }
        }
    }
}
