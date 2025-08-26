using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03231_MinimumNumberOfIncreasingSubsequenceToBeRemoved_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03231_MinimumNumberOfIncreasingSubsequenceToBeRemoved))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03231_MinimumNumberOfIncreasingSubsequenceToBeRemoved))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03231_MinimumNumberOfIncreasingSubsequenceToBeRemoved))![1]);

        public static TheoryData<List<string>, int> _03231_MinimumNumberOfIncreasingSubsequenceToBeRemovedPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03231_MinimumNumberOfIncreasingSubsequenceToBeRemovedPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03231_MinimumNumberOfIncreasingSubsequenceToBeRemovedPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03231_MinimumNumberOfIncreasingSubsequenceToBeRemoved.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03231_MinimumNumberOfIncreasingSubsequenceToBeRemovedPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03231_MinimumNumberOfIncreasingSubsequenceToBeRemoved.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
