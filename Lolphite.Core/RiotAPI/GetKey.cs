namespace Lolphite.Core.RiotAPI
{
    /// <summary>
    /// Separate class for getting api key
    /// </summary>
    public class GetKey
    {
        public static string? Key { get; set; }

        /// <summary>
        /// Set Path before using!
        /// </summary>
        /// <returns> Riot API KEY</returns>
        public static string Get()
        {
            if(string.IsNullOrEmpty(Key))
            {
                string path = "";
                StreamReader sr = new StreamReader(path);
                Key = sr.ReadToEnd();
                return Key;
            }
            return Key;
        }
    }
}
