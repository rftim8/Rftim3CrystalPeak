using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02144_MinimumCostOfBuyingCandiesWithDiscount_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02144_MinimumCostOfBuyingCandiesWithDiscount))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02144_MinimumCostOfBuyingCandiesWithDiscount))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02144_MinimumCostOfBuyingCandiesWithDiscount))![1]);

        public static TheoryData<List<string>, int> _02144_MinimumCostOfBuyingCandiesWithDiscountPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02144_MinimumCostOfBuyingCandiesWithDiscountPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02144_MinimumCostOfBuyingCandiesWithDiscountPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02144_MinimumCostOfBuyingCandiesWithDiscount.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02144_MinimumCostOfBuyingCandiesWithDiscountPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02144_MinimumCostOfBuyingCandiesWithDiscount.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
