using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _12_JSAbacusFrameworkIO_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_12_JSAbacusFrameworkIO))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_12_JSAbacusFrameworkIO))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_12_JSAbacusFrameworkIO))![1]);

        public static TheoryData<List<string>, int> _12_JSAbacusFrameworkIOPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _12_JSAbacusFrameworkIOPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_12_JSAbacusFrameworkIOPartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _12_JSAbacusFrameworkIO.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_12_JSAbacusFrameworkIOPartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _12_JSAbacusFrameworkIO.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
