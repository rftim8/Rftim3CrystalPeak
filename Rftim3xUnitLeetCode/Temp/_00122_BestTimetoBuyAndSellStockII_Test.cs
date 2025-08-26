using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00122_BestTimeToBuyAndSellStockII_Test
    {
        // Arrange
        private static readonly int[] a0 = [7, 1, 5, 3, 6, 4];
        private static readonly int ar = 7;

        private static readonly int[] b0 = [1, 2, 3, 4, 5];
        private static readonly int br = 4;

        private static readonly int[] c0 = [7, 6, 4, 3, 1];
        private static readonly int cr = 0;

        public static TheoryData<int[], int> _00122_BestTimeToBuyAndSellStockII_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00122_BestTimeToBuyAndSellStockII_Data))]
        public void BestTimeToBuyAndSellStockII0(int[] a0, int expected)
        {
            // Act
            int actual = _00122_BestTimeToBuyAndSellStockII.BestTimeToBuyAndSellStockII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}