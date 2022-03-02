using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.Utilities
{
    public enum PlatformRoute
    {
        BR1,
        EUN1,
        EUW1,
        JP1,
        KR,
        LA1,
        LA2,
        NA1,
        OC1,
        TR1,
        RU
    }

    public enum RegionRoute
    {
        AMERICAS,
        ASIA,
        EUROPE
    }

    public static class RouteUtils
    {
        /// <summary>
        /// Converts the PlatformRoute into its corresponding RegionalRoute.
        /// </summary>
        /// <param name="value">This, the PlatformRoute to convert.</param>
        /// <remarks> 
        /// <para>This code was taken from MingweiSamuel.Camille Library.</para>
        /// 
        /// <para>
        /// SEE SOURCE CODE: https://github.com/MingweiSamuel/Camille
        /// </para>
        /// 
        /// <para>
        /// SEE LICENSE: https://github.com/MingweiSamuel/Camille/blob/release/3.x.x/LICENSE.txt
        /// </para>
        /// </remarks>
        /// 
        /// <returns>AMERICAS, ASIA, or EUROPE. Will not return SEA which is only used for LoR.</returns>
        public static RegionRoute? ToRegional(this PlatformRoute? value)
        {
            switch (value)
            {
                case PlatformRoute.BR1:
                case PlatformRoute.LA1:
                case PlatformRoute.LA2:
                case PlatformRoute.NA1:
                case PlatformRoute.OC1:
                    return RegionRoute.AMERICAS;

                case PlatformRoute.JP1:
                case PlatformRoute.KR:
                    return RegionRoute.ASIA;

                case PlatformRoute.EUN1:
                case PlatformRoute.EUW1:
                case PlatformRoute.RU:
                case PlatformRoute.TR1:
                    return RegionRoute.EUROPE;
            }
            throw new ArgumentException($"Unexpected PlatformRoute value: {value}.");
        }
    }
}
