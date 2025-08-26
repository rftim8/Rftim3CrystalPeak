using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _18_SettlersOfTheNorthPole_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_18_SettlersOfTheNorthPole))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_SettlersOfTheNorthPole))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_18_SettlersOfTheNorthPole))![1]);

        public static TheoryData<List<string>, int> _18_SettlersOfTheNorthPolePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _18_SettlersOfTheNorthPolePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_18_SettlersOfTheNorthPolePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _18_SettlersOfTheNorthPole.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_18_SettlersOfTheNorthPolePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _18_SettlersOfTheNorthPole.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
