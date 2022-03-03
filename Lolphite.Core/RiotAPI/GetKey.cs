namespace Lolphite.Core.RiotAPI
{
    /// <summary>
    /// Separate class for getting api key
    /// </summary>
    public class GetKey
    {
        public string? Key { get; set; }

        /// <summary>
        /// Set Path before using!
        /// </summary>
        /// <returns> Riot API KEY</returns>
        public static string Get()
        {
            string path = "";
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
