using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _18_Duet_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_18_Duet))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_Duet))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_Duet))![1]);

        public static TheoryData<List<string>, int> _18_DuetPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _18_DuetPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_18_DuetPartOne_Data))]
        public void RftPartOne(List<string> input, int expected)
        {
            // Act
            int actual = _18_Duet.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_18_DuetPartTwo_Data))]
        public void RftPartTwo(List<string> input, int expected)
        {
            // Act
            int actual = _18_Duet.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
