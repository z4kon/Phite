using Lolphite.Core.Model;
using Lolphite.Core.Utilities;
using Newtonsoft.Json;

namespace Lolphite.Core.RiotAPI.Endpoints
{
    public class AccountV1 : API
    {
        public AccountV1() : base()
        {
        }

        [Obsolete("Not working")]
        public static AccountDTO? GetAccountData()
        {
            if (Constants.Initialized)
            {
                string path = "riot/account/v1/accounts/by-puuid/{puuid}?";
                var response = GET(GetURI(path, false));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<AccountDTO>(content);
                }
                else
                {
                    return null;
                }
            }
            else throw new Exception("Constants Class Exception - Class was not initialized!");
        }
    }
}
