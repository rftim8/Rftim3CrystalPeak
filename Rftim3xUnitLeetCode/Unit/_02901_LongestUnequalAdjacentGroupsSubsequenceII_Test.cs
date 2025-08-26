using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02901_LongestUnequalAdjacentGroupsSubsequenceII_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02901_LongestUnequalAdjacentGroupsSubsequenceII))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02901_LongestUnequalAdjacentGroupsSubsequenceII))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02901_LongestUnequalAdjacentGroupsSubsequenceII))![1]);

        public static TheoryData<List<string>, int> _02901_LongestUnequalAdjacentGroupsSubsequenceIIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02901_LongestUnequalAdjacentGroupsSubsequenceIIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02901_LongestUnequalAdjacentGroupsSubsequenceIIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02901_LongestUnequalAdjacentGroupsSubsequenceII.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02901_LongestUnequalAdjacentGroupsSubsequenceIIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02901_LongestUnequalAdjacentGroupsSubsequenceII.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
