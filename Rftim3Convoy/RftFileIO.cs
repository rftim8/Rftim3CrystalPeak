namespace Rftim3Convoy
{
    public class RftFileIO
    {
        public static string[] GetAllLinesFromFile(string pathFilename)
        {
            string[] res = [];

            using (FileStream fileStream = new(pathFilename, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using StreamReader streamReader = new(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string? buffer = streamReader.ReadLine();

                    Array.Resize(ref res, res.Length + 1);
                    res[^1] = buffer is not null ? buffer : "\n";
                }
            }

            return res;
        }
    }
}
