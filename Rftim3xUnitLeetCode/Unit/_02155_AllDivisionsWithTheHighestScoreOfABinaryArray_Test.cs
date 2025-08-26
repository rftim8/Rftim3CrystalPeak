using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02155_AllDivisionsWithTheHighestScoreOfABinaryArray_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02155_AllDivisionsWithTheHighestScoreOfABinaryArray))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02155_AllDivisionsWithTheHighestScoreOfABinaryArray))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02155_AllDivisionsWithTheHighestScoreOfABinaryArray))![1]);

        public static TheoryData<List<string>, int> _02155_AllDivisionsWithTheHighestScoreOfABinaryArrayPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02155_AllDivisionsWithTheHighestScoreOfABinaryArrayPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02155_AllDivisionsWithTheHighestScoreOfABinaryArrayPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02155_AllDivisionsWithTheHighestScoreOfABinaryArray.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02155_AllDivisionsWithTheHighestScoreOfABinaryArrayPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02155_AllDivisionsWithTheHighestScoreOfABinaryArray.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
