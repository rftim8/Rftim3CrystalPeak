using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _24_BlizzardBasin_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_24_BlizzardBasin))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_BlizzardBasin))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_24_BlizzardBasin))![1]);

        public static TheoryData<List<string>, int> _24_BlizzardBasinPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _24_BlizzardBasinPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_24_BlizzardBasinPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _24_BlizzardBasin.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Incomplete")]
        [MemberData(nameof(_24_BlizzardBasinPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _24_BlizzardBasin.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
