using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _18_LavaductLagoon_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_18_LavaductLagoon))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_LavaductLagoon))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_LavaductLagoon))![1]);

        public static TheoryData<List<string>, long> _18_LavaductLagoonPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _18_LavaductLagoonPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_18_LavaductLagoonPartOne_Data))]
        public void PartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _18_LavaductLagoon.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_18_LavaductLagoonPartTwo_Data))]
        public void PartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _18_LavaductLagoon.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
