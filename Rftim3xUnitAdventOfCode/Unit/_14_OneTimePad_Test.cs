using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _14_OneTimePad_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_14_OneTimePad))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_OneTimePad))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_OneTimePad))![1]);

        public static TheoryData<List<string>, int> _14_OneTimePadPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _14_OneTimePadPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_14_OneTimePadPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _14_OneTimePad.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Optimize")]
        [MemberData(nameof(_14_OneTimePadPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _14_OneTimePad.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
