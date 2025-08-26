namespace Rftim3Console.System.Threading.Tasks
{
    class RftAsync
    {
        public RftAsync()
        {
            X().GetAwaiter().GetResult();
            Task<int> x = RetrieveDocsHomePage();
            Console.WriteLine(x.Result);
        }

        static async Task X()
        {
            Console.WriteLine($"Hello ");
            await Task.Delay(5000);
            Console.WriteLine($"World!");
        }

        public async Task<int> RetrieveDocsHomePage()
        {
            HttpClient client = new();
            byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/");
            Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");

            return content.Length;
        }
    }
}
