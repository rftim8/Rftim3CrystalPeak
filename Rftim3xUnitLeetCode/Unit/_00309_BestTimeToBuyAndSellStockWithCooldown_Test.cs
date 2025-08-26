using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00309_BestTimeToBuyAndSellStockWithCooldown_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00309_BestTimeToBuyAndSellStockWithCooldown))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00309_BestTimeToBuyAndSellStockWithCooldown))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00309_BestTimeToBuyAndSellStockWithCooldown))![1]);

        public static TheoryData<List<string>, int> _00309_BestTimeToBuyAndSellStockWithCooldownPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00309_BestTimeToBuyAndSellStockWithCooldownPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00309_BestTimeToBuyAndSellStockWithCooldownPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00309_BestTimeToBuyAndSellStockWithCooldown.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00309_BestTimeToBuyAndSellStockWithCooldownPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00309_BestTimeToBuyAndSellStockWithCooldown.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
