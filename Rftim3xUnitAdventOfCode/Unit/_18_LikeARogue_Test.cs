using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _18_LikeARogue_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_18_LikeARogue))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_LikeARogue))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_LikeARogue))![1]);

        public static TheoryData<List<string>, int> _18_LikeARoguePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _18_LikeARoguePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_18_LikeARoguePartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _18_LikeARogue.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_18_LikeARoguePartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _18_LikeARogue.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
