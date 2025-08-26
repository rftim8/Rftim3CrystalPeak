using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02829_DetermineTheMinimumSumOfAKAvoidingArray_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02829_DetermineTheMinimumSumOfAKAvoidingArray))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02829_DetermineTheMinimumSumOfAKAvoidingArray))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02829_DetermineTheMinimumSumOfAKAvoidingArray))![1]);

        public static TheoryData<List<string>, int> _02829_DetermineTheMinimumSumOfAKAvoidingArrayPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02829_DetermineTheMinimumSumOfAKAvoidingArrayPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02829_DetermineTheMinimumSumOfAKAvoidingArrayPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02829_DetermineTheMinimumSumOfAKAvoidingArray.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02829_DetermineTheMinimumSumOfAKAvoidingArrayPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02829_DetermineTheMinimumSumOfAKAvoidingArray.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
