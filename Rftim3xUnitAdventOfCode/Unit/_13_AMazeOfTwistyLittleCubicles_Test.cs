using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _13_AMazeOfTwistyLittleCubicles_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_13_AMazeOfTwistyLittleCubicles))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_AMazeOfTwistyLittleCubicles))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_AMazeOfTwistyLittleCubicles))![1]);

        public static TheoryData<List<string>, int> _13_AMazeOfTwistyLittleCubiclesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _13_AMazeOfTwistyLittleCubiclesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_13_AMazeOfTwistyLittleCubiclesPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _13_AMazeOfTwistyLittleCubicles.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_13_AMazeOfTwistyLittleCubiclesPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _13_AMazeOfTwistyLittleCubicles.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
