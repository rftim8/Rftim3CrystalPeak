using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _03_SquaresWithThreeSides_Test
    {
        // Arrange
        public static List<string> Input => RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_03_SquaresWithThreeSides))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_SquaresWithThreeSides))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_03_SquaresWithThreeSides))![1]);

        public static TheoryData<List<string>, int> _03_SquaresWithThreeSidesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03_SquaresWithThreeSidesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03_SquaresWithThreeSidesPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _03_SquaresWithThreeSides.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03_SquaresWithThreeSidesPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _03_SquaresWithThreeSides.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
