namespace Rftim3Convoy.Temp.Construct.IOs
{
    public class DataPrep
    {
        // Reflection from different assembly
        public static string DataRetrieveString(Stream? stream)
        {
            string x = "";
            using (Stream? stm = stream)
            {
                if (stm is not null)
                {
                    using StreamReader rdr = new(stm);
                    string? buffer = rdr.ReadLine();
                    if (buffer is not null)
                        x += buffer;
                }
            }

            return string.IsNullOrEmpty(x) ? "" : x;
        }

        public static List<string> DataRetrieveList(Stream? stream)
        {
            List<string> data = [];
            using (Stream? stm = stream)
            {
                if (stm is not null)
                {
                    using StreamReader rdr = new(stm);
                    while (!rdr.EndOfStream)
                    {
                        string? buffer = rdr.ReadLine();
                        if (buffer is not null)
                            data.Add(buffer);
                    }
                }
            }

            return data.Count != 0 ? data : [];
        }

        // Local resource files
        public static string GetRoot()
        {
            DirectoryInfo? level1 = Directory.GetParent(Directory.GetCurrentDirectory());
            if (level1 is not null)
            {
                DirectoryInfo? level2 = Directory.GetParent(level1.ToString());
                if (level2 is not null)
                {
                    DirectoryInfo? level3 = Directory.GetParent(level2.ToString());
                    if (level3 is not null)
                        return $"{level3}\\RftAdventOfCode\\";
                }
            }

            return "";
        }

        public static List<string> DataRetrieveList(string path)
        {
            path = $"{GetRoot()}{path}";

            List<string> list = [];
            using (FileStream stm = new(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader rdr = new(stm);
                while (!rdr.EndOfStream)
                {
                    string? buffer = rdr.ReadLine();
                    if (buffer is not null)
                        list.Add(buffer);
                }
            }

            return list;
        }

        public static string DataRetrieveString(string path)
        {
            path = $"{GetRoot()}{path}";

            string x = "";
            using (FileStream stm = new(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader rdr = new(stm);
                string? buffer = rdr.ReadLine();
                if (buffer is not null)
                    x += buffer;
            }

            return x;
        }
    }
}
