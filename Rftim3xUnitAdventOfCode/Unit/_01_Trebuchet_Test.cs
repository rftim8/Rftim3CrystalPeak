using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _01_Trebuchet_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_01_Trebuchet))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_Trebuchet))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_Trebuchet))![1]);

        public static TheoryData<List<string>, int> _01_TrebuchetPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01_TrebuchetPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01_TrebuchetPartOne_Data))]
        public void PartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01_Trebuchet.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_01_TrebuchetPartTwo_Data))]
        public void PartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01_Trebuchet.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
