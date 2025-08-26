using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _05_AMazeOfTwistyTrampolinesAllAlike_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_05_AMazeOfTwistyTrampolinesAllAlike))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_AMazeOfTwistyTrampolinesAllAlike))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_AMazeOfTwistyTrampolinesAllAlike))![1]);

        public static TheoryData<List<string>, int> _05_AMazeOfTwistyTrampolinesAllAlikePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _05_AMazeOfTwistyTrampolinesAllAlikePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_05_AMazeOfTwistyTrampolinesAllAlikePartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _05_AMazeOfTwistyTrampolinesAllAlike.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_05_AMazeOfTwistyTrampolinesAllAlikePartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _05_AMazeOfTwistyTrampolinesAllAlike.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
