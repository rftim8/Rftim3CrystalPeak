using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _10_ElvesLookElvesSay_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_10_ElvesLookElvesSay))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_10_ElvesLookElvesSay))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_10_ElvesLookElvesSay))![1]);

        public static TheoryData<List<string>, int> _10_ElvesLookElvesSayPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _10_ElvesLookElvesSayPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_10_ElvesLookElvesSayPartOne_Data))]
        public static void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _10_ElvesLookElvesSay.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_10_ElvesLookElvesSayPartTwo_Data))]
        public static void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _10_ElvesLookElvesSay.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
