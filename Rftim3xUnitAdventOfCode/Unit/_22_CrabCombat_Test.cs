using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _22_CrabCombat_Test
    {
        // Arrange
        private static readonly List<string> Input = [.. string.Join("\r\n", RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_22_CrabCombat))!).Split("\r\n\r\n")];
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_22_CrabCombat))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_22_CrabCombat))![1]);

        public static TheoryData<List<string>, int> _22_CrabCombatPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _22_CrabCombatPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_22_CrabCombatPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _22_CrabCombat.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_22_CrabCombatPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _22_CrabCombat.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
