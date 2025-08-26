using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _19_ASeriesOfTubes_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_19_ASeriesOfTubes))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_ASeriesOfTubes))![0];
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_19_ASeriesOfTubes))![1]);

        public static TheoryData<List<string>, string> _19_ASeriesOfTubesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _19_ASeriesOfTubesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_19_ASeriesOfTubesPartOne_Data))]
        public void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _19_ASeriesOfTubes.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_19_ASeriesOfTubesPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _19_ASeriesOfTubes.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
