using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _05_SupplyStacks_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_05_SupplyStacks))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_SupplyStacks))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_05_SupplyStacks))![1];

        public static TheoryData<List<string>, string> _05_SupplyStacksPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _05_SupplyStacksPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_05_SupplyStacksPartOne_Data))]
        public void RftPartOne(List<string> a0, string expected)
        {
            // Act
            string actual = _05_SupplyStacks.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_05_SupplyStacksPartTwo_Data))]
        public void RftPartTwo(List<string> a0, string expected)
        {
            // Act
            string actual = _05_SupplyStacks.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
