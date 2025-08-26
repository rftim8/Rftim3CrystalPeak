using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _07_RecursiveCircus_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_07_RecursiveCircus))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_RecursiveCircus))![0];
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_07_RecursiveCircus))![1]);

        public static TheoryData<List<string>, string> _07_RecursiveCircusPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _07_RecursiveCircusPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_07_RecursiveCircusPartOne_Data))]
        public void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _07_RecursiveCircus.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_07_RecursiveCircusPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _07_RecursiveCircus.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
