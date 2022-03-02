﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolphite.Core.Model
{
    public class ChampionMasteryDTO
    {
        public int championId { get; set; }
        public int championLevel { get; set; }
        public int championPoints { get; set; }
        public object? lastPlayTime { get; set; }
        public int championPointsSinceLastLevel { get; set; }
        public int championPointsUntilNextLevel { get; set; }
        public bool chestGranted { get; set; }
        public int tokensEarned { get; set; }
        public string? summonerId { get; set; }
    }
}
