using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00123_BestTimeToBuyAndSellStockIII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _00123_BestTimeToBuyAndSellStockIII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00123_BestTimeToBuyAndSellStockIII_Data))]
        public void BestTimeToBuyAndSellStockIII0(int[] a0, int expected)
        {
            // Act
            int actual = _00123_BestTimeToBuyAndSellStockIII.BestTimeToBuyAndSellStockIII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}