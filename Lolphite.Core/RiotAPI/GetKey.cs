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
            if(string.IsEmptyOrNull(Key))
            {
                string path = "";
                StreamReader sr = new StreamReader(path);
                Key = sr.ReadToEnd();
                return sr.ReadToEnd();
            }
            return Key;
        }
    }
}
