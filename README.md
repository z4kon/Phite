# Phite
A Simple RiotAPI C# implementation. As of now, supports only League of Legends general endpoints.

### Phite Goals
- Ease of Use. Code is very simple. The project was done during spare time for learning purposes, beware of errors or non-sense.


## Using the library 
### 1. Before using the library in any way create a text file, for example Key.txt or apikey.txt anywhere in your pc
### 2. Register on **[Riot Developers API](https://developer.riotgames.com/)**. Here you will get a development Riot API Key.
### 3. Copy the key, and put it inside your text file. Copy the path of the text file, and in GetKey class set the correct path to your api key text file.


### Depending on how you may plan to use the library, there are two main ways.
### Option 1 - Easy way.
~~~C#
// Include Lolphite.Core
using Lolphite.Core

// Use library entry point, to initialize it.
var summonerDTO = EntryPoint.Initialize(PlatformRoute.EUW1, "Agurin");

// example
Console.WriteLine($"Name:   {summonerDTO.Name}" +
                  $"Level:  {summonerDTO.SummonerLevel}" +
                  $"Puuid:  {summonerDTO.Puuid}" +
                  $"IconID: {summonerDTO.ProfileIconId}");

/* 
EntryPoint initializes Constants Class 
which is used troughout the library, especially for making api requests
*/

// After initializing, use other endpoints. These endpoints get the data of summoner defined in summonerDTO earlier.

var MasteryDTO = ChampionMasteryV4.GetChampionMasteries();
var LeagueEntryDTO = LeagueV4.GetPosition();
var MatchList = MatchV5.GetMatchesList(20); // 20 can be changed to higher or lower
var MatchDTO = MatchV5.GetMatchData(MatchList); // Before getting match data, make request to get Match List
~~~

### Option 2 - Manual way.
~~~C#
// Include Lolphite.Core
using Lolphite.Core

// Manually initialize main properties
Constants.Platform = PlatformRoute.EUW1;
Constants.SummonerName = "Agurin";

// Call GetSummonerByName(), which will initialize remaining properties in Constants Class
var summonerDTO = SummonerV4.GetSummonerByName();

// example
Console.WriteLine($"Name:   {summonerDTO.Name}" +
                  $"Level:  {summonerDTO.SummonerLevel}" +
                  $"Puuid:  {summonerDTO.Puuid}" +
                  $"IconID: {summonerDTO.ProfileIconId}");


// After initializing, use other endpoints. These endpoints get the data of summoner defined in summonerDTO earlier.

var MasteryDTO = ChampionMasteryV4.GetChampionMasteries();
var LeagueEntryDTO = LeagueV4.GetPosition();
var MatchList = MatchV5.GetMatchesList(20); // 20 can be changed to higher or lower
var MatchDTO = MatchV5.GetMatchData(MatchList); // Before getting match data, make request to get Match List
~~~


## Potential
### This library is more or less enough for basic applications. Here a simple one i created using WPF, during spare time to test out the library.

- A search window

![Search](/Tests/demo/logindemo.png)

- after pressing search button, app gathers various data, and performs some calculations (some may be wrong or off a bit)

![Search](/Tests/demo/ProfileDemo.png)

- A Match List of 20 games, by pressing on any match, a statistics window opens up, which has couple demos on how data could be used
  calculations are/may be bit off, aswell as the design, as the whole app was built just for testing the api and the library for learning and fun.

![Search](/Tests/demo/statsdemo.png)



