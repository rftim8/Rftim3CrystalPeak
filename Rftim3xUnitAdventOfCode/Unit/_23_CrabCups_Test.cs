using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _23_CrabCups_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_23_CrabCups))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_23_CrabCups))![0]);
        private static readonly ulong ExpectedPartTwo = ulong.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_23_CrabCups))![1]);

        public static TheoryData<List<string>, long> _23_CrabCupsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, ulong> _23_CrabCupsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_23_CrabCupsPartOne_Data))]
        public void RftPartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _23_CrabCups.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_23_CrabCupsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, ulong expected)
        {
            // Act
            ulong actual = _23_CrabCups.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
