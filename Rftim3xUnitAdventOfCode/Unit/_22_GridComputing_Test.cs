using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _22_GridComputing_Test
    {
        // Arrange
        public static List<string> Input => RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_22_GridComputing))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_22_GridComputing))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_22_GridComputing))![1]);

        public static TheoryData<List<string>, int> _22_GridComputingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _22_GridComputingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_22_GridComputingPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _22_GridComputing.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_22_GridComputingPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _22_GridComputing.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
