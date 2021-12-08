using Newtonsoft.Json;
using ValorantAPI.JsonStructs;
using System.Net;
using System;

namespace ValorantAPI
{
    public class ValAPI
    {

        public const int Version = 1;
        public const string APIEndpoint = ".api.riotgames.com";

        private string RiotToken = string.Empty;
        private Regions RiotRegion = 0;

        private WebClient GetWebClient()
        {
            using (WebClient web = new WebClient())
            {
                //https://asia.api.riotgames.com/riot/account/v1/accounts/by-puuid/HqFt7blb88-Ip7hH9WT5bkMnv2mP6EGu3cz8wkiEtE0t1JEYK4E3XwutgqpsclQ-yQFKeP7f7XPWeQ
                web.Headers.Add("X-Riot-Token", RiotToken);
                web.BaseAddress = $"https://{RiotRegion}{APIEndpoint}";
                return web;
            }
        }

        public ValAPI(Regions region, string riotToken)
        {
            RiotToken = riotToken;
            RiotRegion = region;
        }

        public enum Regions
        {
            americas,
            asia,
            esports,
            europe
        }

        public Account GetAccountByID(string PUIID)
        {
            using (WebClient web = GetWebClient())
            {
                try
                {
                    string response = web.DownloadString($"/riot/account/v1/accounts/by-puuid/{PUIID}");
                    return JsonConvert.DeserializeObject<Account>(response);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Account GetAccountByName(string Username, string tagLine)
        {
            //https://asia.api.riotgames.com/riot/account/v1/accounts/by-riot-id/Kye/5000
            using (WebClient web = GetWebClient())
            {
                try
                {
                    string response = web.DownloadString($"/riot/account/v1/accounts/by-riot-id/{Username}/{tagLine}");
                    return JsonConvert.DeserializeObject<Account>(response);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public ActiveShard GetActiveShard(Account account)
        {
            //https://americas.api.riotgames.com/riot/account/v1/active-shards/by-game/val/by-puuid/j9cLVnv0-tcGwO9-vm2n44POwy2U44QICZOEYB5ExqzwxWYdaQOoHgAmfRlISIqUNQKRy36PVHaoWQ
            using (WebClient web = GetWebClient())
            {
                try
                {
                    string response = web.DownloadString($"/riot/account/v1/active-shards/by-game/val/by-puuid/{account.puuid}");
                    return JsonConvert.DeserializeObject<ActiveShard>(response);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public class Language
        {
            public const string arAE = "ar-AE";
            public const string deDE = "de-DE";
            public const string enGB = "en-GB";
            public const string enUS = "en-US";
            public const string esES = "es-ES";
            public const string esMX = "es-MX";
            public const string frFR = "fr-FR";
            public const string idID = "id-ID";
            public const string itIT = "it-IT";
            public const string jaJP = "ja-JP";
            public const string koKR = "ko-KR";
            public const string plPL = "pl-PL";
            public const string ptBR = "pt-BR";
            public const string ruRU = "ru-RU";
            public const string thTH = "th-TH";
            public const string trTR = "tr-TR";
            public const string viVN = "vi-VN";
            public const string zhCN = "zh-CN";
            public const string zhTW = "zh-TW";
        }

        public enum ValorantRegion
        {
            AP,
            BR,
            ESPORTS,
            EU,
            KR,
            LATAM,
            NA
        }

        public Content GetContent(string Language, ValorantRegion Region)
        {
            //https://ap.api.riotgames.com/val/content/v1/contents?locale=en-US
            using (WebClient web = new WebClient())
            {
                try
                {
                    web.Headers.Add("X-Riot-Token", RiotToken);
                    string response = web.DownloadString($"https://ap.api.riotgames.com/val/content/v1/contents?locale={Language}");
                    return JsonConvert.DeserializeObject<Content>(response);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}