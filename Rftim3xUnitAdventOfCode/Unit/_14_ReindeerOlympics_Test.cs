using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _14_ReindeerOlympics_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_14_ReindeerOlympics))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ReindeerOlympics))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_14_ReindeerOlympics))![1]);

        public static TheoryData<List<string>, int> _14_ReindeerOlympicsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _14_ReindeerOlympicsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_14_ReindeerOlympicsPartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _14_ReindeerOlympics.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_14_ReindeerOlympicsPartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _14_ReindeerOlympics.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
