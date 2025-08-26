using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Rftim3Console.System.Nets.Https
{
    public class RftHttpClient
    {
        public RftHttpClient()
        {
            HttpClient httpClient = new();
            using Task<string> x = httpClient.GetStringAsync($"https://codeforces.com/problemset/problem/1971/A");

            Console.WriteLine(x.Result.ToString());
        }

        public static string GenerateSignature(string args, SecurityToken token)
        {
            if (string.IsNullOrEmpty(token?.Key) ||
                string.IsNullOrEmpty(token.Secret) ||
                string.IsNullOrEmpty(token.Random))
            {
                return "";
            }

            string flag = args.Contains('?') ? "&" : "?";

            string signature = $"{flag}apiKey={token.Key}&time={GetCodeforcesTime()}";

            string hash = $"{token.Random}/{args}{signature}#{token.Secret}";
            Console.WriteLine("To be hashed:\n" + hash);
            byte[] bytes = Encoding.UTF8.GetBytes(hash);
            using (SHA512 alg = SHA512.Create())
            {
                alg.ComputeHash(bytes);
                signature += $"&apiSig={token.Random}{Convert.ToHexStringLower(alg.Hash!)}";
            }

            return signature;
        }

        public static int GetCodeforcesTime() => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

        private static string Deserialize(string apiData)
        {
            int index = apiData.IndexOf("result\":");
            if (apiData.Substring(index + 8, 1) != "[")
            {
                apiData = apiData.Insert(apiData.IndexOf("result\":") + 8, "[");
                apiData = apiData.Insert(apiData.LastIndexOf('}'), "]");
            }

            string? res = JsonConvert.DeserializeObject<string>(apiData);

            return res ?? "";
        }
    }
}
