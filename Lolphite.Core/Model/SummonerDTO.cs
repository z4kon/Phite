using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.Model
{
    public class SummonerDTO
    {
        public string? Id { get; set; }
        public string? AccountId { get; set; }
        public string? Puuid { get; set; }
        public string? Name { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
    }
}
