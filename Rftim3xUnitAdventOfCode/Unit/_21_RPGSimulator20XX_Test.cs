using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _21_RPGSimulator20XX_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_21_RPGSimulator20XX))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_21_RPGSimulator20XX))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_21_RPGSimulator20XX))![1]);

        public static TheoryData<List<string>, int> _21_RPGSimulator20XXPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _21_RPGSimulator20XXPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_21_RPGSimulator20XXPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _21_RPGSimulator20XX.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_21_RPGSimulator20XXPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _21_RPGSimulator20XX.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
