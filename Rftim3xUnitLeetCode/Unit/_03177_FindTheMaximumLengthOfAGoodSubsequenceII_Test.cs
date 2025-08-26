using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03177_FindTheMaximumLengthOfAGoodSubsequenceII_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03177_FindTheMaximumLengthOfAGoodSubsequenceII))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03177_FindTheMaximumLengthOfAGoodSubsequenceII))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03177_FindTheMaximumLengthOfAGoodSubsequenceII))![1]);

        public static TheoryData<List<string>, int> _03177_FindTheMaximumLengthOfAGoodSubsequenceIIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03177_FindTheMaximumLengthOfAGoodSubsequenceIIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03177_FindTheMaximumLengthOfAGoodSubsequenceIIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03177_FindTheMaximumLengthOfAGoodSubsequenceII.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03177_FindTheMaximumLengthOfAGoodSubsequenceIIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03177_FindTheMaximumLengthOfAGoodSubsequenceII.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
