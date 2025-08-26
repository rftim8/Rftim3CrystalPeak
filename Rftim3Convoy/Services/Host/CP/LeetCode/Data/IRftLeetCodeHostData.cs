namespace Rftim3Convoy.Services.Host.CP.LeetCode.Data
{
    public interface IRftLeetCodeHostData
    {
        public List<string>? Input_Test(bool testType = true, bool direction = true, string? problemName = null);

        public List<string>? Output_Test(bool testType = true, bool direction = false, string? problemName = null);
    }
}
