namespace Rftim3Console.System.Nets.HttpWebRequests
{
    public class RftHttpWebRequest
    {
        public RftHttpWebRequest()
        {
            // Call the async method to perform the request
            PerformRequestAsync().GetAwaiter().GetResult();
        }

        private static async Task PerformRequestAsync()
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("https://www.google.com/");
            response.EnsureSuccessStatusCode();

            // Print the HTTP header name/value pairs to the console
            Console.WriteLine("The HttpHeaders are:");
            foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }

            // Print the HTML contents of the page to the console
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
}
