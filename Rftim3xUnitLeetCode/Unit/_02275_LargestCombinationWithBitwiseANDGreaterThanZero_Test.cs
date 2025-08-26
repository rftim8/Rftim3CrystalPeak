using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02275_LargestCombinationWithBitwiseANDGreaterThanZero_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02275_LargestCombinationWithBitwiseANDGreaterThanZero))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02275_LargestCombinationWithBitwiseANDGreaterThanZero))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02275_LargestCombinationWithBitwiseANDGreaterThanZero))![1]);

        public static TheoryData<List<string>, int> _02275_LargestCombinationWithBitwiseANDGreaterThanZeroPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02275_LargestCombinationWithBitwiseANDGreaterThanZeroPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02275_LargestCombinationWithBitwiseANDGreaterThanZeroPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02275_LargestCombinationWithBitwiseANDGreaterThanZero.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02275_LargestCombinationWithBitwiseANDGreaterThanZeroPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02275_LargestCombinationWithBitwiseANDGreaterThanZero.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
