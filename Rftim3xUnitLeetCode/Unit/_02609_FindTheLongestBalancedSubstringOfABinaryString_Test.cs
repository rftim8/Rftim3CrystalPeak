using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02609_FindTheLongestBalancedSubstringOfABinaryString_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02609_FindTheLongestBalancedSubstringOfABinaryString))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02609_FindTheLongestBalancedSubstringOfABinaryString))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02609_FindTheLongestBalancedSubstringOfABinaryString))![1]);

        public static TheoryData<List<string>, int> _02609_FindTheLongestBalancedSubstringOfABinaryStringPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02609_FindTheLongestBalancedSubstringOfABinaryStringPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02609_FindTheLongestBalancedSubstringOfABinaryStringPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02609_FindTheLongestBalancedSubstringOfABinaryString.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02609_FindTheLongestBalancedSubstringOfABinaryStringPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02609_FindTheLongestBalancedSubstringOfABinaryString.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
