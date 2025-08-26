using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _17_ClumsyCrucible_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_17_ClumsyCrucible))!;
        private static readonly long ExpectedPartOne = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_17_ClumsyCrucible))![0]);
        private static readonly long ExpectedPartTwo = long.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_17_ClumsyCrucible))![1]);

        public static TheoryData<List<string>, long> _17_ClumsyCruciblePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, long> _17_ClumsyCruciblePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_17_ClumsyCruciblePartOne_Data))]
        public void PartOne(List<string> a0, long expected)
        {
            // Act
            long actual = _17_ClumsyCrucible.PartOne_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_17_ClumsyCruciblePartTwo_Data))]
        public void PartTwo(List<string> a0, long expected)
        {
            // Act
            long actual = _17_ClumsyCrucible.PartTwo_Test(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
