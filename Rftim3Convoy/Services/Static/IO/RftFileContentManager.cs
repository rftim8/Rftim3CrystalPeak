namespace Rftim3Convoy.Services.Static.IO
{
    public class RftFileContentManager : IRftFileContentManager
    {
        #region AdventOfCode
        public static List<string> GetAdventOfCodeProblemNames() => GetAdventOfCodeProblemNames0();

        private static List<string> GetAdventOfCodeProblemNames0()
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string AoCpath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\AdventOfCode\\Templates\\AdventOfCodeProblemNames.txt";

            List<string> list = [];

            using (FileStream fileStream = new(AoCpath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader streamReader = new(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string? buffer = streamReader.ReadLine();

                    if (buffer is not null)
                        list.Add(buffer);
                }
            }

            list.Sort();
            File.WriteAllText(AoCpath, string.Join("\n", list));

            return list;
        }

        public static void CreateAdventOfCodeDataFiles(List<string> filenames) => CreateAdventOfCodeDataFiles0(filenames);

        private static void CreateAdventOfCodeDataFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string dataPath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\AdventOfCode\\IO\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(dataPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".txt", ""))];

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}_Input"))
                    File.Create($"{dataPath}{item}_Input.txt");

                if (!dirFiles.Contains($"{item}_Output"))
                    File.Create($"{dataPath}{item}_Output.txt");
            }
        }

        public static void CreateAdventOfCodeCodeFiles(List<string> filenames) => CreateAdventOfCodeCodeFiles0(filenames);

        private static void CreateAdventOfCodeCodeFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3CP\\AdventOfCode\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\AdventOfCode\\Templates\\RftAdventOfCodeCSTemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}"))
                {
                    File.WriteAllText($"{cpPath}{item}.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }

        public static void CreateAdventOfCodeCodeInterfaceFiles(List<string> filenames) => CreateAdventOfCodeCodeInterfaceFiles0(filenames);

        private static void CreateAdventOfCodeCodeInterfaceFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3CP\\AdventOfCode\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\AdventOfCode\\Templates\\RftAdventOfCodeCSITemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"I{item}"))
                {
                    File.WriteAllText($"{cpPath}I{item}.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }

        public static void CreateAdventOfCodexUnitTestFiles(List<string> filenames) => CreateAdventOfCodexUnitTestFiles0(filenames);

        private static void CreateAdventOfCodexUnitTestFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3xUnit\\UnitTests\\CP\\AdventOfCode\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\AdventOfCode\\Templates\\RftAdventOfCodeCSxUnitTestTemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}_Test"))
                {
                    File.WriteAllText($"{cpPath}{item}_Test.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        #region CodeForces
        public static List<string> GetCodeForcesProblemNames() => GetCodeForcesProblemNames0();

        private static List<string> GetCodeForcesProblemNames0()
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string CFpath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodeForces.txt";

            List<string> list = [];

            using (FileStream fileStream = new(CFpath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader streamReader = new(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string? buffer = streamReader.ReadLine();

                    if (buffer is not null)
                        list.Add(buffer);
                }
            }

            File.WriteAllText(CFpath, string.Join("\n", list));

            return list;
        }

        public static void CleanCodeForcesProblemNames() => CleanCodeForcesProblemNames0();

        private static void CleanCodeForcesProblemNames0()
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string CFpath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodeForces.txt";

            List<string> x = GetCodeForcesProblemNames();
            List<string> y = [];

            foreach (string item in x)
            {
                y.Add(item.Split("Submit")[0]);
            }

            List<string> z = [];
            foreach (string item in y)
            {
                if (item[0] != '_')
                {
                    string t = item.Split("\t")[0];
                    int c = 0;

                    foreach (char item1 in t)
                    {
                        if (char.IsNumber(item1))
                            c++;
                        else
                            break;

                    }

                    t = $"_{string.Join("", Enumerable.Repeat('0', 6 - c))}{t}_{item.Split("\t")[1]}";
                    z.Add(t);
                }
            }

            if (z.Count > 0)
                File.AppendAllText(CFpath, string.Join("\n", z));

        }
        #endregion

        #region CodinGame
        public static List<string> GetCodinGameProblemNames() => GetCodinGameProblemNames0();

        private static List<string> GetCodinGameProblemNames0()
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string LCpath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodinGame\\Templates\\CodinGameProblemNames.txt";

            List<string> list = [];

            using (FileStream fileStream = new(LCpath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader streamReader = new(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string? buffer = streamReader.ReadLine();

                    if (buffer is not null)
                        list.Add(buffer);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                List<string> pn = [.. list[i].Split(" ")];
                if (pn[0].Contains('.'))
                {
                    pn[0] = $"_0{pn[0][..^1]}_";
                    for (int j = 1; j < pn.Count; j++)
                    {
                        pn[j] = $"{pn[j][0].ToString().ToUpper()}{pn[j][1..]}";
                    }
                }
                list[i] = string.Join("", pn)
                    .Replace("-", "")
                    .Replace(")", "")
                    .Replace("(", "");
            }

            list.Sort();
            File.WriteAllText(LCpath, string.Join("\n", list));

            return list;
        }

        public static void CreateCodinGameDataFiles(List<string> filenames) => CreateCodinGameDataFiles0(filenames);

        private static void CreateCodinGameDataFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string dataPath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodinGame\\IO\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(dataPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".txt", ""))];

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}_Input"))
                    File.Create($"{dataPath}{item}_Input.txt");

                if (!dirFiles.Contains($"{item}_Output"))
                    File.Create($"{dataPath}{item}_Output.txt");
            }
        }

        public static void CreateCodinGameCodeFiles(List<string> filenames) => CreateCodinGameCodeFiles0(filenames);

        private static void CreateCodinGameCodeFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3CP\\CodinGame\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodinGame\\Templates\\RftCodinGameCSTemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}"))
                {
                    File.WriteAllText($"{cpPath}{item}.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }

        public static void CreateCodinGameCodeInterfaceFiles(List<string> filenames) => CreateCodinGameCodeInterfaceFiles0(filenames);

        private static void CreateCodinGameCodeInterfaceFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3CP\\CodinGame\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodinGame\\Templates\\RftCodinGameCSITemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"I{item}"))
                {
                    File.WriteAllText($"{cpPath}I{item}.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }

        public static void CreateCodinGamexUnitTestFiles(List<string> filenames) => CreateCodinGamexUnitTestFiles0(filenames);

        private static void CreateCodinGamexUnitTestFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3xUnit\\UnitTests\\CP\\CodinGame\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\CodinGame\\Templates\\RftCodinGameCSxUnitTestTemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}_Test"))
                {
                    File.WriteAllText($"{cpPath}{item}_Test.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        #region LeetCode
        public static List<string> GetLeetCodeProblemNames() => GetLeetCodeProblemNames0();

        private static List<string> GetLeetCodeProblemNames0()
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string LCpath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\LeetCode\\Templates\\LeetCodeProblemNames.txt";

            List<string> list = [];

            using (FileStream fileStream = new(LCpath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader streamReader = new(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string? buffer = streamReader.ReadLine();

                    if (buffer is not null)
                        list.Add(buffer);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                List<string> pn = [.. list[i].Split(" ")];
                if (pn[0].Contains('.'))
                {
                    pn[0] = $"_0{pn[0][..^1]}_";
                    for (int j = 1; j < pn.Count; j++)
                    {
                        pn[j] = $"{pn[j][0].ToString().ToUpper()}{pn[j][1..]}";
                    }
                }
                list[i] = string.Join("", pn)
                    .Replace("-", "")
                    .Replace(")", "")
                    .Replace("(", "");
            }

            list.Sort();
            File.WriteAllText(LCpath, string.Join("\n", list));

            return list;
        }

        public static void CreateLeetCodeDataFiles(List<string> filenames) => CreateLeetCodeDataFiles0(filenames);

        private static void CreateLeetCodeDataFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string dataPath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\LeetCode\\IO\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(dataPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".txt", ""))];

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}_Input"))
                    File.Create($"{dataPath}{item}_Input.txt");

                if (!dirFiles.Contains($"{item}_Output"))
                    File.Create($"{dataPath}{item}_Output.txt");
            }
        }

        public static void CreateLeetCodeCodeFiles(List<string> filenames) => CreateLeetCodeCodeFiles0(filenames);

        private static void CreateLeetCodeCodeFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3CP\\LeetCode\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\LeetCode\\Templates\\RftLeetCodeCSTemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}"))
                {
                    File.WriteAllText($"{cpPath}{item}.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }

        public static void CreateLeetCodeCodeInterfaceFiles(List<string> filenames) => CreateLeetCodeCodeInterfaceFiles0(filenames);

        private static void CreateLeetCodeCodeInterfaceFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3CP\\LeetCode\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\LeetCode\\Templates\\RftLeetCodeCSITemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"I{item}"))
                {
                    File.WriteAllText($"{cpPath}I{item}.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }

        public static void CreateLeetCodexUnitTestFiles(List<string> filenames) => CreateLeetCodexUnitTestFiles0(filenames);

        private static void CreateLeetCodexUnitTestFiles0(List<string> filenames)
        {
            string executablePath = Directory.GetCurrentDirectory();

            List<int> indexes = [];

            for (int i = 0; i < executablePath!.Length; i++)
            {
                if (executablePath[i] == '\\')
                    indexes.Add(i);
            }

            string cpPath = $"{executablePath[..indexes[^4]]}\\Rftim3xUnit\\UnitTests\\CP\\LeetCode\\";
            IEnumerable<string> dir = Directory.EnumerateFiles(cpPath);
            List<string> dirFiles = [.. dir.Select(o => o.Split('\\').Last().Replace(".cs", ""))];

            string templatePath = $"{executablePath[..indexes[^4]]}\\Rftim3Atlas\\CP\\LeetCode\\Templates\\RftLeetCodeCSxUnitTestTemplate.txt";
            string template = File.ReadAllText(templatePath);

            foreach (string item in filenames)
            {
                if (!dirFiles.Contains($"{item}_Test"))
                {
                    File.WriteAllText($"{cpPath}{item}_Test.cs", template.Replace("[x]", item));
                    Console.WriteLine(item);
                }
            }
        }
        #endregion
    }
}
