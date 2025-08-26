using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _07_CamelCards_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_07_CamelCards))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_CamelCards))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_CamelCards))![1]);

        public static TheoryData<List<string>, long> _07_CamelCardsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _07_CamelCardsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_07_CamelCardsPartOne_Data))]
        public void PartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _07_CamelCards.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory(Skip = "Rewrite")]
        [MemberData(nameof(_07_CamelCardsPartTwo_Data))]
        public void PartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _07_CamelCards.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
