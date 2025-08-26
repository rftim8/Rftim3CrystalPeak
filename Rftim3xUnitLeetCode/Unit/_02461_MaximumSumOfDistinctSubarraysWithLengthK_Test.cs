using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02461_MaximumSumOfDistinctSubarraysWithLengthK_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02461_MaximumSumOfDistinctSubarraysWithLengthK))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02461_MaximumSumOfDistinctSubarraysWithLengthK))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02461_MaximumSumOfDistinctSubarraysWithLengthK))![1]);

        public static TheoryData<List<string>, int> _02461_MaximumSumOfDistinctSubarraysWithLengthKPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02461_MaximumSumOfDistinctSubarraysWithLengthKPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02461_MaximumSumOfDistinctSubarraysWithLengthKPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02461_MaximumSumOfDistinctSubarraysWithLengthK.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02461_MaximumSumOfDistinctSubarraysWithLengthKPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02461_MaximumSumOfDistinctSubarraysWithLengthK.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
