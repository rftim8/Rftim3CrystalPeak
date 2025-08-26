using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02099_FindSubsequenceOfLengthKWithTheLargestSum_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02099_FindSubsequenceOfLengthKWithTheLargestSum))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02099_FindSubsequenceOfLengthKWithTheLargestSum))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02099_FindSubsequenceOfLengthKWithTheLargestSum))![1]);

        public static TheoryData<List<string>, int> _02099_FindSubsequenceOfLengthKWithTheLargestSumPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02099_FindSubsequenceOfLengthKWithTheLargestSumPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02099_FindSubsequenceOfLengthKWithTheLargestSumPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02099_FindSubsequenceOfLengthKWithTheLargestSum.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02099_FindSubsequenceOfLengthKWithTheLargestSumPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02099_FindSubsequenceOfLengthKWithTheLargestSum.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
