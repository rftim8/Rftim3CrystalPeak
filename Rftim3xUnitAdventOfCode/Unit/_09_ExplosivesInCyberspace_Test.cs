using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _09_ExplosivesInCyberspace_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_09_ExplosivesInCyberspace))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_ExplosivesInCyberspace))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_09_ExplosivesInCyberspace))![1]);

        public static TheoryData<List<string>, int> _09_ExplosivesInCyberspacePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _09_ExplosivesInCyberspacePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_09_ExplosivesInCyberspacePartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _09_ExplosivesInCyberspace.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_09_ExplosivesInCyberspacePartTwo_Data))]
        public static void RftPartTwo(List<string> input, long expected)
        {
            // Act
            long actual = _09_ExplosivesInCyberspace.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
