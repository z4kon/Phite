using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.Model
{
    public class LeagueEntryDTO
    {
        public string? LeagueId { get; set; }
        public string? QueueType { get; set; }
        public string? Tier { get; set; }
        public string? Rank { get; set; }
        public string? SummonerId { get; set; }
        public string? SummonerName { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool Veteran { get; set; }
        public bool Inactive { get; set; }
        public bool FreshBlood { get; set; }
        public bool Hotstreak { get; set; }

        public string FullRank
        { get { return $"{Tier} {Rank}"; } }
    }
}
