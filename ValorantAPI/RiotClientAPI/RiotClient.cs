using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ValorantAPI.RiotClientAPI.RiotJsonStructs;
namespace ValorantAPI.RiotClientAPI
{
    public class RiotClient
    {

        public Token Token;
        public Lockfile lockfile;
        public string region;
        public FetchSession CurrentUser;
        public RiotClient(string Region)
        {
            lockfile = GetLockfile();
            Token = GetToken();
            CurrentUser = GetCurrentUser();
            region = Region;
        }

        public class Lockfile
        {
            public string name;
            public string pid;
            public string port;
            public string password;
            public string protocol;
        }

        public static Lockfile GetLockfile()
        {
            //public FileStream(string path, FileMode mode, FileAccess access, FileShare share)
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Riot Games\\Riot Client\\Config\\lockfile";
            using (Stream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[(int)fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                string content = Encoding.Default.GetString(buffer);
                string[] PlainLockfile = content.Split(':');
                return new Lockfile() { name = PlainLockfile[0], pid = PlainLockfile[1], port = PlainLockfile[2], password = PlainLockfile[3], protocol = PlainLockfile[4] };
            }
            
        }

        public Token GetToken()
        {
                
                string auth = Utils.Base64Encode($"riot:{lockfile.password}");
                string url = $"https://127.0.0.1:{lockfile.port}/entitlements/v1/token";
                using (HttpClientHandler clientHandler = new HttpClientHandler())
                {
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    HttpClient client = new HttpClient(clientHandler);
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
                    string result = client.GetStringAsync(url).Result;
                    return JsonConvert.DeserializeObject<Token>(result);
                }
        }

        public Store_GetOffers Store_GetOffers()//Get prices for all store items
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.accessToken}");
                wc.Headers.Add("X-Riot-Entitlements-JWT", Token.token);
                string url = $"https://pd.{region}.a.pvp.net/store/v1/offers/";
                return JsonConvert.DeserializeObject<Store_GetOffers>(wc.DownloadString(url));
            }

        }
        
        public StoreFrontV2.Root Store_GetStorefrontV2()//Get the currently available items in the store
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.accessToken}");
                wc.Headers.Add("X-Riot-Entitlements-JWT", Token.token);
                string url = $"https://pd.{region}.a.pvp.net/store/v2/storefront/{CurrentUser.puuid}";
                //return wc.DownloadString(url);
                return JsonConvert.DeserializeObject<StoreFrontV2.Root>(wc.DownloadString(url));
            }

        }
        
        

        //TEXT_CHAT_RNet_FetchSession
        public FetchSession GetCurrentUser()//Get the current session including player name and PUUID
        {
            Lockfile lockfile = GetLockfile();
            string auth = Utils.Base64Encode($"riot:{lockfile.password}");
            string url = $"https://127.0.0.1:{lockfile.port}/chat/v1/session";
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
                string result = client.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<FetchSession>(result);
            }
        }


        private Wallet.Root Store_GetWallet()//Get the currently available items in the store
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.accessToken}");
                wc.Headers.Add("X-Riot-Entitlements-JWT", Token.token);
                string url = $"https://pd.{region}.a.pvp.net/store/v1/wallet/{CurrentUser.puuid}";
                return JsonConvert.DeserializeObject<Wallet.Root>(wc.DownloadString(url));
            }

        }

        public Currency GetUserCurrency()
        {
            Wallet.Root wallet = Store_GetWallet();
            return new Currency() { ValorantPoints = wallet.Balances._85ad13f73d1b51289eb27cd8ee0b5741, Radianite = wallet.Balances.E59aa87c4cbf517a59836e81511be9b7 };
        }


        public Loadout.Root GetPlayerLoadout()//Get player's loadout
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.accessToken}");
                wc.Headers.Add("X-Riot-Entitlements-JWT", Token.token);
                string url = $"https://pd.{region}.a.pvp.net/personalization/v2/players/{CurrentUser.puuid}/playerloadout";

                return JsonConvert.DeserializeObject<Loadout.Root>(wc.DownloadString(url));
            }
        }

        public bool SetPlayerLoadout(Loadout.Root loadout)//Get the currently available items in the store
        {
            try
            {
                using (WebClient wc = new WebClient())
                {

                    wc.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.accessToken}");
                    wc.Headers.Add("X-Riot-Entitlements-JWT", Token.token);
                    string url = $"https://pd.{region}.a.pvp.net/personalization/v2/players/{CurrentUser.puuid}/playerloadout";

                    string response = wc.UploadString(url, "PUT", JsonConvert.SerializeObject(loadout));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static ExternalSessions.Root GetExternalSessions()//Get the current locale
        {
            Lockfile lockfile = GetLockfile();
            string auth = Utils.Base64Encode($"riot:{lockfile.password}");
            string url = $"https://127.0.0.1:{lockfile.port}/product-session/v1/external-sessions";
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
                string result = client.GetStringAsync(url).Result;

                JObject response = JObject.Parse(result);

                foreach (var x in response)
                {
                    JToken value = x.Value;
                    return JsonConvert.DeserializeObject<ExternalSessions.Root>(value.ToString());
                }
            }
            throw new Exception("Error when trying to fetch region");
        }

        public Entitlements.Root Get_Entitlements()//Get the current locale
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.accessToken}");
                wc.Headers.Add("X-Riot-Entitlements-JWT", Token.token);
                string url = $"https://pd.{region}.a.pvp.net/store/v1/entitlements/{CurrentUser.puuid}";
                return JsonConvert.DeserializeObject<Entitlements.Root>(wc.DownloadString(url));
            }

        }

        
    }
}
