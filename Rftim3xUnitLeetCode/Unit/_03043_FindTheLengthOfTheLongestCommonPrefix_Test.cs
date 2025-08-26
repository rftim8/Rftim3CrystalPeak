using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03043_FindTheLengthOfTheLongestCommonPrefix_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03043_FindTheLengthOfTheLongestCommonPrefix))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03043_FindTheLengthOfTheLongestCommonPrefix))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03043_FindTheLengthOfTheLongestCommonPrefix))![1]);

        public static TheoryData<List<string>, int> _03043_FindTheLengthOfTheLongestCommonPrefixPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03043_FindTheLengthOfTheLongestCommonPrefixPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03043_FindTheLengthOfTheLongestCommonPrefixPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03043_FindTheLengthOfTheLongestCommonPrefix.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03043_FindTheLengthOfTheLongestCommonPrefixPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03043_FindTheLengthOfTheLongestCommonPrefix.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
