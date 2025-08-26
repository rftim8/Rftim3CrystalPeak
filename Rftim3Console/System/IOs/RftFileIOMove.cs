namespace Rftim3Console.System.IOs
{
    internal class RftFileIOMove
    {
        public RftFileIOMove()
        {
            int counter = 0;

            string? pathDest = @"";
            string? pathSrc = @"";

            if (!Directory.Exists(pathDest))
                return;

            if (!Directory.Exists(pathSrc))
                return;

            List<string> srcDirs = [.. Directory.EnumerateDirectories(pathSrc)];
            List<string> destFiles = [.. Directory.EnumerateFiles(pathDest)];

            foreach (string item in srcDirs)
            {
                List<string> srcFiles = [.. Directory.EnumerateFiles(item)];

                foreach (string item0 in srcFiles)
                {
                    string? fileDest = $"{pathDest}{item0.Split('\\').Last()}_2012";

                    if (!destFiles.Contains(fileDest))
                    {
                        File.Move(item0, fileDest, true);
                        Console.WriteLine(fileDest);
                        counter++;
                    }
                }
            }

            Console.WriteLine($"Total: {counter}");
        }
    }
}
