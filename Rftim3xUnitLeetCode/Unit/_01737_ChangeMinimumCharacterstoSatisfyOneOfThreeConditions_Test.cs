using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditions_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditions))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditions))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditions))![1]);

        public static TheoryData<List<string>, int> _01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditionsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditionsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditionsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditions.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditionsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01737_ChangeMinimumCharacterstoSatisfyOneOfThreeConditions.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
