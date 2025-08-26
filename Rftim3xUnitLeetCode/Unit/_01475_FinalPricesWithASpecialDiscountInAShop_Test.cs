using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01475_FinalPricesWithASpecialDiscountInAShop_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01475_FinalPricesWithASpecialDiscountInAShop))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01475_FinalPricesWithASpecialDiscountInAShop))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01475_FinalPricesWithASpecialDiscountInAShop))![1]);

        public static TheoryData<List<string>, int> _01475_FinalPricesWithASpecialDiscountInAShopPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01475_FinalPricesWithASpecialDiscountInAShopPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01475_FinalPricesWithASpecialDiscountInAShopPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01475_FinalPricesWithASpecialDiscountInAShop.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01475_FinalPricesWithASpecialDiscountInAShopPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01475_FinalPricesWithASpecialDiscountInAShop.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
