using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevel_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevel))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevel))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevel))![1]);

        public static TheoryData<List<string>, int> _02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevelPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevelPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevelPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevel.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevelPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02471_MinimumNumberOfOperationsToSortaBinaryTreeByLevel.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
