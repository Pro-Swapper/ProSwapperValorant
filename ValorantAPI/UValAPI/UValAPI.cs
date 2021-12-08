using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ValorantAPI.UValAPI
{
    public class Methods
    {
        private const string UVALAPIEndpoint = "https://valorant-api.com/v1";
        public static T Get<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(new WebClient().DownloadString($"{UVALAPIEndpoint}{url}"));
        }
    }
}
