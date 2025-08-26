using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _24_ImmuneSystemSimulator20XX_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_24_ImmuneSystemSimulator20XX))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_ImmuneSystemSimulator20XX))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_ImmuneSystemSimulator20XX))![1]);

        public static TheoryData<List<string>, int> _24_ImmuneSystemSimulator20XXPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _24_ImmuneSystemSimulator20XXPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_24_ImmuneSystemSimulator20XXPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _24_ImmuneSystemSimulator20XX.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_24_ImmuneSystemSimulator20XXPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _24_ImmuneSystemSimulator20XX.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
