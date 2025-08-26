using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _03_PerfectlySphericalHousesInAVacuum_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_03_PerfectlySphericalHousesInAVacuum))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_PerfectlySphericalHousesInAVacuum))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_PerfectlySphericalHousesInAVacuum))![1]);

        public static TheoryData<List<string>, int> _03_PerfectlySphericalHousesInAVacuumPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03_PerfectlySphericalHousesInAVacuumPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03_PerfectlySphericalHousesInAVacuumPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _03_PerfectlySphericalHousesInAVacuum.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03_PerfectlySphericalHousesInAVacuumPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _03_PerfectlySphericalHousesInAVacuum.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
