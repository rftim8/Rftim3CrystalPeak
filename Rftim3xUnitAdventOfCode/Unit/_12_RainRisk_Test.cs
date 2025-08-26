using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _12_RainRisk_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_12_RainRisk))!;
        private static readonly double ExpectedPartOne = double.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_12_RainRisk))![0]);
        private static readonly double ExpectedPartTwo = double.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_12_RainRisk))![1]);

        public static TheoryData<List<string>, double> _12_RainRiskPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, double> _12_RainRiskPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_12_RainRiskPartOne_Data))]
        public void RftPartOne(List<string> a0, double expected)
        {
            // Act
            double actual = _12_RainRisk.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_12_RainRiskPartTwo_Data))]
        public void RftPartTwo(List<string> a0, double expected)
        {
            // Act
            double actual = _12_RainRisk.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
