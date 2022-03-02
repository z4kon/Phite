using Lolphite.Core;
using Lolphite.Core.Model;
using Lolphite.Core.RiotAPI.Endpoints;
using Lolphite.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public static void Main()
        {
            #region Option 1: Initialization, USE OPTIONALLY

            Console.WriteLine("Option 1 - Automatic initialization");
            var summonerDTO = EntryPoint.Initialize(PlatformRoute.EUW1, "Agurin");

            Console.WriteLine("------------------------------------", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine(Constants.Platform);
            Console.WriteLine(Constants.Region);
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Name: {summonerDTO.Name}");
            Console.WriteLine($"Summoner Level: {summonerDTO.SummonerLevel}");
            Console.WriteLine($"PuuID: {summonerDTO.Puuid}");
            Console.WriteLine($"IconID: {summonerDTO.ProfileIconId}");
            Console.WriteLine("------------------------------------");
            #endregion

            #region Option 2: Manual Initialization
            //Console.WriteLine("Option 2 - Manual initialization", Console.ForegroundColor = ConsoleColor.Red);

            //Constants.Platform = PlatformRoute.EUW1;
            //Constants.SummonerName = "Agurin";

            //var SummonerDTO = SummonerV4.GetSummonerByName();

            //Console.WriteLine("------------------------------------");
            //Console.WriteLine(Constants.Platform);
            //Console.WriteLine(Constants.Region);

            //Console.WriteLine("------------------------------------");
            //Console.WriteLine($"Name: {SummonerDTO.Name}");
            //Console.WriteLine($"Summoner Level: {SummonerDTO.SummonerLevel}");
            //Console.WriteLine($"PuuID: {SummonerDTO.Puuid}");
            //Console.WriteLine($"IconID: {SummonerDTO.ProfileIconId}");
            //Console.WriteLine("------------------------------------", Console.ForegroundColor = ConsoleColor.White);

            #endregion

            #region Get Summoner Champion Masteries
            var MasteryDTO = ChampionMasteryV4.GetChampionMasteries();

            foreach(var champMastery in MasteryDTO.ToList())
            {
                Console.WriteLine($"Champion ID: {champMastery.championId}");
                Console.WriteLine($"Champion Level: {champMastery.championLevel}");
                Console.WriteLine($"Champion EXP: {champMastery.championPoints}");
                Console.WriteLine($"Exp until Next Level: {champMastery.championPointsUntilNextLevel}");
                Console.WriteLine("------------------------------------");
            }
            #endregion

            #region Get Summoner League Position Data
            var LeagueEntryDTO = LeagueV4.GetPosition();

            foreach(var entry in LeagueEntryDTO.ToList())
            {
                Console.WriteLine($"Name: { entry.SummonerName}", Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine($"Rank: { entry.FullRank}");
                Console.WriteLine($"LP:   { entry.LeaguePoints}");
                Console.WriteLine($"Wins: { entry.Wins}");
                Console.WriteLine($"Losses: { entry.Losses}");
            }
            #endregion

            #region Get Summoner Match List, and each match data
            var MatchList = MatchV5.GetMatchesList(10);

            var MatchDTO = MatchV5.GetMatchData(MatchList);

            foreach(var match in MatchDTO)
            {
                Console.WriteLine("------------------------------------\n", Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine($"Game ID: {match.info.gameId}");
                Console.WriteLine($"Game Version: {match.info.gameVersion}");

                List<Participant>? participants = match.info.participants as List<Participant>;

                Console.WriteLine("Participant Data:\n");
                foreach(var participant in participants)
                {
                    Console.WriteLine($"Name: {participant.summonerName}");
                    Console.WriteLine($"Champion: {participant.championName}");
                    Console.WriteLine($"Kills: {participant.kills}");
                    Console.WriteLine($"Deaths: {participant.deaths}");
                    Console.WriteLine($"Assists: {participant.assists}");
                    Console.WriteLine($"Total Minions Killed: {participant.totalMinionsKilled}");
                    Console.WriteLine("------------------------------------\n");

                }
            }
            #endregion

        }

    }
}