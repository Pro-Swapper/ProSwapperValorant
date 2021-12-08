using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI
{
    public static class Utils
    {
        public static string Base64Encode(string plainText)=> Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        public static string Base64Decode(string base64EncodedData)=> Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));

    }
}
