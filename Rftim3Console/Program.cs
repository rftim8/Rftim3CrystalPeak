using Microsoft.Extensions.Configuration;
using Rftim3Convoy;
using Rftim3Tracer;

namespace Rftim3Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            TestADOClient();
            TestFileIO();
        }

        private static void TestADOClient()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>();

            IConfigurationRoot configuration = builder.Build();

            string? userSecret = configuration[IRftDatabases.Database.Northwind.ToString()];
            _ = new RftADO(userSecret!);
        }

        private static void TestFileIO()
        {
            string[] test = RftFileIO.GetAllLinesFromFile("");
            foreach (string item in test)
            {
                Console.WriteLine(item);
            }
        }
    }
}
