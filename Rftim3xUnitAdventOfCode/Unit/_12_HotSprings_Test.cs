using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _12_HotSprings_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_12_HotSprings))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_12_HotSprings))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_12_HotSprings))![1]);

        public static TheoryData<List<string>, long> _12_HotSpringsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _12_HotSpringsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_12_HotSpringsPartOne_Data))]
        public void PartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _12_HotSprings.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_12_HotSpringsPartTwo_Data))]
        public void PartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _12_HotSprings.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
