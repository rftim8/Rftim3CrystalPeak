using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _01_NotQuiteLisp_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_01_NotQuiteLisp))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_NotQuiteLisp))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_01_NotQuiteLisp))![1]);

        public static TheoryData<List<string>, int> _01_NotQuiteLispPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01_NotQuiteLispPartTwo_Data => 
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01_NotQuiteLispPartOne_Data))]
        public static void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01_NotQuiteLisp.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01_NotQuiteLispPartTwo_Data))]
        public static void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01_NotQuiteLisp.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
