namespace Rftim3Convoy.Services.Static.IO
{
    public interface IRftFileContentManager
    {
        public static abstract List<string> GetAdventOfCodeProblemNames();
        public static abstract void CreateAdventOfCodeDataFiles(List<string> filenames);
        public static abstract void CreateAdventOfCodeCodeFiles(List<string> filenames);
        public static abstract void CreateAdventOfCodeCodeInterfaceFiles(List<string> filenames);
        public static abstract void CreateAdventOfCodexUnitTestFiles(List<string> filenames);
        public static abstract List<string> GetCodinGameProblemNames();
        public static abstract void CreateCodinGameDataFiles(List<string> filenames);
        public static abstract void CreateCodinGameCodeFiles(List<string> filenames);
        public static abstract void CreateCodinGameCodeInterfaceFiles(List<string> filenames);
        public static abstract void CreateCodinGamexUnitTestFiles(List<string> filenames);
        public static abstract List<string> GetLeetCodeProblemNames();
        public static abstract void CreateLeetCodeDataFiles(List<string> filenames);
        public static abstract void CreateLeetCodeCodeFiles(List<string> filenames);
        public static abstract void CreateLeetCodeCodeInterfaceFiles(List<string> filenames);
        public static abstract void CreateLeetCodexUnitTestFiles(List<string> filenames);
    }
}
