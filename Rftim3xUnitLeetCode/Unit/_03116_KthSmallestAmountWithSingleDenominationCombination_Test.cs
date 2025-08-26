using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03116_KthSmallestAmountWithSingleDenominationCombination_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03116_KthSmallestAmountWithSingleDenominationCombination))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03116_KthSmallestAmountWithSingleDenominationCombination))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03116_KthSmallestAmountWithSingleDenominationCombination))![1]);

        public static TheoryData<List<string>, int> _03116_KthSmallestAmountWithSingleDenominationCombinationPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03116_KthSmallestAmountWithSingleDenominationCombinationPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03116_KthSmallestAmountWithSingleDenominationCombinationPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03116_KthSmallestAmountWithSingleDenominationCombination.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03116_KthSmallestAmountWithSingleDenominationCombinationPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03116_KthSmallestAmountWithSingleDenominationCombination.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
