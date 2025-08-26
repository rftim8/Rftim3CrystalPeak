using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _05_HowAboutANiceGameOfChess_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_05_HowAboutANiceGameOfChess))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_HowAboutANiceGameOfChess))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_HowAboutANiceGameOfChess))![1];

        public static TheoryData<List<string>, string> _05_HowAboutANiceGameOfChessPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _05_HowAboutANiceGameOfChessPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_05_HowAboutANiceGameOfChessPartOne_Data))]
        public static void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _05_HowAboutANiceGameOfChess.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_05_HowAboutANiceGameOfChessPartTwo_Data))]
        public static void RftPartTwo(List<string> input, string expected)
        {
            // Act
            string actual = _05_HowAboutANiceGameOfChess.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
