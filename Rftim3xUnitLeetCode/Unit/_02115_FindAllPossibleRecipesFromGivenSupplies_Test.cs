using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02115_FindAllPossibleRecipesFromGivenSupplies_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02115_FindAllPossibleRecipesFromGivenSupplies))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02115_FindAllPossibleRecipesFromGivenSupplies))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02115_FindAllPossibleRecipesFromGivenSupplies))![1]);

        public static TheoryData<List<string>, int> _02115_FindAllPossibleRecipesFromGivenSuppliesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02115_FindAllPossibleRecipesFromGivenSuppliesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02115_FindAllPossibleRecipesFromGivenSuppliesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02115_FindAllPossibleRecipesFromGivenSupplies.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02115_FindAllPossibleRecipesFromGivenSuppliesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02115_FindAllPossibleRecipesFromGivenSupplies.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
