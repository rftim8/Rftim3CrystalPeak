using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _14_ChocolateCharts_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_14_ChocolateCharts))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ChocolateCharts))![0];
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ChocolateCharts))![1]);

        public static TheoryData<List<string>, string> _14_ChocolateChartsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _14_ChocolateChartsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_14_ChocolateChartsPartOne_Data))]
        public void RftPartOne(List<string> a0, string expected)
        {
            // Act
            string actual = _14_ChocolateCharts.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_14_ChocolateChartsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _14_ChocolateCharts.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
