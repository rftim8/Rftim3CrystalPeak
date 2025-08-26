using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _20_ARegularMap_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_20_ARegularMap))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_ARegularMap))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_20_ARegularMap))![1]);

        public static TheoryData<List<string>, int> _20_ARegularMapPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _20_ARegularMapPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_20_ARegularMapPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _20_ARegularMap.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_20_ARegularMapPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _20_ARegularMap.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
