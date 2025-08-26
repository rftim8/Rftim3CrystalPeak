using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _13_MineCartMadness_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_13_MineCartMadness))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_MineCartMadness))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_MineCartMadness))![1];

        public static TheoryData<List<string>, string> _13_MineCartMadnessPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _13_MineCartMadnessPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_13_MineCartMadnessPartOne_Data))]
        public void RftPartOne(List<string> a0, string expected)
        {
            // Act
            string actual = _13_MineCartMadness.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_13_MineCartMadnessPartTwo_Data))]
        public void RftPartTwo(List<string> a0, string expected)
        {
            // Act
            string actual = _13_MineCartMadness.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
