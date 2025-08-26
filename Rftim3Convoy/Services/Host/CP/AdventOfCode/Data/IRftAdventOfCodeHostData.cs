namespace Rftim3Convoy.Services.Host.CP.AdventOfCode.Data
{
    public interface IRftAdventOfCodeHostData
    {
        public List<string>? Input_Test(bool testType = true, bool direction = true, string? problemName = null);

        public List<string>? Output_Test(bool testType = true, bool direction = false, string? problemName = null);
    }
}
