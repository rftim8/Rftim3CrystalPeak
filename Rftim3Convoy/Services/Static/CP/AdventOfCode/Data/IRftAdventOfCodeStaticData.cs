namespace Rftim3Convoy.Services.Static.CP.AdventOfCode.Data
{
    public interface IRftAdventOfCodeStaticData<T0, T1>
    {
        static abstract T0? Input_Test(bool testType = true, bool direction = true, string? problemName = null);

        static abstract T1? Output_Test(bool testType = true, bool direction = false, string? problemName = null);
    }
}
