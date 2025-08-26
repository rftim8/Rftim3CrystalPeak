using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00309_BestTimeToBuyAndSellStockWithCooldown_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _00309_BestTimeToBuyAndSellStockWithCooldown_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00309_BestTimeToBuyAndSellStockWithCooldown_Data))]
        public void BestTimeToBuyAndSellStockWithCooldown0(int[] a0, int expected)
        {
            // Act
            int actual = _00309_BestTimeToBuyAndSellStockWithCooldown.BestTimeToBuyAndSellStockWithCooldown0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}