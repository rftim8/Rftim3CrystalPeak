using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _13_KnightsOfTheDinnerTable_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_13_KnightsOfTheDinnerTable))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_KnightsOfTheDinnerTable))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_KnightsOfTheDinnerTable))![1]);

        public static TheoryData<List<string>, int> _13_KnightsOfTheDinnerTablePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _13_KnightsOfTheDinnerTablePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_13_KnightsOfTheDinnerTablePartOne_Data))]
        public static void RftPartOne(List<string> file, int expected)
        {
            // Act
            int actual = _13_KnightsOfTheDinnerTable.PartOne_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_13_KnightsOfTheDinnerTablePartTwo_Data))]
        public static void RftPartTwo(List<string> file, int expected)
        {
            // Act
            int actual = _13_KnightsOfTheDinnerTable.PartTwo_Test(file);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
