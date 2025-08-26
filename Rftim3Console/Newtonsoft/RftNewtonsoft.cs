using Newtonsoft.Json;

namespace Rftim3Console.Newtonsoft
{
    public class RftNewtonsoft
    {
        private static readonly string? rftPathRoot = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString())?.ToString();
        private static readonly string rftFileName = $"{rftPathRoot}{Path.DirectorySeparatorChar}RftResources{Path.DirectorySeparatorChar}stores{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
        private static readonly string rftPath = $"{rftPathRoot}{Path.DirectorySeparatorChar}RftResources{Path.DirectorySeparatorChar}stores{Path.DirectorySeparatorChar}";

        public RftNewtonsoft()
        {
            int func = 0;

            switch (func)
            {
                #region Create
                case 0:
                    RftCreateDirectory();
                    break;
                case 1:
                    RftCreateFile();
                    break;
                #endregion
                #region Read
                case 2:
                    RftGetFileInfo();
                    break;
                case 3:
                    RftGetDirectoryInfo();
                    break;
                case 4:
                    RftCurrentDirectory();
                    break;
                case 5:
                    RftSpecialDirectories();
                    break;
                case 6:
                    RftCombinePaths();
                    break;
                case 7:
                    RftGetExtension();
                    break;
                case 8:
                    RftListDirectories();
                    break;
                case 9:
                    RftListFiles();
                    break;
                case 10:
                    RftListAllFilesExtension();
                    break;
                case 11:
                    RftListSpecificFile();
                    break;
                case 12:
                    RftReadDataFromFile();
                    break;
                #endregion
                #region Update
                case 13:
                    RftOverwriteFile();
                    break;
                case 14:
                    RftAppendToFile();
                    break;
                #endregion
                default:
                    break;
            }
        }

        #region Create
        private static void RftCreateDirectory()
        {
            if (!Directory.Exists(Path.Combine(rftPath, "201", "newDir")))
                Directory.CreateDirectory(Path.Combine(rftPath, "201", "newDir"));
            else
                Console.WriteLine($"Directory exists!");
        }

        private static void RftCreateFile()
        {
            if (!File.Exists(Path.Combine(rftPath, "greeting.txt")))
                File.WriteAllText(Path.Combine(rftPath, "greeting.txt"), "Hello World!");
            else
                Console.WriteLine($"File exists!");
        }
        #endregion

        #region Read
        private static void RftGetFileInfo()
        {
            FileInfo rftFileInfo = new(rftFileName);
            Console.WriteLine($"{rftFileInfo.Name}\n{rftFileInfo.Directory}\n{rftFileInfo.Extension}\n{rftFileInfo.CreationTime}");
        }

        private static void RftGetDirectoryInfo()
        {
            DirectoryInfo rftDirectoryInfo = new(rftFileName);
            Console.WriteLine($"{rftDirectoryInfo.Name}\n{rftDirectoryInfo.Root}\n{rftDirectoryInfo.CreationTime}");
        }

        private static void RftCurrentDirectory()
        {
            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
        }

        private static void RftSpecialDirectories()
        {
            string rftSpecialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine($"{rftSpecialDirectory}");
        }

        private static void RftCombinePaths()
        {
            Console.WriteLine($"{Path.Combine("stores", "201", "202")}");
        }

        private static void RftGetExtension()
        {
            Console.WriteLine($"{Path.GetExtension("sales.json")}");
        }

        private static void RftListDirectories()
        {
            IEnumerable<string> rftListDirectories = Directory.EnumerateDirectories(rftPath);

            foreach (string rftDirectory in rftListDirectories)
            {
                Console.WriteLine($"{rftDirectory}");
            }
        }

        private static void RftListFiles()
        {
            IEnumerable<string> rftFiles = Directory.EnumerateFiles(rftPath);

            foreach (string rftFile in rftFiles)
            {
                Console.WriteLine($"{rftFile}");
            }
        }

        private static void RftListAllFilesExtension()
        {
            IEnumerable<string> rftAllFiles = Directory.EnumerateFiles(rftPath, "*.txt", SearchOption.AllDirectories);

            foreach (string rftFiles in rftAllFiles)
            {
                Console.WriteLine($"{rftFiles}");
            }
        }

        private static void RftListSpecificFile()
        {
            IEnumerable<string> rftSpecificFile = Directory.EnumerateFiles(rftPath, "*", SearchOption.AllDirectories);

            foreach (string rftFile in rftSpecificFile)
            {
                if (rftFile.EndsWith("sales.json"))
                    Console.WriteLine($"{rftFile}");
            }
        }

        private static void RftReadDataFromFile()
        {
            string? rftReadDataFromFile = File.ReadAllText($"{Path.Combine(rftPath, "sales.json")}");
            SalesTotal? rftSalesData = JsonConvert.DeserializeObject<SalesTotal>(rftReadDataFromFile);

            if (rftSalesData is not null)
                Console.WriteLine($"{rftSalesData.Total}");
            else
                Console.WriteLine($"No data found!");
        }
        #endregion

        #region Update
        private static void RftOverwriteFile()
        {
            string? rftReadDataFromFile = File.ReadAllText($"{Path.Combine(rftPath, "sales.json")}");
            SalesTotal? rftSalesData = JsonConvert.DeserializeObject<SalesTotal>(rftReadDataFromFile);

            if (rftSalesData is not null)
                File.WriteAllText(Path.Combine(rftPath, "totals.txt"), rftSalesData.Total.ToString());
            else
                Console.WriteLine($"No data found!");
        }

        private static void RftAppendToFile()
        {
            string? rftReadDataFromFile = File.ReadAllText($"{Path.Combine(rftPath, "sales.json")}");
            SalesTotal? rftSalesData = JsonConvert.DeserializeObject<SalesTotal>(rftReadDataFromFile);

            if (rftSalesData is not null)
                File.AppendAllText(Path.Combine(rftPath, "totals.txt"), rftSalesData.Total.ToString());
            else
                Console.WriteLine($"No data found!");
        }
        #endregion
    }

    internal record SalesTotal(double Total);
}
