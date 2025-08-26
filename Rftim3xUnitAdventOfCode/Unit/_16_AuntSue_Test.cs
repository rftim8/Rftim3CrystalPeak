using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _16_AuntSue_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_16_AuntSue))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_AuntSue))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_16_AuntSue))![1]);

        public static TheoryData<List<string>, int> _16_AuntSuePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _16_AuntSuePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_16_AuntSuePartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _16_AuntSue.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_16_AuntSuePartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _16_AuntSue.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
